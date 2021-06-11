using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace MySQProyecto.CapaNegocio
{
    public class Autorr: IAutor
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        
        public bool Actualizar(string codAutor, string Apellidos, string Nombres, string Nacionalidad)
        {
            string consulta = "update TAutor set apellidos=@apellidos,nombres=@nombres,nacionalidad=@nacionalidad where codautor=@codautor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codautor", codAutor);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nombres", Nombres);
            comando.Parameters.AddWithValue("@nacionalidad", Nacionalidad);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1)
                return true;
            else
                return false; ;
        
    }

        public bool Agregar(string codAutor, string Apellidos, string Nombres, string Nacionalidad)
        {
            string consulta = "insert into TAutor values(@codautor,@apellidos,@nombres,@nacionalidad)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codautor", codAutor);
            comando.Parameters.AddWithValue("@apellidos", Apellidos);
            comando.Parameters.AddWithValue("@nombres", Nombres);
            comando.Parameters.AddWithValue("@nacionalidad", Nacionalidad);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1)
                return true;
            else
                return false;
        }

        public DataTable Buscar(string texto)
        {

            string consulta = $"select * from TAutor where codAutor like '%{texto}%' " +
                $"or codlibro like '%{texto}%' " +
                $"or fechaPrestamo like '%{texto}%' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public bool Eliminar(string codAutor)
        {
            string consulta = "delete from TAutor where codautor ='" + codAutor + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else return false;

            }

        public DataTable Listar()
        {
            string consulta = "select *from TAutor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

    }
}