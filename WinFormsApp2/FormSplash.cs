using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class FormSplash : Form
    {
        
        public FormSplash()
        {
            InitializeComponent();
        }

        public string Password { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Password = textBox1.Text;  
            Close();
        }
    }
   
}
