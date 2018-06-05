using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_Bot.Logic
{
    public class ErrorChecker : Reader
    {

        public bool HasError { get; private set; }
        private string  _outputText = "";

        public ErrorChecker(string input, Props.Bot bot, Levels.ParentLevel form) : base(input, bot, form)
        {
            HasError = false;
            reset();
            do
            {
                findError();
                nextLine();
                _preIndex += _currentLine.Length + 1;
                if (_postText != "")
                    _preText = _inputText.Substring(0, _preIndex);
            }
            while (_postText != "");
        }


        private void findError()
        {//Stops the program continuing, and displays an error message if an error is found        
         //Check _currentLine for error

            if (regexMethod.IsMatch(_currentLine))
            {//check method for errors
                List<string> objects = new List<string>(new string[] { "bot" });//there may be more than one interactable object in future updates
                List<string> methods = new List<string>();
                List<string> parameters = new List<string>();

                splitMethod(_currentLine);

                if (_object == "bot")
                {
                    methods = new List<string>(new string[] { "Move", "Turn" });
                    if (_method == "Turn")
                    {
                        parameters = new List<string>(new string[] { "\"left\"", "\"right\"" });
                        foreach (var item in variables)
                        {
                            if (item.Name == _parameter)
                            {
                                _parameter = item.Value;
                            }
                        }
                        if (!parameters.Contains(_parameter))
                             _outputText = "Invalid parameter for 'Turn': " + _parameter + "\nCommands are case sensitive and string parameters must be in quotes\n"+
                                "Try: 'bot.Turn(\"left\");' or 'bot.Turn(\"right\");' .\n"+
                                "If you are using a varible as a parameter, it's value must be \"left\" or \"right\"";
                    }
                    else if (_method == "Move")
                    {
                        foreach (var item in variables)
                        {
                            if (item.Name == _parameter)
                            {
                                _parameter = item.Value.ToString();
                                if (_parameter == "")
                                     _outputText = "Variable '" + item.Name + "' has not been set a value";
                            }
                        }
                        if (!regexInt.IsMatch(_parameter) && _parameter != "")
                             _outputText =  _outputText = "Invalid parameter for 'Move': " + _parameter + "\nThe parameter for 'Move' must be an integer or integer variable:\n"+
                                "There must be either: A whole number with out symbols or letters\n" +
                                "between the brackets: '(' ')'.\n Or: An existing integer variable declared in a line above \nbetween the brackets: '(' ')'.";
                    }
                }
                if (!objects.Contains(_object))
                {
                     _outputText = "Invalid object: '" + _object + "'.";
                    if (!Regex.IsMatch(_object, "^[a-z]"))
                    {
                         _outputText += "\nObjects such as " + char.ToLower(_object[0]) + _object.Substring(1) + " begin with lower case letters.";
                    }
                }
                else if (!methods.Contains(_method))
                {
                     _outputText = "Invalid method for " + _object + ":'" + _method + "'.";
                    if (!Regex.IsMatch(_method, "^[A-Z]"))
                    {
                         _outputText += "\nPublic Methods such as " + char.ToUpper(_method[0]) + _method.Substring(1) + " begin with capital letters.";
                    }
                }
            }

            else if (_currentLine.Contains("Move") || _currentLine.Contains("Turn"))
            {//method has incorrect syntax
                if (!_currentLine.Contains('(') || !_currentLine.Contains(')'))
                     _outputText = "You must use  2 brackets: '(' and ')' in a method.";
                else if (_currentLine.StartsWith("bot") && !_currentLine.StartsWith("bot."))
                     _outputText = "You must differentiate the object from the method\n 'bot' and '" + _currentLine.Substring(3, _currentLine.Length - 3) + " must be seperated with a '.'.";
                else if (!_currentLine.Contains(".") || _currentLine.StartsWith("."))
                {
                    string substring;
                    if (_currentLine.StartsWith("."))
                        substring = _currentLine.Substring(1, _currentLine.Length - 1);
                    else
                        substring = _currentLine;
                     _outputText = "Missing object to '" + substring + "' try: bot." + substring + ".";
                }
                else if (_currentLine.EndsWith(";"))
                     _outputText = "Syntax Error: '" + _currentLine + "'\nYou may have some extra or missing charecters.";
            }

            else if (regexNewVar.IsMatch(_currentLine) || regexNewVarEquals.IsMatch(_currentLine))
            {//check variable decleration for errors
                splitDeclareVar(_currentLine);
                if (_varType != "string" && _varType != "int")
                {
                     _outputText = "Invalid variable type: '" + _varType + "'.\nTry 'string' or 'int' in lower case";
                }
                else if (variables.Any(v => v.Name == _varName))
                {
                     _outputText = "You cannot declare a variable with the same name twice.\nChange this variable using '" + _varName + " =" + _varValue + "'.";
                }
                else if (regexInt.IsMatch(Convert.ToString(_varName.FirstOrDefault())) || Regex.IsMatch(_varName, @"^[^A-Za-z0-9_]$") || _varName.Contains(' '))
                     _outputText = "Varible names may not contain symbols or spaces or start with numbers.";
                else if (new[] { "string", "int", "bool", "float", "char", "loop" }.Contains(_varName))
                     _outputText = "'" + _varName + "' may not be used as a variable name.";

                if (regexNewVarEquals.IsMatch(_currentLine))
                {
                    if (_varType == "int" && !regexInt.IsMatch(_varValue))
                         _outputText = "Integer values may only be whole numbers.";
                    else if (_varType == "string" && !regexString.IsMatch(_varValue))
                         _outputText = "Strings must (only) have double quotation marks at beggining and end.\nFor Example: \"direction\".";
                }

                if ( _outputText == "")
                    declareVar(_currentLine);
            }

            else if (regexChangeVar.IsMatch(_currentLine))
            {
                splitChangeVar(_currentLine);
                if (variables.All(v => !_varName.Contains(v.Name)))
                    //error if variables list does not contain variable name
                     _outputText = "The variable: '" + _varName + "' has not been declared.";
                else
                {
                    foreach (var item in variables)
                    {
                        if (_varName == item.Name)
                        {
                            if (item.Type == "string" && !regexString.IsMatch(_varValue) || item.Type == "int" && !regexInt.IsMatch(_varValue))
                                 _outputText = "'" + _varName + "' is of type '" + item.Type + "' and may not be changed.";
                        }
                    }
                }
            }

            else if (regexChangeVarMath.IsMatch(_currentLine))
            {
                splitChangeVar(_currentLine);
                foreach (var item in variables)
                {
                    if (item.Name == _varValue)
                        _varValue = item.Value.ToString();
                    if (item.Name == _otherValue)
                        _otherValue = item.Value.ToString();
                    if (!regexInt.IsMatch(_varValue) || !regexInt.IsMatch(_otherValue))
                         _outputText = "Mathematical operations may only be applied to integers or declared integer variables.";
                }
                if (variables.All(v => !_varName.Contains(v.Name)))
                     _outputText = "The variable: '" + _varName + "' has not been declared.";
            }

            else if (_currentLine.Contains("}") || _currentLine.Contains("{"))
            {
                if (_currentLine != "}" && _currentLine != "{")
                     _outputText = "Lines with Braces '{' or '}' must contain 1 brace and nothing else.";
                else if (!_inputText.Contains("loop") || !_preText.Contains("loop"))
                {
                    if (_currentLine == "{")
                         _outputText = "Unnecessary brace: '{'.";
                    else
                         _outputText = "Unnecessary brace: '}'.";
                }
            }

            else if (_currentLine.StartsWith("loop"))
            {
                if (!_currentLine.Contains('(') || !_currentLine.Contains(')'))
                     _outputText = "You must use 2 brackets: '(' ')' in a loop.";
                else
                {
                    string loopValue = _currentLine.Split('(', ')')[1];
                    foreach (var item in variables)
                    {
                        if (loopValue == item.Name)
                            loopValue = Convert.ToString(item.Value);
                    }
                    if (!regexInt.IsMatch(loopValue))
                         _outputText = "The loop parameter must be a typed integer or existing integer variable: \nThere must be a whole number wihout symbols or letters \nbetween the brackets '(' ')'.";

                    else if (_currentLine.Contains(";"))
                         _outputText = "loop statements must not contain semicolon ';'.";
                }
            }
            else if (_currentLine.Contains("++") || _currentLine.Contains("--"))
            {
                foreach (var item in variables)
                {
                    if (_currentLine.StartsWith(item.Name))
                    {
                        if (item.Type != "int")
                            _outputText = "you may only increment or decrement int variables";
                    }
                }
            }
            else
                 _outputText = "Unrecognized Command: '" + _currentLine + "'\nRemember that commands are case sensitive!";


            if (!_currentLine.EndsWith(";") && !_currentLine.Contains("loop") && !_currentLine.Contains("{") && !_currentLine.Contains("}"))
            {// this doesn't work and i have no idea why
                 _outputText = "You must end this line with a semicolon ';'.";
            }

            if (_currentLine == "" || _currentLine.StartsWith("//"))
                 _outputText = ""; //if line is blank or comment: no error
            if ( _outputText != "")
                errorMessage(_lineNo);


            //Check _inputText for error
            if (_postText.StartsWith("loop"))
            {
                if (!_postText.Contains('}') || !_postText.Contains('{'))
                     _outputText = "The body of the loop must be opened with opening brace: '{'\nand closed with a closing brace: '}'\nor the program wont know what is inside or outside the loop.";
                else if (_postText.Contains(")"))
                {
                    int index = _postText.IndexOf(')');
                    string substring = _postText.Substring(index, _postText.IndexOf('{') - index + 1);
                    substring = Regex.Replace(substring, @"[\s\n]+", string.Empty);
                    if (substring != "){")
                         _outputText = "The body of the loop must be declared under the loop statement as follows:\nloop(<number>)\n{\n//code here\n}";
                }

            }
            else if (_postText.StartsWith("{") && _postText.Contains("}"))
            {
                int index = _postText.IndexOf('}');
                string substring = _postText.Substring(1, index - 1);
                if (substring.Contains('{'))
                     _outputText = "use only 1 opening brace '{' within a loop.";
                if (substring.Contains("loop"))
                     _outputText = "Nested loops (loops witin loops) may not be used in Code_Bot.";
            }
            else if (_postText.StartsWith("}"))
            {
                string substring;
                if (_postText.Contains("loop"))
                    substring = _postText.Substring(1, _postText.IndexOf("loop") - 1);
                else
                    substring = _postText.Substring(1, _postText.LastIndexOf("\n"));
                if (_preText.Contains("loop"))
                {
                    if (substring.Contains('}') && substring.Contains('{'))
                         _outputText = "unneccessary closing and opening braces: '{' '}' (below this line).";
                    else if (substring.Contains('}'))
                         _outputText = "unneccessary closing brace(s): '}' (below this line).";
                    else if (substring.Contains('{'))
                         _outputText = "unneccessary opening brace(s): '{' (below this line).";
                }
            }
            if ( _outputText != "")
                errorMessage(_lineNo + 1);
        }


        private void errorMessage(int lineNo)
        {
            if (!HasError)//only show message box once if error
                MessageBox.Show("Whoops, looks like there are some errors in your code!\nCheck the error textbox for details.\n",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            HasError = true;
            int lineCount = _outputText.Count(v => v == '\n') + 2;
            string linesToAdd = "";
            for (int i = 0; i < lineCount; i++)
                linesToAdd += "\n";
            form.RtfOutputLineNumbers.Text += lineNo + linesToAdd;
            form.RtfOutput.Text += _outputText + "\n\n";
            _outputText = "";

        }


    }
}



