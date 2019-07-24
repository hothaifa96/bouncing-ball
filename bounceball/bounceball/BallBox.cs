using System.Windows.Forms;

namespace bounceball
{
    public class BallBox
    {
        public PictureBox PicBox { get; set; }
        public int XStep { get; set; }
        public int YStep { get; set; }

        public BallBox(PictureBox picBox, int xStep, int yStep)
        {
            PicBox = picBox;
            XStep = xStep;
            YStep = yStep;
        }
    }
}