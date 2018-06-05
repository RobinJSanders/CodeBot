using System;
using Code_Bot.Props;
using Code_Bot.Instructions;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Code_Bot.Levels
{
    public partial class L8 : Code_Bot.Levels.ParentLevel
    {
        public L8()
        {
            InitializeComponent();
        }

        protected override void CallOnLoad()
        {
            bot.SetPosition(7, 15, "up");

            WallBuild.Vertical(6, 7, 10, Walls, this);
            WallBuild.Vertical(8, 8, 9, Walls, this);
            WallBuild.Horizontal(6, 6, 8, Walls, this);
            WallBuild.Horizontal(9, 8, 7, Walls, this);
            WallBuild.Vertical(13, 3, 3, Walls, this);
            WallBuild.Vertical(15, 3, 5, Walls, this);
            Walls.Add(new Wall(14, 3, this));
            Walls.Add(new Wall(7, 16, this));

            Exits.Add(new Exit(14, 4, this, new L9()));
        }

        private void L8_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I8());
            _hint = "You need 2 string varibles with the values of \"left\" and  \"right\". You also need 3 int variables as parameters for bot.Move();";
        }

        protected override void btnGo_Click(object sender, EventArgs e)
        {//the user may only use declared variables as parameters on this level
            Regex turn = new Regex(@"\s*bot\s*\.\s*Turn\s*\(\s*.+\"" +\s *\)\s *\;\s * ");
            Regex move = new Regex(@"\s*bot\s*\.\s*Move\s*\(\s*[0-9]*\s*\)\s*\;\s*");


            if (move.IsMatch(rtfInput.Text) || turn.IsMatch(rtfInput.Text))
            {
                MessageBox.Show("You may only use variables as parameters on this level!\n",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
            else
                go();
        }

    }
}
