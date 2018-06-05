using System;
using System.Collections.Generic;


namespace Code_Bot.Logic
{
    public class Interpreter : Reader
    {
        private List<string> _linesInLoop = new List<string>();
        private int _loopValue;
        private int _openingLineNo;
        private bool _looping = false;
        public Interpreter(string input, Props.Bot bot, Levels.ParentLevel form) : base(input, bot, form)
        {
            reset();
            while (_postText != "")
            {
                nextLine();
                processLine(_currentLine);
            }
        }

        private void processLine(string line)
        {
            //takes the approriate action depending on the value of line
            //@param: _currentLine when line outside a loop or an item in linesInLoop[] when executing a loop
            if (!bot.Crashed)
            {

                if (_looping)
                {
                    if (line.Contains("}"))
                    {
                        _looping = false;
                        _lineNo = _openingLineNo;
                        executeLoop();
                        _linesInLoop.Clear();
                    }
                    else
                        _linesInLoop.Add(line);
                }
                else if (!_looping && line != "" && !line.StartsWith("//"))
                {

                    if (line.Contains("{"))
                    {
                        _looping = true;
                        _openingLineNo = _lineNo;
                    }
                    else
                    {
                        form.RtfOutputLineNumbers.Text += _lineNo + "\n";
                    }

                    if (line.StartsWith("loop"))
                    {
                        setLoopValue(line);
                    }
                    else if (regexMethod.IsMatch(line))
                    {
                        splitMethod(line);
                        processMethod(line);
                    }
                    else if (regexNewVar.IsMatch(line)||regexNewVarEquals.IsMatch(line))
                    {
                        splitDeclareVar(line);
                        declareVar(line);
                    }
                    else if (regexChangeVar.IsMatch(line) || regexChangeVarMath.IsMatch(line))
                    {
                        foreach (var item in variables)
                        {
                            if (line.StartsWith(item.Name))
                            {
                                splitChangeVar(line);
                                changeVar(line);
                            }
                        }
                    }
                    else if (regexIncrement.IsMatch(line))
                    {
                        foreach (var item in variables)
                        {
                            if (line.StartsWith(item.Name))
                            {
                                splitChangeVar(line);
                                int value= Convert.ToInt16(item.Value);
                                value++;
                                item.Value = Convert.ToString(value);
                                form.RtfOutput.Text += "Value of " + item.Name + " incremented by one is now: " + item.Value +"\n"; 
                            }
                        }
                    }
                    else if (regexDecrement.IsMatch(line))
                    {
                        foreach (var item in variables)
                        {
                            if (line.StartsWith(item.Name))
                            {
                                splitChangeVar(line);
                                int value = Convert.ToInt16(item.Value);
                                value--;
                                item.Value = Convert.ToString(value);
                                form.RtfOutput.Text += "Value of " + item.Name + " decremented by one is now: " + item.Value + "\n";
                            }
                        }
                    }
                }

            }
        }

        private void processMethod(string line)
        {//SplitMethod() in reader class
            _varValue = _parameter;
            _varName = "";
            foreach (var item in variables)
            {
                if (_parameter == item.Name)
                {
                    _varValue = item.Value;
                    _varName = item.Name;
                    break;
                }
            }

            if (_varName == "")
                _parameter = _varValue;
            else
                _parameter = _varName + "(" + _varValue + ")";

            form.RtfOutput.Text += "Object: " + _object + "   Method: " + _method;
            if (_parameter != "")
                form.RtfOutput.Text += "    Parameter: " + _parameter;
            form.RtfOutput.Text += "\n";
            switch (_method)
            {
                case "Move":
                    if (_varValue == "")
                    {
                        bot.Move(1);
                    }
                    else
                    {
                        int distance = Convert.ToInt16(_varValue);
                        bot.Move(distance);
                        if (distance < 0)
                        {
                            form.RtfOutput.Text += "Warning: the bot can not reverse!\n";
                            form.RtfOutputLineNumbers.Text += "\n";
                        }
                    }
                    break;
                case "Turn":
                    switch (_varValue)
                    {
                        case "\"left\"":
                            bot.Turn("left");
                            break;
                        case "\"right\"":
                            bot.Turn("right");
                            break;
                    }
                    break;
            }
        }

        private void executeLoop()
        {

            for (int j = _loopValue; j > 0; j--)
            {
                if (!bot.Crashed)
                {
                    form.RtfOutput.Text += Convert.ToString(j) + " loops remaining\n";
                    form.RtfOutputLineNumbers.Text += _openingLineNo + "\n";
                }
                _lineNo = _openingLineNo;
                for (int i = 0; i < _linesInLoop.Count; i++)
                {
                    string line = _linesInLoop[i];
                    _lineNo++;
                    processLine(line);
                }

            }
            _lineNo = _openingLineNo + _linesInLoop.Count;
            _lineNo++;
            form.RtfOutputLineNumbers.Text += _lineNo + "\n";
            if (!bot.Crashed)
                form.RtfOutput.Text += "Loop ended\n";
        }

        private void setLoopValue(string line)
        {
            string loopValueStr = line.Split('(', ')')[1];
            foreach (var item in variables)
            {
                if (loopValueStr == item.Name)
                    loopValueStr = Convert.ToString(item.Value);
            }
            _loopValue = Convert.ToInt16(loopValueStr);
            form.RtfOutput.Text += "Loop: " + loopValueStr + " times\n";
            if (_loopValue < 1)
                form.RtfOutput.Text += "Warning: nothing happens if you try to loop " + loopValueStr + " times!\n";
        }

        protected override void declareVar(string line)
        {
            base.declareVar(line);
            form.RtfOutput.Text += "Variable type: " + _varType + "    Variable Name: " + _varName;
            if (_varValue != "")
                form.RtfOutput.Text += "    Value: " + _varValue;
            form.RtfOutput.Text += "\n";
        }


        private void changeVar(string line)
        {
            if (regexChangeVar.IsMatch(line))
            {
                //change item2 where item1 = varname
                foreach (var item in variables)
                {
                    if (item.Name == _varName)
                    {
                        item.Value = _varValue;
                    }
                }
            }
            else if (regexChangeVarMath.IsMatch(line))//only works with ints
            {
                int firstInt;
                int secondInt;
                int result = 0;
                foreach (var item in variables)
                {
                    if (item.Name == _varValue)
                        firstInt = Convert.ToInt16(item.Value);
                    else
                        firstInt = Convert.ToInt16(_varValue);

                    if (item.Name == _otherValue)
                        secondInt = Convert.ToInt16(item.Value);
                    else
                        secondInt = Convert.ToInt16(_otherValue);

                    if (item.Name == _varName)
                    {

                        switch (_operator)
                        {
                            case '+':
                                result = firstInt + secondInt;
                                break;
                            case '-':
                                result = firstInt - secondInt;
                                break;
                            case '/':
                                result = firstInt / secondInt;
                                break;
                            case '*':
                                result = firstInt * secondInt;
                                break;

                        }
                        _varValue = Convert.ToString(result);
                        item.Value = _varValue;
                    }
                }
            }
            form.RtfOutput.Text += "The value of '" + _varName + "' has been changed to " + _varValue + "\n";
        }
    }
}

