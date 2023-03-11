using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backprop;
using ExcelDataReader;

namespace BackPropagation
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        private static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private string filePath = projectDirectory + @"\\diabetes.xlsx";

        public Form1()
        {
            InitializeComponent();
            nn = new NeuralNet(6, 100, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.run();
            textBox3.Text = "" + nn.getOuputData(0);
        }

        private void trainBtn_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        int MAX_COLUMN = reader.FieldCount;
                        int MAX_EPOCHS = Convert.ToInt32(textBox7.Text);
                        for (int epoch = 0; epoch < MAX_EPOCHS; epoch++)
                        {
                            reader.Reset();
                            int ROW_CTR = 0;
                            do
                            {
                                while (reader.Read())
                                {
                                    for (int column = 0; column < MAX_COLUMN; column++)
                                    {
                                        if (column == MAX_COLUMN - 1)
                                        {
                                            nn.setDesiredOutput(0, reader.GetDouble(column));
                                            nn.learn();
                                        }
                                        else
                                        {
                                            nn.setInputs(column, reader.GetDouble(column));
                                        }

                                    }
                                    if (ROW_CTR == 100)
                                    {
                                        testBtn.Enabled = true;
                                        testBtn.BackColor = SystemColors.Highlight;
                                        break;
                                    }
                                    ROW_CTR++;
                                }
                                
                            } while (reader.NextResult());       
                        }

                    }
                }

                testBtn.Enabled = true;
                testBtn.BackColor = SystemColors.Highlight;
            }
            else
            {
                outputLbl.Text = "Enter epoch" + Environment.NewLine + "number";
            }
        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&
                textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                nn.setInputs(0, Convert.ToDouble(textBox1.Text));
                nn.setInputs(1, Convert.ToDouble(textBox2.Text));
                nn.setInputs(2, Convert.ToDouble(textBox3.Text));
                nn.setInputs(3, Convert.ToDouble(textBox4.Text));
                nn.setInputs(4, Convert.ToDouble(textBox5.Text));
                nn.setInputs(5, Convert.ToDouble(textBox6.Text));
                nn.run();
                outputLbl.Text = "" + nn.getOuputData(0);
            }
            else
            {
                outputLbl.Text = "Input all text" + Environment.NewLine +  "fields";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            outputLbl.Text = "";
        }
    }
}
