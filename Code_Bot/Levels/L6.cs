using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L6 : Code_Bot.Levels.ParentLevel
    {
        public L6()
        {
            InitializeComponent();
        }

        protected override void CallOnLoad()
        {
            bot.SetPosition(15, 16, "left");
            WallBuild.Horizontal(5, 15, 11, Walls, this);
            WallBuild.Horizontal(4, 13, 11, Walls, this);
            WallBuild.Horizontal(5, 11, 11, Walls, this);
            WallBuild.Horizontal(4, 9, 11, Walls, this);
            WallBuild.Horizontal(5, 7, 11, Walls, this);
            WallBuild.Vertical(3, 6, 10, Walls, this);
            WallBuild.Vertical(16, 6, 10, Walls, this);
            WallBuild.Horizontal(1, 15, 2, Walls, this);
            WallBuild.Horizontal(17, 15, 4, Walls, this);
            Exits.Add(new Exit(4, 6, this, new L7()));            
        }

        private void L6_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I6());
            _hint = "Inside the loop: move, Turn right, move, Turn right, move, Turn left, move, Turn left,";
        }
    }
}
