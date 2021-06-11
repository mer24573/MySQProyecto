<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fmrAutor.aspx.cs" Inherits="MySQProyecto.fmrAutor" %>

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
            <p>Apellidos: <asp:TextBox runat="server" ID="txtapellidos" /> </p>
            <p>Nombres: <asp:TextBox runat="server" ID="txtnombres" /> </p>
            <p>Nacionalidad: <asp:TextBox runat="server" ID="txtnacionalidad" /> </p>
            <p>Buscar: <asp:TextBox runat="server" ID="txtBuscar" /> </p>
            <p>
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click"  />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminarr" OnClick="btnEliminarr_Click"  />
                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click" />
                

            </p>
            <asp:GridView runat="server" ID="gvAutor" ></asp:GridView>
            
            
        </div>
    </form>
</body>
</html>
