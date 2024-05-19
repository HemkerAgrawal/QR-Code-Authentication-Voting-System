<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="FingerPrint_Voting_Systen.login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type ="text/javascript">


$("#upload").on('change', function() {
    var file = $(this)[0].files[0];
    if(!file) {//undefined
        return;
    }
    if(!startLoading()) {
        return;
    }
    var file = $(this)[0].files[0];
    var reader = new FileReader();
    reader.readAsDataURL(file); // read file as Data URL
    reader.onload = function() {
        var base64 = this.result;
        //send this base64 string to c# backend page using ajax
        
});

            </script>
    <%--<script type ="text/javascript">
            $("#upload").on('change',function(){
    var file = $(this)[0].files[0];
    if(!file){
        return;
    }
    if(!startLoading()){
        return;
    }
    var file = $(this)[0].files[0];
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function(){
        var base64 = this.result;
    }
};
        </script>--%>





</head>
<body>
    <form id="form1" runat="server">
        <div>


            <input id ="upload" name = "upload" type="file" accept="image/*" />





        </div>
    </form>
</body>
</html>



