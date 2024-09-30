using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL_Kütüphanesi;

namespace DLL_Uygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString( Matematik.Dörtİşlem.topla(Convert.ToDouble(textBox1.Text),
                                              Convert.ToDouble(textBox2.Text)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Matematik.Dörtİşlem.çıkar(Convert.ToDouble(textBox1.Text),
                                              Convert.ToDouble(textBox2.Text)));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Matematik.Dörtİşlem.çarp(Convert.ToDouble(textBox1.Text),
                                              Convert.ToDouble(textBox2.Text)));

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(Matematik.Dörtİşlem.böl(Convert.ToDouble(textBox1.Text),
                                  Convert.ToDouble(textBox2.Text)));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(Matematik.Geometri.dikdörtgenAlan(Convert.ToDouble(textBox4.Text),
                                  Convert.ToDouble(textBox5.Text)));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = Convert.ToString(Matematik.Geometri.daireAlan(Convert.ToDouble(textBox7.Text)));

        }
    }
}
