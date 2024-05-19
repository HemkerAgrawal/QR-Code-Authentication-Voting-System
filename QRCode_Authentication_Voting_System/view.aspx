
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="view.aspx.cs" Inherits="FingerPrint_Voting_Systen.view" %>

<!DOCTYPE html>

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

      
</head>
<body>
    <form id="form1" runat="server">




        <div class="jumbotron jumbotron-fluid j">
            <div class="container">
                <br />
                <br />
                <h1 class="display-4"><b>VOTING SYSTEM</b></h1>
                <p class="lead"><h2>DISPLAY CANDIDATES</h2></p>
                <br />
                <br />
            </div>
        </div>
        <br />
        <br />

        <center>

        <div>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="VIEW" Width="175px" Visible="False" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="VIEW" Width="175px" Visible =" False" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" OnRowDataBound="GridView1_RowDataBound" Width="478px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Visible="false">
            </asp:GridView>
            <asp:Label ID="Label6" runat="server" Text="Label" Visible ="False"></asp:Label>
        </div>
     <%-- <asp:DataList ID="ImageDataList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("ImageData")) %>' />
                </ItemTemplate>
            </asp:DataList>--%>

        <asp:DataList ID="DataList1" runat="server" Height="543px" Width="363px">
            <ItemTemplate>
                 <table class="auto-style5" >
                       <caption>
                           <center>
                           <hr width="363px">
                           <tr>
                               <td class="auto-style4" rowspan="7">
                                   <br />
                                                       <asp:ImageButton ID="ImageButton1" runat="server" Height="100px" Width="150px" ImageUrl='<%# Eval("extra1") %>' />
                                   <br />

                                 <%--  <asp:Label ID="Label62" runat="server" Text="<%# Eval("customerid") %>"></asp:Label>--%>
                               </td>

                               <td colspan="2">
                                   <asp:Label ID="Label3" runat="server" Font-Size="Large" Visible="false" Text='<%# Eval("extra1") %>'></asp:Label>
                               </td>

                                <td colspan="2">
                                   <asp:Label ID="Label4" runat="server" Font-Size="Large" Text='<%# Eval("name") %>'></asp:Label>
                               </td>

                                <td colspan="2">
                                   <asp:Label ID="Label5" runat="server" Font-Size="Large" Text='<%# Eval("count") %>' Visible="False"></asp:Label>
                               </td>
                               </tr>
                               </center>
                               </caption>
                    </table>
</ItemTemplate>


        </asp:DataList>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>

            </center>
    </form>
</body>
</html>
