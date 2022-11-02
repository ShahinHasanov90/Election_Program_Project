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

namespace Election_Program_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection BAGLA = new SqlConnection(@"Data Source=DESKTOP-4CCALSF\SQLEXPRESS01;Initial Catalog=DB_PARTY;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            FRMSTATISTIK FR = new FRMSTATISTIK();
            FR.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BAGLA.Open();
            SqlCommand kt1 = new SqlCommand("insert into TBL_COUNTY (COUNTYNAME,A_PARTY,B_PARTY,C_PARTY,D_PARTY,E_PARTY,F_PARTY,G_PARTY) values (@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", BAGLA);
            kt1.Parameters.AddWithValue("@P2", TXTNAME.Text); 
            kt1.Parameters.AddWithValue("@P3", TXTA.Text);
            kt1.Parameters.AddWithValue("@P4", TXTB.Text);
            kt1.Parameters.AddWithValue("@P5", TXTC.Text);
            kt1.Parameters.AddWithValue("@P6", TXTD.Text);
            kt1.Parameters.AddWithValue("@P7", TXTE.Text);
            kt1.Parameters.AddWithValue("@P8", TXTF.Text);
            kt1.Parameters.AddWithValue("@P9", TXTG.Text);
            kt1.ExecuteNonQuery();
            BAGLA.Close();
            MessageBox.Show("County add lucky");
        }
    }
}
