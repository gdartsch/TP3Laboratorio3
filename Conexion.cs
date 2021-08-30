using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3Lab3
{
    class Conexion
    {
        public MySqlConnection ConexionDB()
        {
            string servidor = "localhost";
            string db = "world";
            string usuario = "root";
            string password = "mysql";

            string cadenaConexion = "Database=" + db +
                                    "; Data Source=" + servidor +
                                    //"; Port=" + puerto +
                                    "; User Id= " + usuario +
                                    "; Password=" + password +"";


            try
            {
                MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);

                return conexionDb;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
