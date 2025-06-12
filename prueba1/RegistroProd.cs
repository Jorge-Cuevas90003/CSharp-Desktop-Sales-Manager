using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace prueba1
{
    public partial class RegistroProd : Form
    {
        string hora = "";
        public string Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        public RegistroProd()
        {
            InitializeComponent();
        }


        public DataSet reportar()
        {
            try
            {
                string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones1 = "SELECT *From productos_ventas WHERE fecha LIKE '%"+hora+"%';";
                MySqlConnection cone1 = new MySqlConnection(url1);
                MySqlCommand comando2new = new MySqlCommand(Instrucciones1, cone1);
                comando2new.CommandTimeout = 60;
                cone1.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(Instrucciones1, cone1);
                DataSet dst = new DataSet();
                da.Fill(dst);
                cone1.Close();
                return dst;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
                return null;
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            DataSet dst = new DataSet();
            dst = reportar();
            if (dst.Tables[0].Rows.Count - 1 >= 0)
            {
                CrystalReport3 reporte = new CrystalReport3();
                reporte.SetDataSource(dst.Tables[0]);
                crystalReportViewer1.ReportSource = reporte;

            }
            else
            {
                MessageBox.Show("No hay factura");
            }
        }
    }
}
