<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="FingerPrint_Voting_Systen.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="Content/Style1.css" rel="stylesheet" />
     <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.7.1.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="jumbotron jumbotron-fluid j">
            <div class="container">
                <br />
                <br />
                <h1 class="display-4"><b>VOTING SYSTEM</b></h1>
                <p class="lead"><h2>MENU FORM</h2></p>
                <br />
                <br />
            </div>
        </div>
        </div>

           <div>
            <center>
        <br />
        <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Voter Registration" Width="220px" height="50px" class="btn btn-primary"/>
        <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Start/Stop Voting Process" Width="220px" height="50px" class="btn btn-primary"/>
        <br />
                <br />
                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Candidate Registration" Width="220px" height="50px" class="btn btn-primary"/>
        <br />
                <br />
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="View Final Results" Width="220px" height="50px" class="btn btn-primary"/>
                </center>
               </div>
    </form>
</body>
</html>
