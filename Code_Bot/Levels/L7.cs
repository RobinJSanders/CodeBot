using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L7 : ParentLevel
    {
        public L7()
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
            Exits.Add(new Exit(4, 6, this, new L8()));
        }

        private void L7_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I7());
            _hint = "Inside the loop: move(11), Turn right, move(2), Turn right, move(11), Turn left, move(2), Turn left.";
        }
    }
}
