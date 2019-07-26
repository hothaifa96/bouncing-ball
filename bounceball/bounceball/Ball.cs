using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bounceball
{
   class Ball
    {
        # region DATA
        const int _Size = 50;// the size of the bll that the class creat
        const string _PicPath = "C:/Users/hothaifa/source/repos/bounceball/bounceball/picres/crazyball.jpg";
        private Random _rnd = new Random();
        private int _StartingX;// the ball X coordenation location 
        private int _StartingY;// "     "  Y        "         "         
        public int stepX = 1;// the step in the horizontal axis
        public int stepY = 1;// the step in the vertical axis
        public int previousStepX;
        public int previousStepY;
        public PictureBox ball;
        #endregion
        public void UpdateSteps(int width,int height)
        {
            if (ball.Location.X+ previousStepX <= 0 || ball.Location.X + _Size + previousStepX >= width)//to change the moving direction when the X coordination of the pic hit the boarder 
            {
                this.stepX = -this.stepX;
            }// if the ball locatin and the window boarder collision  the value of the ball will change the direction 
            if (ball.Location.Y + previousStepY <= 0 || ball.Location.Y + _Size + previousStepY >= height)//to change the moving direction when the X coordination of the pic hit the boarder 
            {
                this.stepY =-this.stepY;
            }

        }
        public Ball()
        {

        }
        public Ball(PictureBox ball)
        {
            this.ball = ball;
        }
        public PictureBox CreatOne(int maxwindowwidth, int maxwindowheight)
        {
            _StartingX = _rnd.Next(maxwindowwidth-_Size);
            _StartingY = _rnd.Next(maxwindowheight-_Size);
            ball = new PictureBox
            {            
                Name = "ball",
                Size = new Size(_Size, _Size),
                Location = new Point(_StartingX, _StartingY),
                Image = Image.FromFile(_PicPath),
            };
            ball.SizeMode = PictureBoxSizeMode.StretchImage;
            
            return ball;
        
        }
    }
}
