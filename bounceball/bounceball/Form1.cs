using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bounceball
{
    public partial class ballfield : Form
    {
        #region Data
        ballpic ballclass = new ballpic();
        private int stepx = 1;
        private int stepy =1;
        public List<PictureBox> ballList = new List<PictureBox>();
        #endregion

        private void MoveBall(PictureBox ball )
        {
            #region X_movement
            Action a = () => { ball.Location = new Point(ball.Location.X + stepx, ball.Location.Y); };// mooving the pic by chanching the location in the action 
                this.BeginInvoke(a);
                if (ball.Location.X <= 0 || ball.Location.X + ball.Width > this.ClientSize.Width)//to change the moving direction when the X coordination of the pic hit the boarder 
                stepx = -stepx;
            #endregion
            #region Y_MOVEMENT
            Action a2 = () => { ball.Location = new Point(ball.Location.X, ball.Location.Y + stepy); };// to change the moving direction when the coordinayhion of th pic hits the boarder };
                this.BeginInvoke(a2);
                if ((ball.Location.Y <= 0 || ball.Location.Y + ball.Height > this.ClientSize.Height)) 
                {
                    stepy = -stepy;
                }
            #endregion
        }
        public ballfield()
        {
            InitializeComponent();
        }  
        private  void Form1_Load(object sender, EventArgs e)
        {
            BackColor = Color.White;

            
        }

        private async void moveTask()
        {
            while (true)
            {
                foreach (var ballpic in ballList)
                {
                    Task.Factory.StartNew(() => { MoveBall(ballpic); });
                    ballpic.DoubleClick += new EventHandler((o, a) => { ballList.Remove(ballpic); });
                }
                await Task.Delay(10);
            }
        }

        private void NewBall_click(object sender, MouseEventArgs e)
        {
            PictureBox b= ballclass.CreatOne(this.ClientSize.Width, this.ClientSize.Height);
            this.Controls.Add(b);
            ballList.Add(b);
            b.Click += new EventHandler((o, a) => { moveTask(); });//when the pic clicked it will start mooving 
        }
        
    }
}
