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
        Ball ballclass1 = new Ball();
        List<Ball> ballList = new List<Ball>();
        #endregion

        private void MoveBall(Ball ball)
        {
            #region X_movement
            Action a = () => { ball.ball.Location = new Point(ball.ball.Location.X + ball.stepX, ball.ball.Location.Y); };// mooving the pic by chanching the location in the action 
            this.BeginInvoke(a);
            #region updating the previouse steps
            ball.previousStepX = ball.stepX;
            ball.previousStepY = ball.stepY;
            #endregion
            #endregion
            #region Y_movement
            Action a2 = () => { ball.ball.Location = new Point(ball.ball.Location.X, ball.ball.Location.Y + ball.stepY); };// to change the moving direction when the coordinayhion of th pic hits the boarder };
            this.BeginInvoke(a2);
            #endregion
            #region UPDATESTEP
            ball.UpdateSteps(this.ClientSize.Width, this.ClientSize.Height);// the fun checks if the ball hits the window border and change the vlue of the steps if its true
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

        private async void MoveTask()
        {
            while (true)
            {

                foreach (var tt in ballList)
                {
                    Task.Factory.StartNew(() => { MoveBall(tt); }) ;
                    
                }
                await Task.Delay(10);
            }
        }

        private void NewBall_click(object sender, MouseEventArgs e)
        {
            PictureBox b= ballclass1.CreatOne(this.ClientSize.Width, this.ClientSize.Height);
            this.Controls.Add(b);
            Ball ba = new Ball(b);
            ballList.Add(ba);            
            b.Click += new EventHandler((o, a) => { MoveTask(); });//when the pic clicked it will start mooving 
        }
        
    }
}
