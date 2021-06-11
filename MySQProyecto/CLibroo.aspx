<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CLibroo.aspx.cs" Inherits="MySQProyecto.CLibroo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>CodLibro: <asp:TextBox runat="server" ID="txtcodLibro" /> </p>
            <p>Titulo: <asp:TextBox runat="server" ID="txttitulo" /> </p>
            <p>Editorial: <asp:TextBox runat="server" ID="txteditorial" /> </p>
            <p>Buscar: <asp:TextBox runat="server" ID="txtBuscar" /> </p>
            <p>
                <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click"    />
                <asp:Button Text="Eliminar" runat="server" ID="btnEliminarr" OnClick="btnEliminarr_Click"  />
                <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" OnClick="btnActualizar_Click" />
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" OnClick="btnBuscar_Click"  />

            </p>
            <asp:GridView runat="server" ID="gvLibro" ></asp:GridView>
            
           
        </div>
    </form>
</body>
</html>
