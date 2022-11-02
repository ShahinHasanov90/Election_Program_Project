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
    public partial class FRMSTATISTIK : Form
    {
        public FRMSTATISTIK()
        {
            InitializeComponent();
        }
        SqlConnection BAGLA = new SqlConnection(@"Data Source=DESKTOP-4CCALSF\SQLEXPRESS01;Initial Catalog=DB_PARTY;Integrated Security=True");
        private void FRMSTATISTIK_Load(object sender, EventArgs e)
        {
            BAGLA.Open();
            SqlCommand kt3 = new SqlCommand("select COUNTYNAME from TBL_COUNTY", BAGLA);
            SqlDataReader dr3 = kt3.ExecuteReader();
            while(dr3.Read())
            {
                comboBox1.Items.Add(dr3[0]);
            }
            BAGLA.Close();

            BAGLA.Open();
            SqlCommand kt4 = new SqlCommand("Select SUM(A_PARTY),SUM(B_PARTY),SUM(C_PARTY),SUM(D_PARTY),SUM(E_PARTY),SUM(F_PARTY),SUM(G_PARTY) FROM TBL_COUNTY", BAGLA);
            SqlDataReader dr4 = kt4.ExecuteReader();
            while(dr4.Read())
            {
                chart1.Series["COUNTIES"].Points.AddXY("A_PARTY", dr4[0]);
                chart1.Series["COUNTIES"].Points.AddXY("B_PARTY", dr4[1]);
                chart1.Series["COUNTIES"].Points.AddXY("C_PARTY", dr4[2]);
                chart1.Series["COUNTIES"].Points.AddXY("D_PARTY", dr4[3]);
                chart1.Series["COUNTIES"].Points.AddXY("E_PARTY", dr4[4]);
                chart1.Series["COUNTIES"].Points.AddXY("F_PARTY", dr4[5]);
                chart1.Series["COUNTIES"].Points.AddXY("G_PARTY", dr4[6]);

            }
            BAGLA.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BAGLA.Open();
            SqlCommand kt5 = new SqlCommand("Select * from TBL_COUNTY where COUNTYNAME=@C1", BAGLA);
            kt5.Parameters.AddWithValue("@C1", comboBox1.Text);
            SqlDataReader dr5 = kt5.ExecuteReader();
            while (dr5.Read())
            {
                progressBar1.Value = int.Parse(dr5[2].ToString());
                progressBar2.Value = int.Parse(dr5[3].ToString());
                progressBar3.Value = int.Parse(dr5[4].ToString());
                progressBar4.Value = int.Parse(dr5[5].ToString());
                progressBar5.Value = int.Parse(dr5[6].ToString());
                progressBar6.Value = int.Parse(dr5[7].ToString());
                progressBar7.Value = int.Parse(dr5[8].ToString());

                LBLA.Text = dr5[2].ToString();
                LBLB.Text = dr5[3].ToString();
                LBLC.Text = dr5[4].ToString();
                LBLD.Text = dr5[5].ToString();
                LBLE.Text = dr5[6].ToString();
                LBLF.Text = dr5[7].ToString();
                LBLG.Text = dr5[2].ToString();

            }
            BAGLA.Close();
            //LOOK FOR THANKS(-_*):

        }
    }
}
