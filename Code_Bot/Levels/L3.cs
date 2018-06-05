using System;
using Code_Bot.Props;
using Code_Bot.Instructions;

namespace Code_Bot.Levels
{
    public partial class L3 : ParentLevel
    {
        public L3()
        {
            InitializeComponent();
        }
        override protected void CallOnLoad()
        {
            bot.SetPosition(6, 15, "up");
            WallBuild.Vertical(5, 4, 12, Walls, this);
            WallBuild.Vertical(7, 6, 10, Walls, this);
            WallBuild.Horizontal(8, 6, 10, Walls, this);
            WallBuild.Horizontal(6, 4, 12, Walls, this);
            Walls.Add(new Wall(18, 5, this));
            Exits.Add(new Exit(17, 5, this, new L4()));
        }

        private void L3_Load(object sender, EventArgs e)
        {
            CallOnLoad();
            Show();
            showInstructions(new I3());
            _hint = "The method you need to turn right is 'bot.Turn(\"right\")'";
        }
    }
}
