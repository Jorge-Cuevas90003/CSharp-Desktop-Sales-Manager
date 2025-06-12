using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared.Json;
using System.Configuration;

namespace prueba1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
          
            InitializeComponent();
            personalizarretorno();
        }
        private void AbrisForms(object formHijo)
        {
            if (this.PanelContedor.Controls.Count > 0)
                P1.Visible = false;
            P2.Visible = false;
            P3.Visible = false;
            pictureBox11.Visible = false;
            oGrafico.Visible = false;
            this.PanelContedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContedor.Controls.Add(fh);
            this.PanelContedor.Tag = fh;
            fh.Show();


        }
        private void personalizarretorno()
        {
            Sub1.Visible = false;
            Sub2.Visible = false;
          
        }
        private void ocultarMenu()
        {
            if (Sub1.Visible == true)
                Sub1.Visible = false;
            if (Sub2.Visible == true)
                Sub2.Visible = false;
       
         
        }
        private void mostrarmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                ocultarMenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e) {

            
            try {
                string url3 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string sql = "select cliente.Nombre_Empresa, productos_ventas.Total from cliente inner join productos_ventas ON CLIENTE.Id_Cliente=productos_ventas.Nit order by cliente.Nombre_Empresa desc LIMIT 7;";
            MySqlConnection cone3 = new MySqlConnection(url3);
            cone3.Open();
            MySqlDataAdapter DA = new MySqlDataAdapter(sql, cone3);
            DA.Fill(graficos, "DataTable1");
            cone3.Close();
            oGrafico.Titles.Clear();
            oGrafico.Series.Clear();
            oGrafico.ChartAreas.Clear();
            oGrafico.Palette = ChartColorPalette.EarthTones;
            ChartArea areagrafico = new ChartArea();
            areagrafico.Area3DStyle.Enable3D = true;
            oGrafico.ChartAreas.Add(areagrafico);
            Title titulo = new Title("Top Compras(Q)");
            titulo.Font = new Font("Tahoma",18,FontStyle.Bold);
            oGrafico.Titles.Add(titulo);
            Series serie = new Series("DataTable1");
            serie.ChartType= SeriesChartType.Pie;
            serie.XValueMember = "Nombre_Empresa";
            serie.YValueMembers = "Total";
            serie.IsValueShownAsLabel = true;
            oGrafico.Series.Add(serie);
            oGrafico.DataSource=graficos.DataTable1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
         
            try
            {
                string url4 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string sql1 = "SELECT cliente.Nombre_Empresa, COUNT(*) as Cantidad FROM productos_ventas INNER JOIN cliente on productos_ventas.Nit=cliente.Id_Cliente GROUP BY cliente.Nombre_Empresa HAVING COUNT(*)>=1 order by (COUNT(*)) desc;";
                MySqlConnection cone4 = new MySqlConnection(url4);
                cone4.Open();
                MySqlDataAdapter DA1 = new MySqlDataAdapter(sql1, cone4);
                DA1.Fill(graficos, "DataTable2");
                cone4.Close();
                oGrafico2.Titles.Clear();
                oGrafico2.Series.Clear();
                oGrafico2.ChartAreas.Clear();
                oGrafico2.Palette = ChartColorPalette.Bright;
                ChartArea areagrafico2 = new ChartArea();
                areagrafico2.Area3DStyle.Enable3D = true;
                oGrafico2.ChartAreas.Add(areagrafico2);
                Title titulo2 = new Title("Clientes mas Frecuentes");
                titulo2.Font = new Font("Tahoma", 18, FontStyle.Bold);
                oGrafico2.Titles.Add(titulo2);
                Series serie2 = new Series("DataTable2");
                serie2.Name = "Cantidad de Compras";
                serie2.ChartType = SeriesChartType.Column;
                serie2.XValueMember = "Nombre_Empresa";
                serie2.YValueMembers = "Cantidad";
                serie2.IsValueShownAsLabel = true;
                oGrafico2.Series.Add(serie2);
                oGrafico2.DataSource = graficos.DataTable2;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }



            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
            try
            {

                string url5 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones5 = "select sum(Total) from productos_ventas;";
                MySqlConnection cone5 = new MySqlConnection(url5);
                MySqlCommand comando5new = new MySqlCommand(Instrucciones5, cone5);
                comando5new.CommandTimeout = 60;
                MySqlDataReader tabla5;
                cone5.Open();
                tabla5 = comando5new.ExecuteReader();
               if (tabla5.HasRows)
                {
                    while (tabla5.Read())
                     
                    {
                        if (tabla5.IsDBNull(0))
                        {

                        }
                        else
                        {
                            Tventas.Text = Convert.ToString(tabla5.GetString(0));
                        }
                           
                        

                            
                        
                            
                                                     
                          
             
                    }
                }
               
                cone5.Close();
            }catch(MySqlException ex)
            {
                MessageBox.Show(""+ex);
            }


            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select count(Id_Cliente) from cliente;";
            MySqlConnection cone1 = new MySqlConnection(url1);
            MySqlCommand comando1new = new MySqlCommand(Instrucciones1, cone1);
            comando1new.CommandTimeout = 60;
            MySqlDataReader tabla1;
            cone1.Open();
            tabla1 = comando1new.ExecuteReader();
            if (tabla1.HasRows)
            {
                while (tabla1.Read())
                {

                    Tclientes.Text = Convert.ToString(tabla1.GetString(0));

                }


            }
            cone1.Close();


            string url2 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones2 = "select count(Id_Venta) from productos_ventas;";
            MySqlConnection cone2 = new MySqlConnection(url2);
            MySqlCommand comando2new = new MySqlCommand(Instrucciones2, cone2);
            comando2new.CommandTimeout = 60;
            MySqlDataReader tabla2;
            cone2.Open();
            tabla2 = comando2new.ExecuteReader();
            if (tabla2.HasRows)
            {
                while (tabla2.Read())
                {

                    CV.Text = Convert.ToString(tabla2.GetString(0));

                }


            }
            cone2.Close();


        }


        private void button1_Click(object sender, EventArgs e)
        {
            mostrarmenu(Sub1);
           
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        
           
            this.WindowState = FormWindowState.Maximized;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mostrarmenu(Sub2);
            Gmail.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
   
            Gmail.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrisForms(new Btn1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrisForms(new Btn2());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/intl/es/gmail/about/#");

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
       
        }

        private void button13_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrisForms(new Btn6());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrisForms(new Btn7());
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
          
        }

        private void button14_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
     
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AbrisForms(new Btn12());
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.com/intl/es/drive/");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process.Start("https://docs.google.com/document/u/0/");


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/spreadsheets/u/0/");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe");

   
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            AbrisForms(new Btn12());
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
          
            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelContedor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form2 n = new Form2();
            this.Close();
            n.Show();
          

        }

        private void oGrafico_Click(object sender, EventArgs e)
        {

        }
    }
}
