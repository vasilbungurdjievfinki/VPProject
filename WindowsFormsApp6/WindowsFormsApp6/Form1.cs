using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public int counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeNumbers();
            label5.Text = "1";
            progressBar2.Value = 500;
            counter = 0;
            timer1.Start();
            
            
        }

        private void ChangeNumbers()
        {
            Random r = new Random();
            int a, b;
            char d;
        
            int c = r.Next(0,3);
            if(c==0 || c==1)
            {
                if (c == 0)
                {
                    a = r.Next(0, 300);
                    b = r.Next(0, 300);
                }
                else
                {
                    a = r.Next(0, 100);
                    b = r.Next(0, 100);

                }
                if (c==0)
                {
                    d = '+';
                }
                else 
                {
                    d = '-';
                }

            }
            else
            {
               a = r.Next(0, 20);
               b = r.Next(0, 20);
                d = '*';
            }

            
            label1.Text = a.ToString();
            label3.Text = b.ToString();
            label2.Text = d.ToString();
        }

        private int getAnswer()
        {
            int a = int.Parse(label1.Text);
            int b = int.Parse(label3.Text);
            int answer;
            if (label2.Text == "+")
            {
                answer = a + b;
            }
            else if (label2.Text == "-")
            {
                answer = a - b;
            }
            else { answer = a * b; }
            return answer;

        }

        private bool CheckAnswer(int m)
        {
            int a = int.Parse(label1.Text);
            int b = int.Parse(label3.Text);
            int answer;
            if(label2.Text=="+")
            {
                answer = a + b;
            }
            else if(label2.Text=="-")
            {
                answer = a - b;
            }
            else { answer = a*b; }
            

            return (answer == m);  
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool er = int.TryParse(textBox1.Text, out int a);
            if(!er)
            {
                errorProvider1.SetError(textBox1, "Vnesovte nesto sto ne e broj!");
                return;
            }
            bool b = CheckAnswer(int.Parse(textBox1.Text));
            if (b)
            {
                errorProvider1.SetError(textBox1, null);
                int c = int.Parse(label5.Text);
                c++;
                if(c==16)
                {
                    GameOver(int.Parse(label4.Text), 3);
                    return;
                }
                label5.Text=c.ToString();
                progressBar1.Value = c * 10;
                progressBar2.Value = 500;
                textBox1.Text = "";
                
            }
            else
            {
                GameOver(getAnswer(), 1);
            }
            ChangeNumbers();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            if(counter%4==0)
            {
                label4.Text=(counter/4).ToString();
            }
            int a = int.Parse(label5.Text)+1;
            int c= progressBar2.Value - a;
            if(c<=0)
            {
                GameOver(getAnswer(), 2);
                return;
            }
            else progressBar2.Value = c;
        }
        private void GameOver(int a,int b)
        {
            if (b==1)
            {
                timer1.Stop();
                string cc = a.ToString();
                string message =
              "Odgovorivte pogresno! Tocniot odgovor bese vsusnost " + cc + ". Dali sakate nova igra?";
                 string caption = "Greska odgovor";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

             
                if (result == DialogResult.Yes)
                {
                    ChangeNumbers();
                        timer1.Start();
                    label5.Text = "1";
                    progressBar2.Value = 500;
                    progressBar1.Value = 0;
                    label4.Text = "0";
                    counter = 0;
                    textBox1.Text = "";
                    
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            if (b == 2)
            {
                timer1.Stop();
                string cc = a.ToString();
                string message =
              "Vi istece vremeto. Tocniot odgovor bese vsusnost " + cc + ". Dali sakate nova igra?";
                string caption = "Isteceno vreme";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    timer1.Start();
                    ChangeNumbers();
                    label5.Text = "1";
                    progressBar2.Value = 500;
                    progressBar1.Value = 0;
                    counter = 0;
                    label4.Text = "0";
                    textBox1.Text = "";
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            if (b == 3)
            {
                timer1.Stop();
                string cc = a.ToString();
                string message =
              "Vi cestitam. Pobedivte. Vaseto vreme bese " + cc + " sekundi. Dali sakate nova igra?";
                string caption = "Pobeda";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Information);


                if (result == DialogResult.Yes)
                {
                    timer1.Start();
                    ChangeNumbers();
                    label5.Text = "1";
                    progressBar2.Value = 500;
                    progressBar1.Value = 0;
                    counter = 0;
                    label4.Text = "0";
                    textBox1.Text = "";
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}
