using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP3Lab3.Modelo;

namespace TP3Lab3.Controlador
{
    class CtrlCity: Conexion
    {
        public List<Object> Consulta(string dato)
        {
            MySqlDataReader reader;
            List<Object> lista = new List<object>();
            string sql;

            if (dato == null)
            {
                sql = "SELECT ID, Name, CountryCode, District, Population " +
                    "FROM city ORDER BY Name ASC";
            }
            else
            {
                sql = "SELECT ID, Name, CountryCode, District, Population " +
                    "FROM city WHERE ID LIKE '%" + dato + "%' OR " +
                    "ID LIKE '%" + dato + "%' OR " +
                    "Name LIKE '%" + dato + "%' OR " +
                    "CountryCode LIKE '%" + dato + "%' OR " +
                    "District LIKE '%" + dato + "%' OR " +
                    "Population LIKE '%" + dato + "%' " +
                    "ORDER BY Name ASC";
            }

            try
            {
                MySqlConnection conexionDB = base.ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    City city = new City();
                    city.ID = int.Parse(reader.GetString("ID"));
                    city.Name = reader.GetString("Name");
                    city.CountryCode = reader.GetString("CountryCode");
                    city.District = reader.GetString("District");
                    city.Population = int.Parse(reader.GetString("Population"));

                    lista.Add(city);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString()); 
            }
            return lista;
        }

        public bool Insertar(City datos)
        {
            bool bandera = false;

            string sql = "INSERT INTO city " +
                "(Name, CountryCode, District, Population) VALUES (" +
                "'" + datos.Name + "', " +
                "'" + datos.CountryCode + "', " +
                "'" + datos.District + "', " +
                "'" + datos.Population + "')";

            try
            {
                MySqlConnection conexionDB = ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool Actualizar(City datos)
        {
            bool bandera = false;

            string sql = "UPDATE city SET " +
               "Name='" + datos.Name + "', " +
               "CountryCode='" + datos.CountryCode + "', " +
               "District='" + datos.District + "', " +
               "Population='" + datos.Population + "' " +
               "WHERE ID='" + datos.ID + "'";

            try
            {
                MySqlConnection conexionDB = ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }

        public bool Eliminar(int id)
        {
            bool bandera = false;

            string sql = "DELETE FROM city WHERE ID='" + id + "'";

            try
            {
                MySqlConnection conexionDB = ConexionDB();
                conexionDB.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                bandera = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                bandera = false;
            }
            return bandera;
        }
    }
}
