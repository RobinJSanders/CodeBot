using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L10 : Code_Bot.Levels.ParentLevel
    {
        public L10()
        {
            InitializeComponent();
        }

        protected override void CallOnLoad()
        {
            bot.SetPosition(13, 17, "left");

            int x = 7;
            int y = 6;
            int l = 9;
            for (int i = 0; i<3;i++)
            {
                WallBuild.Horizontal(x, y, l, Walls, this);
                x += 2;
                y += 2;
                l -= 1;
                WallBuild.Horizontal(x, y, l, Walls, this);
                x -= 1;
                y += 2;
                l -= 1;
            }
            x = 17;
            y = 5;
            l = 4;
            for (int i = 0; i < 3; i++)
            {
                WallBuild.Vertical(x, y, l, Walls, this);
                x -= 1;
                y += 4;
            }
            x = 7;
            y = 7;
            for (int i = 0; i < 3; i++)
            {
                WallBuild.Vertical(x, y, l, Walls, this);
                x += 1;
                y += 4;
            }
            WallBuild.Horizontal(15, 4, 3, Walls, this);
            WallBuild.Horizontal(9, 18, 6, Walls, this);
            Walls.Add(new Wall(15, 5, this));
            Walls.Add(new Wall(14, 17, this));
   
            Exits.Add(new Exit(16, 5, this, new Debreifing()));
        }



        private void L10_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I10());
            //_hint = "Inside the loop: move(11), Turn right, move(2), Turn right, move(11), Turn left, move(2), Turn left.";
        }
    }
}
