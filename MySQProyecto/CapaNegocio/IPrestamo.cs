using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MySQProyecto.CapaNegocio
{
    interface IPrestamo
    {
        DataTable Listar();
        bool Agregar(string codAutor, string codLibro, string fecharegistro);
        bool Eliminar(string codAutor, string codLibro, string fecharegistro);
        bool Actualizar(string codAutor, string codLibro, string fecharegistro);
        DataTable Buscar(string texto);
    }
}
