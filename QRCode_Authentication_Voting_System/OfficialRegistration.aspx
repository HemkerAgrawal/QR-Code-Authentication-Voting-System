<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficialRegistration.aspx.cs" Inherits="FingerPrint_Voting_Systen.OfficialRegistration" %>

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
                <h1 class="display-4">FINGERPRINT VOTING SYSTEM</h1>
                <p class="lead">OFFICIAL REGISTRATION FORM</p>
                <br />
                <br />
            </div>
        </div>


        <br />
        <br />
        <center>

        <div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="EMAIL"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" Width="120px" TextMode="Email"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="PASSWORD"></asp:Label>
            &nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="120px" TextMode="Password" ></asp:TextBox>
            <br />
            <br />
        </div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="SUBMIT" />
   
     <div class ="container">
        <div class="modal fade" id ="mymodal" role ="dialog" data-backdrop ="static">
            <div class ="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                <div class ="modal-header">
                    <h4 class ="modal-title">Email Verification</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                       <label>OTP</label>
                        <asp:TextBox ID="otpTextBox" placeholder="Enter OTP" runat="server" TextMode="Password" />
                     <button id="show_password1" class="btn btn-primary" type="button">  
                                <span class="fa fa-eye-slash icon3"></span>  
                            </button>  
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnsave" CssClass="btn btn-primary" Text="OK" runat="server" OnClick="btnsave_Click"/>
                </div>
                    </div>
               </div>
         </div>
    </div>  
            
            </center>
    
    </form>
</body>
</html>
