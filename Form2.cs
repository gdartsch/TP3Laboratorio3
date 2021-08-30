using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP3Lab3.Controlador;
using TP3Lab3.Modelo;

namespace TP3Lab3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CargarTabla(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtCampo.Text;
            CargarTabla(dato);
        }

        private void CargarTabla(string dato)
        {
            List<City> lista = new List<City>();
            CtrlCity ctrlCity = new CtrlCity();
            dataGridView1.DataSource = ctrlCity.Consulta(dato);
        }

        /*private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                String nombre = txtNombre.Text;
                String codigoPais = txtCodigoPais.Text;
                String distrito = txtDistrito.Text;
                int poblacion = int.Parse(txtPoblacion.Text);

                if (nombre != "" && codigoPais != "" && distrito != "" && poblacion > 0)
                {
                    string sql = "INSERT INTO city " +
                        "(Name, CountryCode, District, Population) VALUES (" +
                        "'" + nombre + "', " +
                        "'" + codigoPais + "', " +
                        "'" + distrito + "', " +
                        "'" + poblacion + "')";

                    MySqlConnection conexionDB = Conexion.ConexionDB();
                    conexionDB.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Registro Guardado");
                        Limpiar();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message);
                    }
                    finally
                    {
                        conexionDB.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos"); 
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }
            
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT ID, Name, CountryCode, District, Population " +
                "FROM city WHERE ID LIKE '"+ codigo +"' LIMIT 1";

            MySqlConnection conexionDB = Conexion.ConexionDB();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtId.Text = reader.GetString(0);
                        txtNombre.Text = reader.GetString(1);
                        txtCodigoPais.Text = reader.GetString(2);
                        txtDistrito.Text = reader.GetString(3);
                        txtPoblacion.Text = reader.GetString(4);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron registros");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String codigoPais = txtCodigoPais.Text;
            String distrito = txtDistrito.Text;
            int poblacion = int.Parse(txtPoblacion.Text);

            string sql = "UPDATE city SET " +
                //"ID='"+codigo+"', " +
                "Name='" +nombre + "', " +
                "CountryCode='" +codigoPais + "', " +
                "District='" +distrito + "', " +
                "Population='" +poblacion + "' " +
                "WHERE ID='"+codigo+"'";

            MySqlConnection conexionDB = Conexion.ConexionDB();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Modificado");
                Limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            string sql = "DELETE FROM city WHERE " +
                "ID='" + codigo + "'";

            MySqlConnection conexionDB = Conexion.ConexionDB();
            conexionDB.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionDB);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
                Limpiar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtCodigoPais.Text = "";
            txtDistrito.Text = "";
            txtPoblacion.Text = "";
        }*/
    }
}
