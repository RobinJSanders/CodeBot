using System;
using System.Windows.Forms;
using Code_Bot.Logic;
using Code_Bot.Props;
using Code_Bot.Instructions;


namespace Code_Bot.Levels
{
    public partial class Demo : Code_Bot.Levels.ParentLevel
    {
        public Demo()
        {
            InitializeComponent();
            
        }

        override protected void CallOnLoad()
        {     
            base.CallOnLoad();
            bot.SetPosition(10, 8, "up");
            
            //Walls.Add(new Props.Wall(10, 7, this));
           

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            rtfInput.Text += "bot.Move();\n";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            rtfInput.Text += "bot.Turn(\"left\");\n";
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            rtfInput.Text += "bot.Turn(\"right\");\n";
        }

        private void btnLoop_Click(object sender, EventArgs e)
        {
            rtfInput.Text += "loop()\n{\n\n}\n";
        }



        private void Demo_Load(object sender, EventArgs e)
        {
            CallOnLoad();
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

    }
}
