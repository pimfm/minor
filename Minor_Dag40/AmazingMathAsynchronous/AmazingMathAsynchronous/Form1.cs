using InfoSupport.Threading.MathLib;
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

namespace AmazingMathAsynchronous
{
    public partial class Form1 : Form
    {
        private object lockObject = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SlowMath math = new SlowMath();
            SetOutput(0);

            math.BeginSquare((int)intInput1.Value, AddSquareToTextBox, math);
            math.BeginSquare((int)intInput2.Value, AddSquareToTextBox, math);
            math.BeginSquare((int)intInput3.Value, AddSquareToTextBox, math);
        }

        private void AddSquareToTextBox(IAsyncResult result)
        {

            SlowMath math = (SlowMath) result.AsyncState;

            lock (lockObject) {
                int output = int.Parse(txtOutput.Text);
                output += math.EndSquare(result);

                SetOutput(output);
            }
        }

        private void SetOutput(int value)
        {
            Invoke((MethodInvoker)(() => txtOutput.Text = value.ToString()));
        }
    }
}
