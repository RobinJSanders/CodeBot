using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Code_Bot.Logic
{
    public class Reader
    {
        //variables used for counting lines storing text before and after current line
        protected int _lineNo;
        protected int _index;
        protected int _preIndex;
        protected string _inputText;
        protected string _postText;
        protected string _preText;
        protected string _currentLine;
        protected string _outputText;

        //variables used for reading methods
        protected Regex regexMethod = new Regex(@"^\s*[0-9a-zA-Z_]+\s*\.\s*[0-9a-zA-Z_]+\s*\(\s*[^()]*\s*\)\s*\;\s*$");
        protected string _object;
        protected string _method;
        protected string _parameter;

        //variables used for reading variable declerations
        protected Regex regexNewVar = new Regex(@"^\s*[0-9a-zA-Z_]+\s+[0-9a-zA-Z_]+\s*;$");
        protected Regex regexNewVarEquals = new Regex(@"^\s*[0-9a-zA-Z_]+\s+[0-9a-zA-Z_]+\s*\=\s*[0-9a-zA-Z_""]+\s*\;\s*$");
        protected Regex regexInt = new Regex(@"^\-?[0-9]+$");
        protected Regex regexString = new Regex(@"^""[^ ""]*""$");
        protected List<StoredVar> variables = new List<StoredVar>();
        protected string _varType;
        protected string _varName;
        protected string _varValue;

        //variables used for changing existing items in variable list
        protected Regex regexChangeVar = new Regex(@"^\s*[0-9a-zA-Z_]+\s*\=\s*[0-9a-zA-Z_""]+\s*;\s*$");
        protected Regex regexChangeVarMath = new Regex(@"^\s*[0-9a-zA-Z_]+\s*\=\s*[0-9a-zA-Z_""]+\s*[+\-*\/]\s*[0-9a-zA-Z_""]+\s*\;\s*$");
        protected Regex regexDecrement = new Regex(@"^\s*[0-9a-zA-Z_]+\s*\-{2}\s*;$");
        protected Regex regexIncrement = new Regex(@"^\s*[0-9a-zA-Z_]+\s*\+{2}\s*;$");
        protected char _operator;
        protected string _otherValue;

        protected Props.Bot bot;
        protected Levels.ParentLevel form;


        public Reader(string input, Props.Bot bot, Levels.ParentLevel form)
        {
            _inputText = input + "\n\n";
            this.bot = bot; 
            this.form = form;
            _lineNo = 0;
            variables.Clear();
        }

        protected void nextLine()
        {
            _lineNo++;
            _index = _postText.IndexOf("\n");
            _currentLine = _postText.Substring(0, _index).Trim();
            _postText = _postText.Substring(_index + 1, _postText.Length - (_index) - 1);
        }


        protected void reset()
        {
            _currentLine = "";
            _index = 0;
            _postText = _inputText;
            _lineNo = 0;
            _preIndex = 0;
            _preText = "";
        }

        protected void splitMethod(string line)
        {//Splits a method into its components
            int bracketIndex = line.IndexOf('(');
            int dotIndex = line.IndexOf('.');
            _object = line.Substring(0, dotIndex);
            _method = line.Substring(dotIndex + 1, bracketIndex - _object.Length - 1);
            _parameter = line.Split('(', ')')[1];
            //remove extra whitespace
            _object = _object.Trim();
            _method = _method.Trim();
            _parameter = _parameter.Trim();
        }

        protected void splitDeclareVar(string line)//requires testing
        {//Splits an integer decleration into its components
            int spaceIndex = line.IndexOf(' ');
            _varType = line.Substring(0, spaceIndex);
            if (line.Contains("="))
            {
                _varValue = line.Split('=', ';')[1];
                int equalsIndex = line.IndexOf('=');
                _varName = line.Substring(spaceIndex + 1, equalsIndex - _varType.Length - 1);
            }
            else
            {
                int semicolonIndex = line.IndexOf(';');
                _varName = line.Substring(spaceIndex + 1, semicolonIndex - _varType.Length - 1);
                _varValue = "";
            }

            //remove extra whitespace
            _varType = _varType.Trim();
            _varName = _varName.Trim();
            _varValue = _varValue.Trim();
        }

        protected void splitChangeVar(string line)
        {
            _varName = line.Split('=')[0];
            foreach (var item in variables)
                if (_varName == item.Name)
                    _varType = item.Type;
            if (regexChangeVar.IsMatch(line))
                _varValue = line.Split('=', ';')[1];
            else if (regexChangeVarMath.IsMatch(line))
            {
                int declerationIndex = line.IndexOf('='); ;
                if (line.Contains('+'))
                    _operator = '+';
                else if (line.Contains('-'))
                    _operator = '-';
                else if (line.Contains('*'))
                    _operator = '/';
                else if (line.Contains('/'))
                    _operator = '*';
                _varValue = line.Split('=', _operator)[1];
                _otherValue = line.Split(_operator, ';')[1];
                _otherValue = _otherValue.Trim();
            }
            _varName = _varName.Trim();
            _varValue = _varValue.Trim();
        }

        protected virtual void declareVar(string line)
        {
            variables.Add(new StoredVar(_varType, _varName, _varValue));
        }


    }
}
