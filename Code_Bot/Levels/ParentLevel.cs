using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Code_Bot.Logic;
using Code_Bot.Props;


namespace Code_Bot.Levels
{
    public partial class ParentLevel : Form
    {
        public static int BoardX { get; private set; }
        public static int BoardY { get; private set; }
        protected Bot bot;
        protected Form instructions;
        protected string _hint = "No hint for this level";
        public List<Wall> Walls = new List<Wall>();
        public List<Exit> Exits = new List<Exit>();
        Regex _regexMethod = new Regex(@"^[a-z]+\.[a-zA-z]+\([^()]*\)\;$");
        ErrorChecker errorChecker;
        Interpreter interpreter;
        private int _attemptNo;
        private bool _showLineNo;

        public ParentLevel()
        {
            InitializeComponent();
        }
        //methods below
        virtual protected void CallOnLoad()
        {// called when the form is loaded or reset button is pressed
         //bot.SetPosition is set in the child form
            RtfOutput.Clear();
            RtfOutputLineNumbers.Clear();
            DisplayBotLocation();
            Walls.Clear();
            displayAsLog();
            _showLineNo = false;
        }

        public void DisplayBotLocation()
        {//finds the possition direction of bot and returns its output reletive to possition on the grid
            lblX.Text = "X: " + Convert.ToString(bot.GridPositionX);
            lblY.Text = "Y: " + Convert.ToString(bot.GridPositionY);
            lblFacing.Text = "Facing: " + bot.Facing;
        }

        private void displayAsError()
        {
            lblOutput.Text = "Errors: ";
            toolTip1.SetToolTip(RtfOutputLineNumbers, "The line in input text that the error is on");
            toolTip1.SetToolTip(RtfOutput, "Details for each error");
        }

        private void displayAsLog()
        {
            lblOutput.Text = "Log:";
            toolTip1.SetToolTip(RtfOutputLineNumbers, "Line numbers for output textbox");
            toolTip1.SetToolTip(RtfOutput, "Current instructions being processed");
        }

        protected void showInstructions(Form ins)
        {
            instructions = ins;
            instructions.ShowDialog();
        }

        protected void go()
        {//when btnGo is button is clicked
            RtfOutput.Clear();
            RtfOutputLineNumbers.Clear();
            if (btnGo.Text == "Go!")
            {
                errorChecker = new Logic.ErrorChecker(rtfInput.Text, bot, this);
                if (!errorChecker.HasError)
                {
                    _showLineNo = true;
                    btnGo.Text = "Reset";
                    displayAsLog();
                    interpreter = new Logic.Interpreter(rtfInput.Text, bot, this);
                    bot.CheckForExit();
                    _attemptNo++;
                    if (_attemptNo > 2)
                        lblHint.Visible = true;
                }
                else
                {
                    _showLineNo = false;
                    displayAsError();
                }
            }
            else
            {
                btnGo.Text = "Go!";
                CallOnLoad();
            }
        }

        //****************************************************************************************************************
        //event handlers below

        private void ParentForm_Load(object sender, EventArgs e)
        {
            BoardX = pbxBoard.Location.X;
            BoardY = pbxBoard.Location.Y;
            bot = new Props.Bot(this);
            _attemptNo = 0;
            CallOnLoad();
        }

        virtual protected void btnGo_Click(object sender, EventArgs e)
        {
            go();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog object.
            OpenFileDialog openFile1 = new OpenFileDialog();

            // Initialize the filter to look for text files.
            openFile1.Filter = "Text Files|*.txt";

            // If the user selected a file, load its contents into the RichTextBox. 
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                rtfInput.LoadFile(openFile1.FileName,
                RichTextBoxStreamType.PlainText);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtfInput.Clear();
            rtfInputLineNumbers.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            CallOnLoad();
        }

        private void rtfInput_TextChanged(object sender, EventArgs e)
        {
            rtfInputLineNumbers.Clear();
            for (int i = 1; i < rtfInput.Lines.Length + 1; i++)
            {
                rtfInputLineNumbers.Text += i + "\n";
            }
        }

        private void chkTooltips_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTooltips.Checked)
                toolTip1.Active = false;
            else
                toolTip1.Active = true;
        }


        private void btnShowInstructions_Click(object sender, EventArgs e)
        {
            instructions.ShowDialog();
        }

        //sync scrollbars with textboxes and line numbers. Coppied from: https://stackoverflow.com/questions/10266625/same-scroll-bar-for-two-richtextboxes
        public enum ScrollBarType : uint
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }
        public enum Message : uint
        {
            WM_VSCROLL = 0x0115
        }
        public enum ScrollBarCommands : uint
        {
            SB_THUMBPOSITION = 4
        }
        [DllImport("User32.dll")]
        public extern static int GetScrollPos(IntPtr hWnd, int nBar);

        [DllImport("User32.dll")]
        public extern static int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        private void RtfInput_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(rtfInput.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(rtfInputLineNumbers.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }
        private void RtfOutput_VScroll(object sender, EventArgs e)
        {
            int nPos = GetScrollPos(RtfOutput.Handle, (int)ScrollBarType.SbVert);
            nPos <<= 16;
            uint wParam = (uint)ScrollBarCommands.SB_THUMBPOSITION | (uint)nPos;
            SendMessage(RtfOutputLineNumbers.Handle, (int)Message.WM_VSCROLL, new IntPtr(wParam), new IntPtr(0));
        }

        private void lblHint_Click(object sender, EventArgs e)
        {
            lblHint.Text = _hint;
        }

    }
}
