using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace MySQProyecto
{
    public partial class Default : System.Web.UI.Page
    {
        //cadena de conexion de web config
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

        private void Listar()
        {
            string consulta = "select *from tautor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            gvAutor.DataSource = tabla;
            gvAutor.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //leer los datos 
                string codAutor = txtCodautor.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string nombres = txtNombres.Text.Trim();
                string nacionalidad = txtNacionalidad.Text.Trim();
                string profesion = txtProfesion.Text.Trim();
                string consulta = "insert into tautor values(@codautor,@apellidos,@nombres,@nacionalidad,@profesion)";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                //envio de parametros
                comando.Parameters.AddWithValue("@codautor", codAutor);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@nombres", nombres);
                comando.Parameters.AddWithValue("@nacionalidad", nacionalidad);
                comando.Parameters.AddWithValue("@profesion", profesion);
                //ejecutar el insert
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    Response.Write("No se agrego");
            }
            catch (Exception ex)
            {

                Response.Write("Error" + ex.Message);
            }
            
        }

        protected void btnEliminarr_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "delete from tautor where codautor ='"+txtCodautor.Text.Trim()+"'";
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1)
                    Listar();
                else
                    Response.Write("error al eliminar");
            }
            catch (Exception ex)
            {

                conexion.Close();
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
            