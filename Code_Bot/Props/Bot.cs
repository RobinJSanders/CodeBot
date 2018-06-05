using System;
using System.Drawing;
using System.Windows.Forms;
using Code_Bot.Logic;
using Code_Bot.Properties;


namespace Code_Bot.Props
{
    public class Bot
    {
        public string Facing { get; private set; }
        //position of bot relative to grid:
        public int GridPositionX { get; private set; }
        public int GridPositionY { get; private set; }
        public string GridCoordinance { get; private set; }
        public bool Crashed { get; private set; }
        //position of bot in pixels relative to form:
        int _formPositionX;
        int _formPositionY;
        PictureBox pbxBot;
        Levels.ParentLevel parentForm;
        Bitmap _botFacingUp = Resources.BotUp;
        Bitmap _botFacingDown = Resources.BotDown;
        Bitmap _botFacingLeft = Resources.BotLeft;
        Bitmap _botFacingRight = Resources.BotRight;
        Bitmap _blackSquare = Resources.BlackSquare;

        public Bot(Levels.ParentLevel form)
        {
            pbxBot = new System.Windows.Forms.PictureBox();
            parentForm = form;
            pbxBot.Visible = true;
            pbxBot.Name = "pbxBot";
            pbxBot.Size = new System.Drawing.Size(30, 30);
        }

        public void SetPosition(int x, int y, string direction)
        {
            Crashed = false;
            _formPositionX = PositionConvert.GridToFormX(x);
            _formPositionY = PositionConvert.GridToFormY(y);
            Facing = direction;
            UpdatePosition();
            parentForm.Controls.Add(pbxBot);
            pbxBot.BringToFront();
        }

        public void UpdatePosition()
        {
            pbxBot.Image = setImage();
            pbxBot.Location = new System.Drawing.Point(_formPositionX, _formPositionY);
            pbxBot.BringToFront();
            GridPositionX = PositionConvert.FormToGridX(_formPositionX);
            GridPositionY = PositionConvert.FormToGridY(_formPositionY);
            GridCoordinance = Convert.ToString(GridPositionX) + Convert.ToString(GridPositionY);
            parentForm.DisplayBotLocation();
        }

        private Bitmap setImage()
        {
            switch (Facing)
            {
                case "up":
                    return _botFacingUp;
                case "down":
                    return _botFacingDown;
                case "left":
                    return _botFacingLeft;
                case "right":
                    return _botFacingRight;
                default:
                    return _blackSquare;
            }
        }

        private void wait(int ms)
        {//call this method to add a delay in bot's movement
            parentForm.Invalidate();
            parentForm.Refresh();
            System.Threading.Thread.Sleep(ms);
        }

        public void Crash()
        {
            if (!Crashed)
            {
                Crashed = true;
                pbxBot.Image = _blackSquare;
                MessageBox.Show("Whoops you have crashed, reset and try again",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        public void Move(int distance)
        {//move in the direction the bot is Facing
            for (int i = 0; i < distance; i++)
            {
                checkForEdge();
                if (Crashed)
                    break;
                for (int j = 0; j < 10; j++)
                {
                    switch (Facing)
                    {
                        case "up":
                            _formPositionY -= 3;
                            break;
                        case "down":
                            _formPositionY += 3;
                            break;
                        case "left":
                            _formPositionX -= 3;
                            break;
                        case "right":
                            _formPositionX += 3;
                            break;
                    }
                    wait(1);
                    UpdatePosition();
                }
                checkForWall();
                wait(100);
            }

        }

        private void checkForEdge()
        {
            if (GridPositionY == 1 && Facing == "up" || GridPositionY == 20 && Facing == "down" || GridPositionX == 1 && Facing == "left" || GridPositionX == 20 && Facing == "right")
                Crash();
        }

        private void checkForWall()
        {
            foreach (Wall element in parentForm.Walls)
            {
                if (GridCoordinance == Convert.ToString(element.GridPositionX) + Convert.ToString(element.GridPositionY))
                {
                    Crash();
                }
            }
        }

        public void CheckForExit()
        {
            if (!Crashed)
                foreach (Exit element in parentForm.Exits)
                {
                    if (GridCoordinance == Convert.ToString(element.GridPositionX) + Convert.ToString(element.GridPositionY))
                    {//go to next level
                        MessageBox.Show("Level Complete.",
                        "Well Done!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button1);
                        element.ThisLevel.Hide();
                        element.NextLevel.Show();
                    }
                    else
                    {
                        MessageBox.Show("The bot has not reached the exit.\nPlease reset and try again",
                        "Level Incomplete.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                    }
                    break;
                }
        }



        public void Turn(string direction)
        {//the bot can turn left or right relative to the direction it is Facing 
         //e.g. the bot is Facing left so turning right will make it face up
            switch (Facing)
            {
                case "up":
                    switch (direction)
                    {
                        case "left":
                            Facing = "left";
                            break;
                        case "right":
                            Facing = "right";
                            break;
                    }
                    break;
                case "left":
                    switch (direction)
                    {
                        case "left":
                            Facing = "down";
                            break;
                        case "right":
                            Facing = "up";
                            break;
                    }
                    break;
                case "down":
                    switch (direction)
                    {
                        case "left":
                            Facing = "right";
                            break;
                        case "right":
                            Facing = "left";
                            break;
                    }
                    break;
                case "right":
                    switch (direction)
                    {
                        case "left":
                            Facing = "up";
                            break;
                        case "right":
                            Facing = "down";
                            break;
                    }
                    break;
            }
            UpdatePosition();
            wait(200);//short delay between turns
        }
    }
}
