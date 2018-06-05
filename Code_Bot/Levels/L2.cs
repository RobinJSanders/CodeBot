using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L2 : Code_Bot.Levels.ParentLevel
    {
        public L2()
        {
            InitializeComponent();
        }
        override protected void CallOnLoad()
        {
            bot.SetPosition(11, 15, "up");
            WallBuild.Vertical(10, 4,12, Walls, this);
            WallBuild.Vertical(12, 4,12, Walls, this);
            Exits.Add(new Exit(11, 4, this, new L3()));
        }

        private void Level2_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I2());
            _hint = "Look at the Y-coordinates on the left hand side of the grid. The exit lines up with 4 and the bot lines up with 15. 15 - 4 = 11 so you need to move the bot 11 spaces.";
        }
    }
}
