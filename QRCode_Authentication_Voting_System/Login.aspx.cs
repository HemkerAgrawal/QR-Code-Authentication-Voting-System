using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Threading;
using System.Configuration;
using System.Runtime;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Media.Media3D;
using Size = System.Drawing.Size;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace FingerPrint_Voting_Systen
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Visible = false;      



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "Admin" && TextBox2.Text == "Admin")
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                if (TextBox1.Text != "" && TextBox2.Text != "")
                {
                    Label1.Text = "Wrong Credentials";
                    Label1.Visible = true;
                    
                }
                else
                {
                    Label1.Text = "Please Fill required Text Box";
                    Label1.Visible = true;
                }
            }
        }
    }
}
