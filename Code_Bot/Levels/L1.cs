using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L1 : ParentLevel
    {
        public L1()
        {
            InitializeComponent();
        }

        override protected void CallOnLoad()
        {
            bot.SetPosition(11, 11, "up");
            WallBuild.Vertical(10, 10, 2, Walls, this);
            WallBuild.Vertical(12, 10, 2, Walls, this);
            Exits.Add(new Exit(11, 9, this, new L2()));
        }

        private void Level1_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I1());
            _hint = "You need to move the bot 2 spaces to get to the exit, try calling the bot's 'Move' method twice.";
        }
    }
}
