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
    public partial class fmrPrestamo : System.Web.UI.Page
    {
        Prestamo prestamo = new Prestamo();
        private void Listar()
        {

            gvPrestamo.DataSource = prestamo.Listar();
            gvPrestamo.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Listar();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string codAutor = txtcodautor.Text.Trim();
            string codlibro = txtcodlibro.Text.Trim();
            string fecha = txtfprestamo.Text.Trim();

            if (prestamo.Agregar(codAutor, codlibro, fecha))
                Listar();
            else
                Response.Write("No se agrego");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtfprestamo.Text.Trim();

            gvPrestamo.DataSource = prestamo.Buscar(texto);
            gvPrestamo.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            string codAutor = txtcodautor.Text.Trim();
            string codlibro = txtcodlibro.Text.Trim();
            string fecha = txtfprestamo.Text.Trim();

            if (prestamo.Eliminar(codAutor, codlibro, fecha))
                Listar();
            else
                Response.Write("No se elimino");
        }
    }
}