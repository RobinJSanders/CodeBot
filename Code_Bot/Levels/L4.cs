using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L4 : ParentLevel
    {
        public L4()
        {
            InitializeComponent();
        }
        override protected void CallOnLoad()
        {
            bot.SetPosition(5, 5, "up");

            WallBuild.Vertical(4, 5, 8, Walls, this);
            WallBuild.Vertical(6, 5, 6, Walls, this);
            WallBuild.Horizontal(5, 12, 4, Walls, this);
            WallBuild.Vertical(8, 5, 7, Walls, this);
            WallBuild.Horizontal(6, 4, 3, Walls, this);

            Exits.Add(new Exit(7, 5, this, new L5()));
        }

        private void L4_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I4());
            _hint = "To do a full 180, simply turn in either direction twice.";
        }
    }
}
