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
    public partial class Form2 : Form
    {
        private DBManager db;
        public Form2()
        {
            InitializeComponent();
            this.db = new DBManager(this);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.ShowBand();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.ShowSpelschema();
        }
    }
}
