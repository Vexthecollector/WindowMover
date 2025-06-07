using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowMover.WindowHandler;

namespace WindowMover
{
    public partial class StandardView : Form
    {
        WindowHandler.RECT rect = new WindowHandler.RECT();
        float ScalingFactor = 1.0f;
        int offsetTop = 0;
        int offsetLeft = 0;

        public StandardView()
        {
            InitializeComponent();
            GenerateVariables();
            //LoadScreens();
            LoadWindows();
        }

        private void GenerateVariables()
        {
            WindowHandler.RECT rect = new WindowHandler.RECT();

            rect.Top = (Screen.AllScreens.Min(x => x.Bounds.Top));
            rect.Bottom = (Screen.AllScreens.Max(x => x.Bounds.Bottom));
            rect.Left = (Screen.AllScreens.Min(x => x.Bounds.Left));
            rect.Right = (Screen.AllScreens.Max(x => x.Bounds.Right));

            int ScreenWidth = Math.Abs(rect.Left - rect.Right);
            int ScreenHeight = Math.Abs(rect.Top - rect.Bottom);

            float ScalingFactorWidth = (float)ScreenWidth / (float)this.Bounds.Width;
            float ScalingFactorHeigth = (float)ScreenHeight / (float)this.Bounds.Height;

            ScalingFactor = Math.Max(ScalingFactorHeigth, ScalingFactorWidth);

            offsetTop = (int)-(rect.Top / ScalingFactor);
            offsetLeft = (int)-(rect.Left / ScalingFactor);
        }

        private void LoadScreens()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                Panel panel = new Panel();
                panel.Bounds = screen.Bounds;
                panel.Width = (int)(panel.Width / ScalingFactor);
                panel.Height = (int)(panel.Height / ScalingFactor);
                panel.Top = (int)(screen.Bounds.Top / ScalingFactor) + offsetTop;
                panel.Left = (int)(screen.Bounds.Left / ScalingFactor) + offsetLeft;
                panel.BackColor = Color.LightBlue;
                this.Controls.Add(panel);
                panel.Show();

            }
        }


        private void LoadWindows()
        {
            foreach (WindowHandler.WindowData data in WindowHandler.Instance.windows)
            {
                WindowHandler.RECT wRect = WindowHandler.Instance.GetWindowRectangle(data.HandleRef);
                PictureBox pictureBox = new PictureBox();
                //Panel panel = new Panel();
                pictureBox.Width = (int)(wRect.Width() / ScalingFactor);
                pictureBox.Height = (int)(wRect.Height() / ScalingFactor);
                pictureBox.Top = (int)(wRect.Top / ScalingFactor) + offsetTop;
                pictureBox.Left = (int)(wRect.Left / ScalingFactor) + offsetLeft;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                Bitmap memoryImage = new Bitmap(wRect.Width(), wRect.Height(), PixelFormat.Format32bppArgb);
                Size s = new Size(wRect.Width(), wRect.Height());
                Graphics memoryGraphics = Graphics.FromImage(memoryImage);
                memoryGraphics.CopyFromScreen(wRect.Left, wRect.Top, 0, 0, s);
                pictureBox.Image = memoryImage;
                this.Controls.Add(pictureBox);
                pictureBox.Show();



            }

        }

      


    }
    
}
