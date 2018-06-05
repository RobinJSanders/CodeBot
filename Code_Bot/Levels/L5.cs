using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L5 : ParentLevel
    {
        public L5()
        {
            InitializeComponent();
        }
        override protected void CallOnLoad()
        {
            bot.SetPosition(19, 19, "up");

            int x = 16;
            int y = 17;
            for(int i = 0; i < 5; i++)
            {
                WallBuild.Horizontal(x, y, 3, Walls, this);
                WallBuild.Horizontal(x+1, y-2, 3, Walls, this);
                x -= 3;
                y -= 3;
            }
            x = 15;
            y = 15;
            for (int i = 0; i < 5; i++)
            {
                WallBuild.Vertical(x, y, 3, Walls, this);
                WallBuild.Vertical(x+5, y, 3, Walls, this);
                x -= 3;
                y -= 3;
            }
            WallBuild.Vertical(18, 18, 3, Walls, this);
            WallBuild.Vertical(20, 18, 3, Walls, this);
            WallBuild.Vertical(3, 1, 2, Walls, this);
            WallBuild.Vertical(5, 1, 2, Walls, this);

            Exits.Add(new Exit(4, 4, this, new L6()));
        }

        private void L5_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I5());
            _hint = "You will need to loop 5 times to get to the exit";
        }
    }
}
