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
    public partial class fmrAutor : System.Web.UI.Page
    {

        private CapaNegocio.Autorr autorr = new CapaNegocio.Autorr();
        private void Listar()
        {

            gvAutor.DataSource = autorr.Listar();
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
                string codAutor = txtcodautor.Text.Trim();
                string Apelldios = txtapellidos.Text.Trim();
                string Nombres = txtnombres.Text.Trim();
                string Nacionalidad = txtnacionalidad.Text.Trim();

                if (autorr.Agregar(codAutor, Apelldios, Nombres, Nacionalidad))
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
            string codautor =txtcodautor .Text.Trim();

            if (autorr.Eliminar(codautor))
                Listar();
            else
                Response.Write("No se agrego");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string codAutor = txtcodautor.Text.Trim();
            string Apelldios = txtapellidos.Text.Trim();
            string Nombres = txtnombres.Text.Trim();
            string Nacionalidad = txtnacionalidad.Text.Trim();

            if (autorr.Agregar(codAutor, Apelldios, Nombres, Nacionalidad))
                Listar();
            else
                Response.Write("No se agrego");

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtcodautor.Text.Trim();

            gvAutor.DataSource = autorr.Buscar(texto);
            gvAutor.DataBind();
        }
    }
}