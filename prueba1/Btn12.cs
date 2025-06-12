using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace prueba1
{
    public partial class Btn12 : Form
    {
       
        double Total = 0;
        double SuperT = 0;
        
        public Btn12()
        {
 
            InitializeComponent();
        }

        private void Btn12_Load(object sender, EventArgs e)
        {
          

            //Txt_Total.Text = "0";
            try
            {
                string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones1 = "select Id_producto_ingresado,Marca,Modelo,Renta_Mensual,Descripcion,cantidad  from registro_productos where cantidad>0;";
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
                    string[] fila = { tabla2.GetString(0), tabla2.GetString(1), tabla2.GetString(2), tabla2.GetString(3), tabla2.GetString(4), tabla2.GetString(5) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone1.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            try
            {

                string url2 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones2 = "select *From cliente;";
            MySqlConnection cone2 = new MySqlConnection(url2);
            MySqlCommand comando1new = new MySqlCommand(Instrucciones2, cone2);
            comando1new.CommandTimeout = 60;
            MySqlDataReader tabla1;
            cone2.Open();
            tabla1 = comando1new.ExecuteReader();
            if (tabla1.HasRows)
            {
                while (tabla1.Read())
                {
                    string[] fila = { tabla1.GetString(0), tabla1.GetString(1), tabla1.GetString(2), tabla1.GetString(3), tabla1.GetString(4) };
                    var ListViewItem = new ListViewItem(fila);
                    listView3.Items.Add(ListViewItem);
                }


            }
            cone2.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");


            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            List<string> list3 = new List<string>();
            List<string> list4 = new List<string>();
            List<string> list5 = new List<string>();
            double total = 0;
            foreach (ListViewItem item in listView4.Items)
            {

                string IdProducto = string.Format("{0}", item.SubItems[0].Text);
                string Marca = string.Format("{0}", item.SubItems[1].Text);
                string Modelo = string.Format("{0}", item.SubItems[2].Text);
                string RentaMensula = string.Format("{0}", item.SubItems[3].Text);
                string Cantidad = string.Format("{0}", item.SubItems[4].Text);
                total += Convert.ToDouble(item.SubItems[5].Text);

                list.Add(IdProducto);
                list2.Add(Marca);
                list3.Add(Modelo);
                list4.Add(RentaMensula);
                list5.Add(Cantidad);
            }

            string result = string.Join(";", list.ToArray());
            string result2 = string.Join(";", list2.ToArray());
            string result3 = string.Join(";", list3.ToArray());
            string result4 = string.Join(";", list4.ToArray());
            string result5 = string.Join(";", list5.ToArray());
            // MessageBox.Show(""+result+"  "+result2+"  "+ result3+"  "+result4+ "  "+"  "+result5+ total);
            try {
                string urlfinal = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instruccionesfinal = "Insert into Productos_Ventas(Id_productos,Marca,Modelo,Renta_Mensual,Cantidad,Total,Nit,fecha) values('" + result + "','" + result2 + "','" + result3 + "','" + result4 + "','" + result5 + "','" + total + "','" + listView3.SelectedItems[0].Text + "','" + sqlFormattedDate + "')";
                MySqlConnection conefinal = new MySqlConnection(urlfinal);
                MySqlCommand comandofinal = new MySqlCommand(Instruccionesfinal, conefinal);
                comandofinal.CommandTimeout = 60;
                MySqlDataReader tablaFinal;
                conefinal.Open();
                tablaFinal = comandofinal.ExecuteReader();
                if (tablaFinal.HasRows)
                {
                    MessageBox.Show("Se ha registrado exitosamente");
                }
                conefinal.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }

            Factura nw = new Factura();
            nw.Hora = sqlFormattedDate;
            nw.Show();

            listView4.Items.Clear();
            Lbl_CantidadProducto.Text = "" ;
            Txt_Cantidad.Text = "";
                }
        

        private void Txt_Producto_TextChanged(object sender, EventArgs e)
        {
            
            }

        private void Txt_Marca_TextChanged(object sender, EventArgs e)
        {
          
        }

       
        private void Txt_Producto_Click(object sender, EventArgs e)
        {
            
            }

      

      

        private void Txt_Cantidad_Click(object sender, EventArgs e)
        {
           

        }

        private void Txt_Cantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            try {
                string url1 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones1 = "select *From cliente where Id_Cliente='"+textBox2.Text+"';";
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
                    listView3.Items.Add(ListViewItem);
                }


            }
            
            cone1.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
            button6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            try {
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
                    listView3.Items.Add(ListViewItem);
                }


            }
            cone1.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            try
            {
                string url = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones = "select *From registro_productos where Id_producto_ingresado='"+textBox1.Text+"';";
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
                    string[] fila = { tabla.GetString(0), tabla.GetString(1), tabla.GetString(2), tabla.GetString(3), tabla.GetString(4), tabla.GetString(5), tabla.GetString(6), tabla.GetString(7) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(""+ex);
            }
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            try {
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
                    string[] fila = { tabla.GetString(0), tabla.GetString(1), tabla.GetString(2), tabla.GetString(3), tabla.GetString(4), tabla.GetString(5), tabla.GetString(6), tabla.GetString(7) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone.Close();
        }
            catch (MySqlException ex)
            {
                MessageBox.Show(""+ex);
            }
}

        private void Txt_Total_TextChanged(object sender, EventArgs e)
        {

        }



        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {
            /*   string url = "datasource=localhost; port=3306; username=root;password=;database=prueba1";
               string Instrucciones = "select *from Productos_Ventas where Id_Venta  ='" + listView2.SelectedItems[0].Text  + "';";
               MySqlConnection cone = new MySqlConnection(url);
               MySqlCommand comandonew = new MySqlCommand(Instrucciones, cone);
               comandonew.Parameters.AddWithValue("Id_Cliente", Txt_Cliente.Text);
               comandonew.CommandTimeout = 60;
               MySqlDataReader tabla;
               cone.Open();
               tabla = comandonew.ExecuteReader();
               if (tabla.Read())
               {
                   NombreP = tabla["Modelo"].ToString();
                   Marca = tabla["Marca"].ToString();
                   RentaM = tabla["Renta_Mensual"].ToString();
                   Cantidad = tabla["Cantidad"].ToString();
                   Total = tabla["Total"].ToString();
               }

       */

            double cantidad1 = Convert.ToDouble(Txt_Cantidad.Text);
            if (cantidad1 <= Convert.ToInt32(listView2.SelectedItems[0].SubItems[5].Text))
            {



                int veri = 0;
                if (Txt_Descuento.Text == "Ingresa el % de descuento")
                {


                    double cantidad = Convert.ToDouble(Txt_Cantidad.Text);

                    double T = Convert.ToDouble(listView2.SelectedItems[0].SubItems[3].Text);
                    double lo = cantidad * T;

                    string[] filas = new string[7];
                    ListViewItem elementoListView;
                    filas[0] = listView2.SelectedItems[0].Text;
                    filas[1] = listView2.SelectedItems[0].SubItems[1].Text;
                    filas[2] = listView2.SelectedItems[0].SubItems[2].Text;
                    filas[3] = listView2.SelectedItems[0].SubItems[3].Text;
                    filas[4] = Txt_Cantidad.Text;
                    filas[5] = lo.ToString();
                    Lbl_Total.Text = listView2.SelectedItems[0].SubItems[3].Text;
                    elementoListView = new ListViewItem(filas);
                    listView4.Items.Add(elementoListView);
                    double sum1 = Convert.ToDouble(Txt_Totall.Text);
                    double sum2 = sum1 + Convert.ToDouble(lo);
                    Txt_Totall.Text = Convert.ToString(sum2);

                    Lbl_Total.Text = sum2.ToString();
                    int o = Convert.ToInt32(Lbl_CantidadProducto.Text);
                    int i = Convert.ToInt32(Txt_Cantidad.Text);

                    int sum = o + i;

                    Lbl_CantidadProducto.Text = Convert.ToString(sum);

                }
                else
                {
                    veri = Convert.ToInt32(Txt_Descuento.Text);

                    if (Rb_Yes.Checked)
                    {
                        if (veri > 25)
                        {
                            MessageBox.Show("El descuento no peude ser mayor a 25");
                        }
                        else if (veri <= 25)
                        {

                            double cantidad = Convert.ToDouble(Txt_Cantidad.Text);
                            double Desc = Convert.ToDouble(Txt_Descuento.Text);
                            double T = Convert.ToDouble(listView2.SelectedItems[0].SubItems[3].Text);
                            double lo = cantidad * T;
                            Total = lo * (Desc / 100);
                            SuperT = lo - Total;

                            string[] filas = new string[7];
                            ListViewItem elementoListView;
                            filas[0] = listView2.SelectedItems[0].Text;
                            filas[1] = listView2.SelectedItems[0].SubItems[1].Text;
                            filas[2] = listView2.SelectedItems[0].SubItems[2].Text;
                            filas[3] = listView2.SelectedItems[0].SubItems[3].Text;
                            filas[4] = Txt_Cantidad.Text;
                            filas[5] = SuperT.ToString();
                            double sum1 = Convert.ToDouble(Txt_Totall.Text);
                            double sum2 = sum1 + Convert.ToDouble(SuperT);
                            Txt_Totall.Text = Convert.ToString(sum2);
                            int o = Convert.ToInt32(Lbl_CantidadProducto.Text);
                            int i = Convert.ToInt32(Txt_Cantidad.Text);

                            int sum = o + i;

                            Lbl_CantidadProducto.Text = Convert.ToString(sum);
                            Lbl_Total.Text = sum2.ToString();
                            elementoListView = new ListViewItem(filas);
                            listView4.Items.Add(elementoListView);
                        }
                    }
                }

               

          

        
         

            Txt_Descuento.Visible = false;
            Txt_Descuento.Text = "Ingresa el % de descuento";
            radioButton1.Checked = false;


                try {
                    string url4 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                    string Intrucciones4 = "UPDATE registro_productos set cantidad = cantidad-'" + Convert.ToInt32(Txt_Cantidad.Text) + "' where Id_producto_ingresado='" + listView2.SelectedItems[0].Text + "'";
            MySqlConnection cone4 = new MySqlConnection(url4);
            MySqlCommand comando4 = new MySqlCommand(Intrucciones4, cone4);
            comando4.CommandTimeout = 60;
            MySqlDataReader tabla4;
            cone4.Open();
            tabla4 = comando4.ExecuteReader();
            cone4.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("" + ex);
                }




                listView2.Items.Clear();

                string url5 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones5 = "select Id_producto_ingresado,Marca,Modelo,Renta_Mensual,Descripcion,cantidad  from registro_productos where cantidad>0;";
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
                    string[] fila = { tabla5.GetString(0), tabla5.GetString(1), tabla5.GetString(2), tabla5.GetString(3), tabla5.GetString(4), tabla5.GetString(5) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone5.Close();
            }else {
                MessageBox.Show("No se puede pasar del stock");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string url4 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Intrucciones4 = "UPDATE registro_productos set cantidad = cantidad+'" + listView4.SelectedItems[0].SubItems[4].Text + "' where Id_producto_ingresado='" + listView4.SelectedItems[0].Text + "'";
                MySqlConnection cone4 = new MySqlConnection(url4);
                MySqlCommand comando4 = new MySqlCommand(Intrucciones4, cone4);
                comando4.CommandTimeout = 60;
                MySqlDataReader tabla4;
                cone4.Open();
                tabla4 = comando4.ExecuteReader();
                cone4.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }




            listView2.Items.Clear();
            try {
                string url5 = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                string Instrucciones5 = "select Id_producto_ingresado,Marca,Modelo,Renta_Mensual,Descripcion,cantidad  from registro_productos where cantidad>0;";
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
                    string[] fila = { tabla5.GetString(0), tabla5.GetString(1), tabla5.GetString(2), tabla5.GetString(3), tabla5.GetString(4), tabla5.GetString(5) };
                    var ListViewItem = new ListViewItem(fila);
                    listView2.Items.Add(ListViewItem);
                }


            }
            cone5.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("" + ex);
            }


            double select = Convert.ToDouble(listView4.SelectedItems[0].SubItems[5].Text);
            double select1 = Convert.ToDouble(listView4.SelectedItems[0].SubItems[4].Text);

            double total = Convert.ToDouble(Lbl_Total.Text);
            double cantidad = Convert.ToDouble(Lbl_CantidadProducto.Text);

            double total1 = total - select;
            double total2 = cantidad - select1;


            Lbl_Total.Text = total1.ToString();
            Lbl_CantidadProducto.Text = total2.ToString();
            for (int i = listView4.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem itm = listView4.SelectedItems[i];
                listView4.Items[itm.Index].Remove();
            } 
        
            
        }

        private void listView4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        
        }

        private void Txt_Modelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rb_Yes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Rb_Yes_Click(object sender, EventArgs e)
        {
         

            string pregunta = Microsoft.VisualBasic.Interaction.InputBox("Ingresa la Contraseña","Contaseña");
            if (pregunta.Equals("123"))
            {
                Txt_Descuento.Visible = true;
                
            }

        }

        private void Txt_Descuento_Click(object sender, EventArgs e)
        {
            Txt_Descuento.Text = "";
        }

        private void Txt_RentaMensual_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt_Descuento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
