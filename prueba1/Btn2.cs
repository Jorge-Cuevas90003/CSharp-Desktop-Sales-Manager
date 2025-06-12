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
    public partial class Btn2 : Form
    {
        public Btn2()
        {
            InitializeComponent();
        }

        private void Btn2_Load(object sender, EventArgs e)
        {

            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From cliente;";
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
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }
            cone1.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            listView1.Items.Clear();
        
            try
            {


                string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Intrucciones = "insert into cliente values('" + Txt_NIT.Text + "','"+Txt_NombreCliente.Text+"','"+Txt_Direccion.Text+"','"+Txt_Telefono.Text+"','"+Txt_Correo.Text+"')";
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
                string Instrucciones1 = "select *From cliente;";
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
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2),tabla2.GetString(3),tabla2.GetString(4) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }
            cone1.Close(); Txt_NIT.Text = "";
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show("" + Ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Intrucciones = "delete *from cliente where Id_Cliente='"+Txt_NIT.Text+"';";
            MySqlConnection cone = new MySqlConnection(url);
            MySqlCommand comando = new MySqlCommand(Intrucciones, cone);
            comando.CommandTimeout = 60;
            MySqlDataReader tabla;
            cone.Open();
            tabla = comando.ExecuteReader();
        
            cone.Close();



            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From cliente;";
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
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Intrucciones = "UPDATE  cliente set Nombre_Empresa='"+Txt_NombreCliente.Text+"', Direccion_Empresa='"+Txt_Direccion.Text+"', Telefono='"+Txt_Telefono.Text+"', Correo='"+Txt_Correo.Text+"' where Id_Cliente='"+Txt_NIT.Text+"';";
            MySqlConnection cone = new MySqlConnection(url);
            MySqlCommand comando = new MySqlCommand(Intrucciones, cone);
            comando.CommandTimeout = 60;
            MySqlDataReader tabla;
            cone.Open();
            tabla = comando.ExecuteReader();
         
            cone.Close();
            string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            string Instrucciones1 = "select *From cliente;";
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
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4) };
                    var ListViewItem = new ListViewItem(fila);
                    listView1.Items.Add(ListViewItem);
                }


            }

        }

        private void Txt_NIT_Click(object sender, EventArgs e)
        {
            
        }
    }
}
