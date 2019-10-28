using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
/**
 * Large part thanks to https://stackoverflow.com/questions/2416748/how-do-you-simulate-mouse-click-in-c
 */
namespace AnnoyingButton
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Useless App";

    }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Thing done";
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(this.Left+350,this.Top+180);
            DoMouseClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Thing undone";
        }
        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(this.Left + this.Width-20, this.Top + 15);
        }
    }
}
