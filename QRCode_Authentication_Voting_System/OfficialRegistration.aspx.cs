using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using static System.Net.WebRequestMethods;
using System.Net.Mail;
using System.Text;
using System.Drawing.Drawing2D;
using System.Windows;

namespace FingerPrint_Voting_Systen
{
    public partial class OfficialRegistration : System.Web.UI.Page
    {

        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        string pre_path = ConfigurationManager.AppSettings["proj_path"].ToString();
        static string pass, photo, otp;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool checkValueOTP;
            checkValueOTP = checkOTP();

            if (checkValueOTP == true)
            {
                try
                {
                    con.Open();
                    SQLiteCommand cmd = new SQLiteCommand("insert into official values(@name,@password,@extra1)", con);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@extra1", "0");


                    //getqr();
                   // SendEmail();

                    int k = cmd.ExecuteNonQuery();
                    if (k != 0)
                    {


                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('Success','Registered Successfully!', 'success').then(function() { window.location ='Registration.aspx'});", true);


                    }
                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                        "swal('Error','Please try again.','error')", true);
                    }
                    con.Close();
                }
                catch
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Please try again.', 'error')", true);
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Wrong OTP. Please try again.', 'error').then(function() { window.location ='Registration.aspx'});", true);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null)
            {


                try
                {
                    // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\DocTool\DocTool\bin\dbase.db;Version=3;New=False;Compress=True;");
                    con.Open();

                    SQLiteCommand cmd2 = new SQLiteCommand("select * from official where name like '" + TextBox1.Text + "'", con);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        
                        sendOTP();
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMyPopup()", true);
                    }

                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Invalid Email', 'Official already exists.', 'error')", true);
                        clean();
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Please try again.', 'error')", true);
                }

            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Empty Field', 'Please fill all the fields.', 'warning')", true);
            }
        }

        private void clean()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
         //   TextBox3.Text = "";
        }
        private bool checkOTP()
        {
            if (otpTextBox.Text == otp)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void sendOTP()
        {
            Random rnd = new Random();
            string rdnum = (rnd.Next(10000, 99999)).ToString();
            otp = rdnum;
            string to = TextBox1.Text; //To address    
            string from = "emailmkagr@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = "Hello! " + TextBox1.Text + ",\n\n\n\n" + "Your OTP is " + rdnum;
            message.Subject = "OTP for sign up";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("emailmkagr@gmail.com", "nvznyoilfgmtssjg");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}