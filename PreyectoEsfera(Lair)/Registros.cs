using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PreyectoEsfera_Lair_
{
    class Registros
    {
        public void insertaCompra(Label id_esfera, TextBox cantidad, string descrip, double subtotal, TextBox id_venta)
        {
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
            inserta.Conectar();

            String query = "INSERT INTO `eliarome35436DB`.`Carrito` (`id_esfera`, `cantidad`, `descripcion`, `Subtotal`, `id_venta`) VALUES ('" + id_esfera.Text + "','" + cantidad.Text + "','" + descrip + "','" + subtotal + "','"+id_venta.Text+ "')";
            Coman = inserta.construye_command(query);
            inserta.ejecutanonquery();
            Coman.Connection.Close();
            inserta.desconectar();
        }
        public void insertaVendedor(TextBox Nom, TextBox App, TextBox Apm)
        {
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
            inserta.Conectar();

            String query = "Insert into Vendedor (Nombre, App_V, Apm_V) values('" + Nom.Text + "','" + App.Text + "','" + Apm.Text + "')";
            Coman = inserta.construye_command(query);
            inserta.ejecutanonquery();
            Coman.Connection.Close();
            inserta.desconectar();
        }
        public void insertaVenta(TextBox id_ven, Label subtot, Label total, Label id_vende,Label id_clien, DateTimePicker dat)
        {
            string fech = dat.Value.Year.ToString()+"-"+ dat.Value.Month.ToString() +"-"+ dat.Value.Day.ToString();
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
            inserta.Conectar();

            String query = "INSERT INTO `eliarome35436DB`.`Venta` (`id_venta`, `subtotal`, `total`, `id_Vendedor`, `Id_Cliente`, `fecha`) VALUES ('" +id_ven.Text + "','" + subtot.Text + "','" + total.Text +"','"+ id_vende.Text+"','"+id_clien.Text+"','"+fech+ "')";
            Coman = inserta.construye_command(query);
            inserta.ejecutanonquery();
            Coman.Connection.Close();
            inserta.desconectar();
        }
        public void insertaCliente(TextBox Nom, TextBox App, TextBox Apm,TextBox tel,TextBox rfc,TextBox direc)
        {
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
            inserta.Conectar();

            String query = "INSERT INTO `eliarome35436DB`.`Cliente` (`Name_c`, `App_c`, `Apm_c`, `Tel`, `RFC`, `Direccion`) VALUES ('" + Nom.Text + "','" + App.Text + "','" + Apm.Text + "','" + tel.Text + "','" +
               rfc.Text + "','" + direc.Text + "')";
            Coman = inserta.construye_command(query);
            inserta.ejecutanonquery();
            Coman.Connection.Close();
            inserta.desconectar();
        }
        public void insertaEsferas(TextBox pintu,TextBox carto,TextBox ganch, TextBox color, TextBox tamaño)
        {
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
            inserta.Conectar();
            double pi = Convert.ToDouble(pintu.Text);
            double car = Convert.ToDouble(carto.Text);
            double ganc = Convert.ToDouble(ganch.Text);
            double costo = 0;
            double costo2 = 0;
            int cant=0;

            int tam = int.Parse(tamaño.Text);
            if (tam == 3)
            {
                 costo = (pi / 300 + car / 300 + ganc/700 );
                 cant = 300;
            }
            else
                if (tam == 5)
                {
                    costo = (pi / 265 + car / 265 + ganc/700 );
                    cant = 265;
                }
            if (tam == 3)
            {
                costo2 = (pi / 300 + ganc / 700);
                cant = 300;
            }
            else
                if (tam == 5)
                {
                    costo2 = (pi /265 + ganc / 700);
                    cant = 265;
                }

            String query = "INSERT INTO `eliarome35436DB`.`Esfera` (`costo_esf`, `color`, `tam`, `disponibilidad`, `Precio_en_caja`) VALUES ('" + costo2 + "','" + color.Text + "','" + tamaño.Text + "' , '" + cant + "','" + costo+"')";
            Coman = inserta.construye_command(query);
            inserta.ejecutanonquery();
            Coman.Connection.Close();
            inserta.desconectar();
        }
    }
    public class compra
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = new MySqlConnection("server=74.63.196.2; database=eliarome35436DB; Uid=eliarome35436; pwd=yKqPUDw9EyFL;");

            conectar.Open();
            return conectar;
        }

        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public double subtotal { get; set; }

        public void person(TextBox fa, Label l1)
        {
            string a="",b="",c="";
            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT `Name_c`,`App_c`,`Apm_c` FROM `Cliente` WHERE `Id_Cliente` = {0}", fa.Text), ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                a = _reader.GetString(0);
                b = _reader.GetString(1);
                c = _reader.GetString(2);
            }
            l1.Text = a + " " + b + " " + c;


        }

        public void suma(TextBox fa, Label l1, Label l2, Label l3)
        {
            double sum = 0;
            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT SUM(  `Subtotal` ) FROM  `Carrito` WHERE  `id_venta` = {0}", fa.Text), ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                sum = _reader.GetDouble(0);
            }
            l1.Text = Convert.ToString(sum);
            double st = sum * .16;
            l2.Text = Convert.ToString(st);
            l3.Text = Convert.ToString(sum + st);
        }

        public void sumaN(TextBox Na, Label l1)
        {
            double sum = 0;
            MySqlCommand _comando = new MySqlCommand(String.Format(
            "SELECT SUM(  `Subtotal` ) FROM  `Carrito` WHERE  `id_venta` = {0}", Na.Text), ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                sum = _reader.GetDouble(0);
            }
            double st = sum;
            l1.Text = Convert.ToString(st);
        }

        public static List<compra> carrito(TextBox id_ven)
        {

            List<compra> _lista = new List<compra>();
            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT `descripcion`,`cantidad`,`Subtotal` FROM `Carrito` WHERE `id_venta` = {0}", id_ven.Text), ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                compra pin = new compra();
                pin.descripcion = _reader.GetString(0);
                pin.cantidad = _reader.GetInt32(1);
                pin.subtotal = _reader.GetFloat(2);
                _lista.Add(pin);
            }
            return _lista;
        }
        public void Vaciar(TextBox fa)
        {
            MySqlCommand Coman;
            conec.datos inserta = new conec.datos();
                inserta.Conectar();
                String comando = "delete FROM `Carrito` WHERE `id_venta` = " + fa.Text;
                Coman = inserta.construye_command(comando);
                inserta.ejecutanonquery();
                Coman.Connection.Close();
                inserta.desconectar();
            
        }
    }
}
