using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DHM
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
           {
            Form3 a=new Form3();
           // login b=new login();
            if (textBox1.Text == "123456")
            {
                this.Close();
                a.Show();
                
            }
          
        
            else
            {
                label3.ForeColor = Color.Red;
               label3.Text = "Wrong Credential";
                Refresh();
            }
           }
           catch (Exception f)
           {

               MessageBox.Show(f.Message);

           }
        }
    }
}
