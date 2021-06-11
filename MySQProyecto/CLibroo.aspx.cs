using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySQProyecto.CapaNegocio;

namespace MySQProyecto
{
    public partial class CLibroo : System.Web.UI.Page
    {
        private CapaNegocio.Libro libro = new CapaNegocio.Libro();
        private void Listar()
        {
            gvLibro.DataSource = libro.Listar();
            gvLibro.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();


        }
        protected void btnEliminarr_Click(object sender, EventArgs e)
        {
            string codlibro = txtcodLibro.Text.Trim();

            if (libro.Eliminar(codlibro))
                Listar();
            else
                Response.Write("No se agrego");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string codlibro = txtcodLibro.Text.Trim();
            string titulo = txttitulo.Text.Trim();
            string editorial = txteditorial.Text.Trim();

            if (libro.Actualizar(codlibro, titulo, editorial))
                Listar();
            else
                Response.Write("No se agrego");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string codlibro = txtcodLibro.Text.Trim();
                string titulo = txttitulo.Text.Trim();
                string editorial = txteditorial.Text.Trim();

                if (libro.Agregar(codlibro, titulo, editorial))
                    Listar();
                else
                    Response.Write("No se agrego");

            }
            catch (Exception ex)
            {

                Response.Write("Error" + ex.Message);
            }
        }
    }
}
