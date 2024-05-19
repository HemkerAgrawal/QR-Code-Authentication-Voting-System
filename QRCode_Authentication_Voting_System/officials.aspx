﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="officials.aspx.cs" Inherits="FingerPrint_Voting_Systen.officials" %>

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


       <script type="text/javascript">  
        $(document).ready(function () {  
            $('#show_password').hover(function show() {  
                //Change the attribute to text  
                $('#TextBox4').attr('type', 'text');  
                $('.icon').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
            },  
            function () {  
                //Change the attribute back to password  
                $('#TextBox4').attr('type', 'password');  
                $('.icon').removeClass('fa fa-eye').addClass('fa fa-eye-slash');  
            });  
            //CheckBox Show Password  
            $('#ShowPassword').click(function () {  
                $('#Password').attr('type', $(this).is(':checked') ? 'text' : 'password');  
            });  
        });  
    </script>
    

      <script type="text/javascript">
          function ShowMyPopup() {
              /*$("#MyPopup").show();*/
              $("#mymodal").modal("show");
          };
      </script>

    <%--<script type="text/javascript">
        function ShowPopup(title, body) {
            $("#MyPopup .modal-title").html(title);
            $("#MyPopup .modal-body").html(body);
            $("#MyPopup").modal("show");
        };
    </script>--%>


     <script type="text/javascript">  
         $(document).ready(function () {
             $('#show_password0').hover(function show() {
                 //Change the attribute to text  
                 $('#TextBox5').attr('type', 'text');
                 $('.icon2').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
             },
                 function () {
                     //Change the attribute back to password  
                     $('#TextBox5').attr('type', 'password');
                     $('.icon2').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                 });
         });
     </script> 


      <script type="text/javascript">  
          $(document).ready(function () {
              $('#show_password1').hover(function show() {
                  //Change the attribute to text  
                  $('#otpTextBox').attr('type', 'text');
                  $('.icon3').removeClass('fa fa-eye-slash').addClass('fa fa-eye');
              },
                  function () {
                      //Change the attribute back to password  
                      $('#otpTextBox').attr('type', 'password');
                      $('.icon3').removeClass('fa fa-eye').addClass('fa fa-eye-slash');
                  });
          });
      </script>


</head>
<body>
    <form id="form1" runat="server">

        <div class="jumbotron jumbotron-fluid j">
            <div class="container">
                <br />
                <br />
                <h1 class="display-4"><b>VOTING SYSTEM</b></h1>
                <p class="lead"><h2>OFFICIAL FORM</h2></p>
                <br />
                <br />
            </div>
        </div>

        <br />
        <br />


        <div>
            <center>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="START" Width="150px" height="50px" class="btn btn-primary"/>
                <br />
                <br />

            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="STOP" Width="150px" height="50px" class="btn btn-primary"/>
                <br />
                <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="RESULT" Width="150px" height="50px" class="btn btn-primary"/>

                <br />
                <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
         
            <asp:GridView ID="GridView2" runat="server" Visible="False">
            </asp:GridView>
         
            <asp:GridView ID="GridView1" runat="server" Visible="false">
            </asp:GridView>
            

                

                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="PARTY " Font-Bold="True" Font-Size="20pt"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text="NAME" Font-Bold="True" Font-Size="20pt"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="COUNT" Font-Bold="True" Font-Size="20pt"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            

                

               <asp:DataList ID="DataList1" runat="server">
            
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
                                   <asp:Label ID="Label4" runat="server" Font-Size="Large" Text='<%# Eval("name") %>'></asp:Label>
                               </td>

                                <td colspan="2">
                                   <asp:Label ID="Label5" runat="server" Font-Size="Large" Text='<%# Eval("count") %>'></asp:Label>
                               </td>
                               <td colspan="2">
                                   <asp:Label ID="Label3" runat="server" Font-Size="Large" visible="false" Text='<%# Eval("extra1") %>'></asp:Label>
                               </td>
                               </tr>
                               </center>
                               </caption>
                    </table>
</ItemTemplate>
               </asp:DataList>
                </center>
            
        <p>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>

            <div class ="container">
        <div class="modal fade" id ="mymodal" role ="dialog" data-backdrop ="static">
            <div class ="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                <div class ="modal-header">
                    <h4 class ="modal-title">Email Verification</h4>
                </div>
                <div class="modal-body">
                       <label>OTP</label>
                        <asp:TextBox ID="otpTextBox" placeholder="Enter OTP" runat="server" TextMode="Password" />
                   
                </div>
                <div class="modal-footer">
        </div>
                    </div>
               </div>
         </div>
    </div>



        </div>
    </form>
</body>
</html>
