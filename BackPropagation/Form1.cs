using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;

namespace BackPropagation
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        public Form1()
        {
            InitializeComponent();
            //2 input
            //3 hidden
            //1 output
            nn = new NeuralNet(6, 10, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.run();
            textBox3.Text = "" + nn.getOuputData(0);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Convert.ToInt32(textBox7.Text); i++)
            {
                //pos is neuron number at 0
                //data should be from textBox1 as an input and is set as 1 for sample
                //AND operations
                nn.setInputs(0, 6.0);
                nn.setInputs(1, 148.0);
                nn.setInputs(2, 72.0);
                nn.setInputs(3, 33.6);
                nn.setInputs(4, 0.627);
                nn.setInputs(5, 50.0);
                nn.setDesiredOutput(0, 1.0);
                nn.learn();

                nn.setInputs(0, 1.0);
                nn.setInputs(1, 85.0);
                nn.setInputs(2, 66.0);
                nn.setInputs(3, 26.6);
                nn.setInputs(4, 0.351);
                nn.setInputs(5, 31.0);
                nn.setDesiredOutput(0, 0.0);
                nn.learn();

                nn.setInputs(0, 8.0);
                nn.setInputs(1, 183.0);
                nn.setInputs(2, 64.0);
                nn.setInputs(3, 23.3);
                nn.setInputs(4, 0.672);
                nn.setInputs(5, 32.0);
                nn.setDesiredOutput(0, 1.0);
                nn.learn();

                nn.setInputs(0, 1.0);
                nn.setInputs(1, 89.0);
                nn.setInputs(2, 66.0);
                nn.setInputs(3, 28.1);
                nn.setInputs(4, 0.167);
                nn.setInputs(5, 21.0);
                nn.setDesiredOutput(0, 0.0);
                nn.learn();

                nn.setInputs(0, 0.0);
                nn.setInputs(1, 137.0);
                nn.setInputs(2, 40.0);
                nn.setInputs(3, 43.1);
                nn.setInputs(4, 2.288);
                nn.setInputs(5, 33.0);
                nn.setDesiredOutput(0, 1.0);
                nn.learn();
            }
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox3.Text));
            nn.setInputs(3, Convert.ToDouble(textBox4.Text));
            nn.setInputs(4, Convert.ToDouble(textBox5.Text));
            nn.setInputs(5, Convert.ToDouble(textBox6.Text));
            nn.run();
            label5.Text = "" + nn.getOuputData(0);
        }
    }
}
