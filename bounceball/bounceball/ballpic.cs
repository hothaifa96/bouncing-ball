using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bounceball
{
   class ballpic
    {
        const int _Size = 50;
        const string _PicPath = "C:/Users/hothaifa/source/repos/bounceball/bounceball/picres/crazyball.jpg";
        private Random _rnd = new Random();
        private int _StartingX;
        private int _StartingY;
        private int stepX = 1;
        private int stepY = 1;
        public ballpic()
        {

        }
        public PictureBox CreatOne(int maxwindowwidth, int maxwindowheight)
        {
            _StartingX = _rnd.Next(maxwindowwidth-_Size);
            _StartingY = _rnd.Next(maxwindowheight-_Size);
            PictureBox ball = new PictureBox
            {            
                Name = "ball",
                Size = new Size(_Size, _Size),
                Location = new Point(_StartingX, _StartingY),
                Image = Image.FromFile(_PicPath),
            };
            ball.SizeMode = PictureBoxSizeMode.StretchImage;
            
            return ball;
        
        }
        public BallBox GetBallBox(PictureBox ball)
        {
           return new BallBox(ball, stepX, stepY);

        }


    }
}
