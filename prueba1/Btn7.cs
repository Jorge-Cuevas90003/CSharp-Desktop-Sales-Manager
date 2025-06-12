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
using Microsoft.VisualBasic;
using System.Configuration;
namespace prueba1
{
    public partial class Btn7 : Form
    {
        public Btn7()
        {
            InitializeComponent();
        }

        private void Btn7_Load(object sender, EventArgs e)
        {


            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From Bodega_Empresa;";
            MySqlConnection cone1 = new MySqlConnection(url1);
            MySqlCommand comando2new = new MySqlCommand(Instrucciones1, cone1);
            comando2new.CommandTimeout = 60;
            MySqlDataReader tabla2;
            cone1.Open();
            tabla2 = comando2new.ExecuteReader();
            if (tabla2.HasRows)
            {
                while (tabla2.Read())
                {
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone1.Close();

            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones = "select *From registro_productos;";
            MySqlConnection cone = new MySqlConnection(url);
            MySqlCommand comandonew = new MySqlCommand(Instrucciones, cone);
            comandonew.CommandTimeout = 60;
            MySqlDataReader tabla;
            cone.Open();
            tabla = comandonew.ExecuteReader();
            if (tabla.HasRows)
            {
                while (tabla.Read())
                {
                    string[] fila = { tabla.GetString(0), tabla.GetString(1), tabla.GetString(2), tabla.GetString(3), tabla.GetString(4), tabla.GetString(5), tabla.GetString(6), tabla.GetString(7),tabla.GetString(8),tabla.GetString(9) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }
            cone.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();

            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Intrucciones = "insert into   Bodega_Empresa values('" + Txt_IdBodega.Text + "','" + Txt_IdProductoIngresado.Text + "')";
            MySqlConnection cone = new MySqlConnection(url);
            MySqlCommand comando = new MySqlCommand(Intrucciones, cone);
            comando.CommandTimeout = 60;
            MySqlDataReader tabla;
            cone.Open();
            tabla = comando.ExecuteReader();
            if (tabla.HasRows)
            {
                MessageBox.Show("Se ha registrado exitosamente");
            }
            cone.Close();


            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From bodega_empresa;";
            MySqlConnection cone1 = new MySqlConnection(url1);
            MySqlCommand comando2new = new MySqlCommand(Instrucciones1, cone1);
            comando2new.CommandTimeout = 60;
            MySqlDataReader tabla2;
            cone1.Open();
            tabla2 = comando2new.ExecuteReader();
            if (tabla2.HasRows)
            {
                while (tabla2.Read())
                {
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1)};
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone1.Close();
            Txt_IdProductoIngresado.Text = "";
            Txt_IdBodega.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double C = Convert.ToDouble(Txt_Cantidad.Text), U = Convert.ToDouble(Txt_PrecioU.Text), T = C * U;
            listView1.Items.Clear();
            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Intrucciones = "insert into   registro_productos(Marca,Modelo,PrecioU,cantidad,precioTotal,Renta_Mensual,Proveedor,Bodega,Descripcion) values('" + Txt_Marca.Text + "','" + Txt_Modelo.Text + "','" + Txt_PrecioU.Text + "','" + Txt_Cantidad.Text + "','" + T + "','" + Txt_RentaMensual.Text + "','" + Txt_Proveedor.Text + "','" + Txt_Bodega.Text + "','" + textBox1.Text + "')";
            MySqlConnection cone = new MySqlConnection(url);
            MySqlCommand comando = new MySqlCommand(Intrucciones, cone);
            comando.CommandTimeout = 60;
            MySqlDataReader tabla;
            cone.Open();
            tabla = comando.ExecuteReader();
            if (tabla.HasRows)
            {
                MessageBox.Show("Se ha registrado exitosamente");
            }
            cone.Close();

            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From registro_productos;";
            MySqlConnection cone1 = new MySqlConnection(url1);
            MySqlCommand comando2new = new MySqlCommand(Instrucciones1, cone1);
            comando2new.CommandTimeout = 60;
            MySqlDataReader tabla2;
            cone1.Open();
            tabla2 = comando2new.ExecuteReader();
            if (tabla2.HasRows)
            {
                while (tabla2.Read())
                {
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4), tabla2.GetString(5), tabla2.GetString(6), tabla2.GetString(7), tabla2.GetString(8), tabla2.GetString(9) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }
            cone1.Close();




            Txt_Bodega.Text = "";
            Txt_Marca.Text = "";
            Txt_Modelo.Text = "";
            Txt_PrecioU.Text = "";
            Txt_Cantidad.Text = "";
            Txt_Total.Text = "";
            Txt_RentaMensual.Text = "";
            Txt_Proveedor.Text = "";
            textBox1.Text = "";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
           int borrar= Convert.ToInt32(Interaction.InputBox("Desde borrar el producto?", "Borrar Producto", ""));

            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Intrucciones = "delete from registro_productos where Id_producto_ingresado =" + borrar + ";";
                MySqlConnection cone = new MySqlConnection(url);
                MySqlCommand comando = new MySqlCommand(Intrucciones, cone);
                comando.CommandTimeout = 60;
                MySqlDataReader tabla;
                cone.Open();
                tabla = comando.ExecuteReader();

                cone.Close();

            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From registro_productos;";
                MySqlConnection cone1 = new MySqlConnection(url1);
                MySqlCommand comando2new = new MySqlCommand(Instrucciones1, cone1);
                comando2new.CommandTimeout = 60;
                MySqlDataReader tabla2;
                cone1.Open();
                tabla2 = comando2new.ExecuteReader();
                if (tabla2.HasRows)
                {
                    while (tabla2.Read())
                    {
                        string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4), tabla2.GetString(5), tabla2.GetString(6), tabla2.GetString(7), tabla2.GetString(8), tabla2.GetString(9) };
                        var ListViewItem = new ListViewItem(fila);
                        listView1.Items.Add(ListViewItem);
                    }


                }
                cone1.Close();

            


        }

      

      

     
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Bodega_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

       

        private void Txt_Total_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            double C = Convert.ToDouble(Txt_Cantidad.Text), U = Convert.ToDouble(Txt_PrecioU.Text), T = C * U;
            Txt_Total.Text = Convert.ToString(T);
        }
    }
}
