<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fmrPrestamo.aspx.cs" Inherits="MySQProyecto.fmrPrestamo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>CodAutor: <asp:TextBox runat="server" ID="txtcodautor" /> </p>
            <p>CodLibro: <asp:TextBox runat="server" ID="txtcodlibro" /> </p>
            <p>FechaPrestamo: <asp:TextBox runat="server" ID="txtfprestamo" /> </p>
            <p>Buscar: <asp:TextBox runat="server" ID="txtBuscar" /> </p>
            
            <p>
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click"  />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminarr"  />
                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" />
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click"  />

            </p>
            <asp:GridView runat="server" ID="gvPrestamo" ></asp:GridView>
        </div>
    </form>
</body>
</html>
