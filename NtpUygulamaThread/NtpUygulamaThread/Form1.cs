using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NtpUygulamaThread
{
    public partial class Form1 : Form
    {
        private Random rnd;
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Control x in this.Controls)
            {
                if(x is Button){
                    if(((Button)x).Text!="Başla" && ((Button)x).Text != "Sil")
                    {
                        Point koor = ((Button)x).Location;
                        koor.X += rnd.Next(1, 10);
                        ((Button)x).Location = koor;
                        if (koor.X > this.ClientSize.Width - ((Button)x).Width)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show(((Button)x) + " kazandı");
                            break;
                        }
                        {

                        }

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls.OfType<Button>().ToList()) { 

                string ad= ((Button)item).Text;

                if (ad !="Başla" && ad != "Sil")
                {
                    this.Controls.Remove(item);
                }
            }
            timer1.Enabled=true;

            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
            {
                Button btn = new Button();
                btn.Location = new Point(10,i*50);
                btn.Name="btn"+i.ToString();
                btn.Size = new Size(50, 50);
                btn.Text=i.ToString();
                this.Controls.Add(btn);
            }
        }
    }
}
