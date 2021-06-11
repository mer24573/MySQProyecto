using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MySQProyecto.CapaNegocio
{
    public class Prestamo : IPrestamo
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString;
        private static MySqlConnection conexion = new MySqlConnection(cadena);

        public bool Actualizar(string codAutor, string codLibro, string fecharegistro)
        {
            string consulta = "update TPrestamo set codLibro=@codLibro,fechaPrestamo=@fecha where codautor=@codautor";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codAutor", codAutor);
            comando.Parameters.AddWithValue("@codLibro", codLibro);
            comando.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecharegistro));
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else
                return false;
        }

        public bool Agregar(string codAutor, string codLibro, string fecharegistro)
        {
            string consulta = "insert into TPrestamo values(@codAutor,@codLibro,@fecha)";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@codAutor", codAutor);
            comando.Parameters.AddWithValue("@codLibro", codLibro);
            comando.Parameters.AddWithValue("@fecha", Convert.ToDateTime(fecharegistro));
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else
                return false;
        }

        public DataTable Buscar(string texto)
        {
            string consulta = $"select * from tprestamo where codAutor like '%{texto}%' " +
                $"or codlibro like '%{texto}%' " +
                $"or fechaPrestamo like '%{texto}%' ";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }

        public bool Eliminar(string codAutor, string codLibro, string fecharegistro)
        {
            string consulta = "delete from tPrestamo where codAutor='" + codAutor + "' and codLibro='" + codLibro + "' and fechaPrestamo='" + Convert.ToDateTime(fecharegistro) + "'";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            conexion.Open();
            byte i = Convert.ToByte(comando.ExecuteNonQuery());
            conexion.Close();
            if (i == 1) return true;
            else return false;
        }

        public DataTable Listar()
        {
            string consulta = "select *from TPrestamo";
            MySqlCommand comando = new MySqlCommand(consulta, conexion);
            MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            return tabla;
        }
    }
}