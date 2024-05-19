<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FingerPrint_Voting_Systen.Login" %>

<!DOCTYPE html>
<!--<meta charset="utf-8">
    <meta http-equiv="x-ua-compatible" content="ie=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">-->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title></title>

     <link href="Content/Style1.css" rel="stylesheet" />
     <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.0/sweetalert.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.7.0/jquery.min.js" integrity="sha512-3gJwYpMe3QewGELv8k/BX9vcqhryRdzRMxVfq6ngyWXwo03GFEzjsUm8Q7RZcHPHksttq7/GFoxjCVUjkjvPdw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/4.6.2/js/bootstrap.min.js" integrity="sha512-7rusk8kGPFynZWu26OKbTeI+QPoYchtxsmPeBqkHIEXJxeun4yJ4ISYe7C6sz9wdxeE1Gk3VxsIWgCZTc+vX3g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>


    
    
    <%--<link rel="stylesheet" href="Content/Styles.css">--%>

   



</head>
<body>





    



    <form id="form1" runat="server">
        <div>
            <div class="jumbotron jumbotron-fluid j">
            <div class="container">
                <br />
                <br />
                <h1 class="display-4"><b>VOTING SYSTEM</b></h1>
                <p class="lead"><h2>ELECTION OFFICIAL LOGIN FORM</h2></p>
                <br />
                <br />
            </div>
        </div>


   

        </div>
        <br />
        <br />
        <center>
            <asp:Label ID="Label2" runat="server" Text="USERNAME"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TextBox1" runat="server" placeholder="USERNAME"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="PASSWORD"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" placeholder="PASSWORD" TextMode="Password"></asp:TextBox>

            <br />
            <br />
            <br />

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SUBMIT" />

            <br />
            <br />
            <br />
            <br />

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </center>

    </form>
</body>
</html>
