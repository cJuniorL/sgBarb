<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewImagem.aspx.cs" Inherits="sgBarb.View.viewImagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Visualizar Fotos</h1>
    <% 
        List<sgBarb.Model.Foto> lstFoto = sgBarb.Dal.FotoDal.select();
        for (int i = 0; i < lstFoto.Count; i++)
        {
            if (i % 3 == 0)
            {
                if (i != 0)
                    Response.Write("</div>");
                Response.Write("<div class=\"card-columns\">");
            }
            Response.Write("<div class=\"card\">");
            Response.Write("  <img class=\"card-img-top\" src=\"../CliImagens/" + lstFoto[i].imagem + "\">");
            Response.Write("  <h4 class=\"card-title\"> " + sgBarb.Dal.ClienteDAL.selectById(lstFoto[i].clienteID).nome + "</h4>");
            Response.Write(" <p class=\"card-text\">" + lstFoto[i].data.ToShortDateString() + "</p>");
            Response.Write("</div>");
        }
        if (lstFoto.Count > 0)
        {
            Response.Write("</div>");
        }
    %>
    <div class="col-12">
        <div class="col-4">
            <div class="card" style="width: 20rem;">
                <img class="card-img-top" src="../CliImagens/hqdefault.jpg" alt="Card image cap">

                <div class="card-block">
                    <h4 class="card-title">Carlos Roberto</h4>
                    <p class="card-text">29/04/1997</p>
                </div>
            </div>
        </div>
        <div class="col-4">
            <div class="card" style="width: 20rem;">
                <img class="card-img-top" src="../CliImagens/hqdefault.jpg" alt="Card image cap">

                <div class="card-block">
                    <h4 class="card-title">Carlos Roberto</h4>
                    <p class="card-text">29/04/1997</p>
                </div>
            </div>
        </div>
        <div class="col-4">
            <div class="card" style="width: 20rem;">
                <img alt="Card image cap" class="card-img-top" src="../CliImagens/hqdefauhttp://localhost:55133/CliImagens/hqdefault.jpglt.jpg">

                <div class="card-block">
                    <h4 class="card-title">Carlos Roberto</h4>
                    <p class="card-text">29/04/1997</p>
                </div>
            </div>
        </div>
    </div>

    <br />

</asp:Content>
