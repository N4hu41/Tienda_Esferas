using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PreyectoEsfera_Lair_
{
    class conec
    {
        public class datos
        {

            public MySqlDataReader dr { get; set; }
            public MySqlCommand cadena_sql { set; get; }
            MySqlDataAdapter adapt;
            MySqlConnection conn;

            public bool Conectar()
            {
                conn = new MySqlConnection();
                conn.ConnectionString = "server=74.63.196.2; database=eliarome35436DB; Uid=eliarome35436; pwd=yKqPUDw9EyFL";
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al conectarse a la base de datos:" + error.Message);
                    return false;
                }
            }
            public void desconectar()
            {
                conn.Close();
            }
            public void construye_reader(string cadena)
            {
                cadena_sql = new MySqlCommand();
                cadena_sql.Connection = conn;
                cadena_sql.CommandText = cadena;

            }
            public MySqlDataReader ejecuta_reader()
            {
                try
                {
                    dr = cadena_sql.ExecuteReader();
                    return dr;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar el reader" + error.Message);
                    return null;
                }
            }
            public MySqlCommand construye_command(string cadena)
            {
                cadena_sql = new MySqlCommand(cadena, conn);
                return cadena_sql;
            }
            public int ejecutanonquery()
            {
                int afectados;
                try
                {
                    afectados = cadena_sql.ExecuteNonQuery();
                    return afectados;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error al ejecutar el reader" + error.Message);
                    return 0;
                }
            }
            public MySqlDataAdapter construye_adapter(string cadena)
            {
                adapt = new MySqlDataAdapter(cadena, conn);
                return adapt;
            }

        }
    }
}
