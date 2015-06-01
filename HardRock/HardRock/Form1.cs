using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardRock
{
    public partial class Form1 : Form
    {
        private DBManager db;
        public Form1()
        {
            InitializeComponent();
            this.db = new DBManager(null);

            //var table = db.GetBandInfo();

            //string s = table[0][1] as string;

           



           // Console.WriteLine(s);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setband();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetKonsert();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SetAnstalld();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SetTelefonNr();
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
           // new DBManager().Test(1,"Dunder björnarna", "Hårdor", 1, "Sagovärlden");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Setband()
        {
            db.InsertBand(textBox2.Text, textBox3.Text, int.Parse(textBox4.Text), textBox5.Text);
        }

        public void SetKonsert()
        {
          db.InsertSpelning(textBox10.Text, textBox9.Text, textBox8.Text, int.Parse(textBox7.Text), int.Parse(textBox6.Text));
        }

        public void SetAnstalld()
        {
           db.InsertAnstalld(textBox12.Text, int.Parse(textBox11.Text));
        }

        public void SetTelefonNr()
        {
            db.InsertTelefonNr(textBox14.Text, int.Parse(textBox15.Text));
        }

        public void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }


          

        
        
    }
}
