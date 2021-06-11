using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using System.Configuration;
using MySql.Data.MySqlClient;

namespace MySQProyecto.CapaNegocio
{
    public class Libro : ILibro
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);
        public bool Actualizar(string codLibro, string titulo, string editorial)
        {
            string consulta = "update TLibro set titulo=@titulo,editorial=@editorial where codlibro=@codlibro";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codlibro", codLibro);
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@editorial", editorial);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else
                return false;
        }
        public bool Agregar(string codLibro, string titulo, string editorial)
        {
            string consulta = "insert into TLibro values(@codlibro,@titulo,@editorial)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codlibro", codLibro);
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@editorial", editorial);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else
                return false;
        }

        
        public DataTable Buscar(string texto, string criterio)
        {
            string consulta = "select *from TAutor where " + criterio + " LIKE '%" + texto + "%'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public bool Eliminar(string codLibro)
        {
            string consulta = "delete from tlibro where codlibro ='" + codLibro+ "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else return false;
        }

        public DataTable Listar()
        {
            string consulta = "select *from TLibro";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
        
    }
}