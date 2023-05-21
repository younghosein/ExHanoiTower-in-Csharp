using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hanoiTower2
{
    public partial class Form1 : Form
    {
        Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form2 = new Form2();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            form2.Visible = true;
            this.Visible = false;
        }
    }
}
