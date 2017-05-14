<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="sgBarb.View.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login </title>
    <link href="../Scripts/css/bootstrap.min.css" rel="stylesheet">
    <link href="../Scripts/css/singin.css" rel="stylesheet">
    </head>
<body>
    <form id="form1" runat="server">

        <div class="container">

            <div class="form-signin">
                <h2 class="form-signin-heading">Tela de Login</h2>
                <label for="inputEmail" class="sr-only">Login</label>
                <asp:TextBox ID="txtUsuario" type="text" cssClass="form-control" placeholder="Usuário " runat="server" required autofocus></asp:TextBox>
                <label for="inputPassword" class="sr-only">Password</label>
                <asp:TextBox ID="txtSenha" type="password" cssClass="form-control" placeholder="Senha " runat="server" required></asp:TextBox>
                <asp:Button class="btn btn-lg btn-primary btn-block" type="submit" ID="btnLogin" runat="server" Text="Logar" OnClick="btnLogin_Click" />
            </div>

        </div>
    </form>
    <script src="../Scripts/js/jquery-3.1.1.js"></script>
    <script src="../Scripts/js/bootstrap.min.js"></script>
</body>
</html>
