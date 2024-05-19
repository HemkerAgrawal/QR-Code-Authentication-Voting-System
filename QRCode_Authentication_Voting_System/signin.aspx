<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signin.aspx.cs" Inherits="FingerPrint_Voting_Systen.signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>



</head>
<body>
    <form id="form1" runat="server">

        <h1>Camera Access Form</h1>
        <div>
            <video id="camera-feed" style="width: 100%"></video>
            <button id="start-camera">Start Camera</button>
        </div>
    </form>
    <script>
        const videoElement = document.getElementById("camera-feed");
        const startButton = document.getElementById("start-camera");

        startButton.addEventListener("click", async () => {
            try {
                const stream = await navigator.mediaDevices.getUserMedia({ video: true });
                videoElement.srcObject = stream;
            } catch (error) {
                console.error("Error accessing the camera: " + error);
            }
        });
    </script>


        
   <!-- </form> -->
</body>
</html>
