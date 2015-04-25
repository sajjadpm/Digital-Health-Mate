using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DHM
{
    public partial class Form3 : Form

       
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;

        SqlConnection con = new SqlConnection("Data Source=SAJJAD\\SQLEXPRESS;Initial Catalog=DHM;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            chartControl1.Visible = false;
            chartControl2.Visible = false;
            chartControl3.Visible = false;
            chartControl4.Visible = false;
            
        }


        public void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hAEMO._HAEMO' table. You can move, or remove it, as needed.
            this.hAEMOTableAdapter.Fill(this.hAEMO._HAEMO);
            // TODO: This line of code loads data into the 'dHMDataSet3.HAEMO' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dHMDataSet1.SUGAR' table. You can move, or remove it, as needed.
            this.sUGARTableAdapter.Fill(this.dHMDataSet1.SUGAR);
            // TODO: This line of code loads data into the 'dHMDataSet.CHOL' table. You can move, or remove it, as needed.
            this.cHOLTableAdapter.Fill(this.dHMDataSet.CHOL);
            
           
            // TODO: This line of code loads data into the 'bP.bp' table. You can move, or remove it, as needed.
            this.bpTableAdapter.Fill(this.bP.bp);


            try
            {

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }


        }



        void clear()
        {

       
        textEdit1.Text = null;
        textEdit2.Text=null;
        textEdit3.Text=null;
        textEdit4.Text=null;
        textEdit5.Text=null;
        textEdit6.Text = null;
        textEdit7.Text = null;
        textEdit8.Text = null;
        textEdit9.Text = null;
        textEdit10.Text = null;
        textEdit11.Text = null;
        textEdit12.Text = null;
        textEdit13.Text = null;
        textEdit14.Text = null;
        textEdit15.Text = null;
        textEdit16.Text = null;
        textEdit17.Text = null;
        textEdit18.Text = null;
        textEdit19.Text = null;
        }

        private void simpleButton2_Click(object sender, EventArgs e)

        {
            if (textEdit1.Text =="" || textEdit2.Text =="" || textEdit3.Text =="" || textEdit4.Text =="" || textEdit5.Text =="")
            {
                label7.Text = "Please Enter All The Fields";

            }

            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO bp VALUES('" + textEdit1.Text + "','" + textEdit2.Text + "','" + textEdit3.Text + "','" + textEdit4.Text + "','" + textEdit5.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                label7.Text = "Data Entered Successfully Into The Database";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {

                Form3_Load(this, null);
                 chartControl1.Visible = true;
                //    chartControl1.DataBind();
                  chartControl1.Update();
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textEdit6.Text == "" || textEdit7.Text == "" || textEdit8.Text == "" || textEdit9.Text == "" || textEdit10.Text == "")
            {
                label13.Text = "Please Enter All The Fields";

            }

            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO CHOL VALUES('" + textEdit6.Text + "','" + textEdit7.Text + "','" + textEdit8.Text + "','" + textEdit9.Text + "','" + textEdit10.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                label13.Text = "Data Entered Successfully Into The Database";
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try
            {

                Form3_Load(this, null);
                chartControl2.Visible = true;
                //    chartControl1.DataBind();
                chartControl2.Update();
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (textEdit11.Text == "" || textEdit12.Text == "" || textEdit13.Text == "" || textEdit14.Text == "")
            {
                label18.Text = "Please Enter All The Fields";

            }

            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SUGAR VALUES('" + textEdit11.Text + "','" + textEdit12.Text + "','" + textEdit13.Text + "','" + textEdit14.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                label18.Text = "Data Entered Successfully Into The Database";
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            try
            {

                Form3_Load(this, null);
                chartControl3.Visible = true;
                //    chartControl1.DataBind();
                chartControl3.Update();
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (textEdit15.Text == "" || textEdit16.Text == "" || textEdit17.Text == "" || textEdit18.Text == "" || textEdit19.Text == "")
            {
                label24.Text = "Please Enter All The Fields";

            }

            else
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO HAEMO VALUES('" + textEdit15.Text + "','" + textEdit16.Text + "','" + textEdit17.Text + "','" + textEdit18.Text + "','" + textEdit19.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                clear();
                label24.Text = "Data Entered Successfully Into The Database";
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try
            {

                Form3_Load(this, null);
                chartControl4.Visible = true;
                //    chartControl1.DataBind();
                chartControl4.Update();
            }

            catch (Exception f)
            {
                MessageBox.Show(f.Message);

            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            scb=new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            sda=new SqlDataAdapter(@"SELECT id,email,name,systolicpresent,diastolicpresent,date FROM bp",con);
            dt=new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        

       
        
    }
}
