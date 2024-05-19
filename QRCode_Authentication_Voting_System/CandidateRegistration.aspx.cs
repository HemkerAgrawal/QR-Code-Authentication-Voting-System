using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using ZXing;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace FingerPrint_Voting_Systen
{
    public partial class CandidateRegistration : System.Web.UI.Page
    {
        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        string pre_path = ConfigurationManager.AppSettings["proj_path"].ToString();
        static string otp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getmail();
            }
            
            Label4.Visible = false;
            TextBox4.Visible = false;
            Label5.Visible = false;
            TextBox5.Visible = false;
            TextBox3.Visible = false;
        }

        

            private void getmail()
        {
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select name from party", con);
            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "name";
            DropDownList1.DataValueField = "name";
            DropDownList1.DataBind();
            DropDownList1.Items.Remove(DropDownList1.Items.FindByValue("NOTA"));

            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null && TextBox2.Text != null && TextBox6.Text != null && DropDownList1.Text != null)
            {


                try
                {
                   
                    // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\DocTool\DocTool\bin\dbase.db;Version=3;New=False;Compress=True;");
                    con.Open();

                    SQLiteCommand cmd2 = new SQLiteCommand("select * from vote where email like '" + TextBox2.Text + "'", con);
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        SQLiteCommand cmd3 = new SQLiteCommand("select * from vote where party like '" + DropDownList1.Text + "'", con);
                        SQLiteDataAdapter sda2 = new SQLiteDataAdapter(cmd3);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);
                        if (dt2.Rows.Count == 0 || DropDownList1.Text == "INDEPENDENT")
                        {
                            sendOTP();
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMyPopup()", true);
                        }
                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Party already exists.', 'error')", true);
                            clean();
                        }
                    }

                    else
                    {
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Invalid Email', 'Candidate already exists.', 'error')", true);
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
            string to = TextBox2.Text; //To address    
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
        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool checkValueOTP;
            checkValueOTP = checkOTP();

            if (checkValueOTP == true)
            {
                try
                {
                    con.Open();
                    SQLiteDataAdapter csda = new SQLiteDataAdapter("select file from party where name like '" + DropDownList1.Text + "'", con);
                    DataTable qdt = new DataTable();

                    /*     string selectSql = "select file from party where name like '" + DropDownList1.Text + "'";

                         SqlCommand acmd = new SqlCommand(selectSql);

                         try
                         {
                             con.Open();

                             using (SqlDataReader read = acmd.ExecuteReader())
                             {
                                 while (read.Read())
                                 {
                                     TextBox5.Text = (read["file"].ToString());

                                 }
                             }
                         }
                         catch { }  */
                    //   cdcon.Close();



                    csda.Fill(qdt);

                    if (qdt.Rows.Count > 0)
                    {
                        TextBox5.Text = qdt.Rows[0]["file"].ToString();

                    }

                    
                    

                        SQLiteCommand cmd = new SQLiteCommand("insert into vote values(@id,@name,@email,@party,@count,@extra1)", con);

                        cmd.Parameters.AddWithValue("@id", TextBox6.Text);
                        cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@email", TextBox2.Text);
                        cmd.Parameters.AddWithValue("@party", DropDownList1.Text);
                        cmd.Parameters.AddWithValue("@count", 0);
                        cmd.Parameters.AddWithValue("@extra1", TextBox5.Text);
                        //  cmd.Parameters.AddWithValue("@qr", photo);
                        //  cmd.Parameters.AddWithValue("@id", TextBox2.Text);
                        // cmd.Parameters.AddWithValue("@vote", "0");
                        //    getqr();



                        //                    SendEmail();

                        int k = cmd.ExecuteNonQuery();
                        if (k != 0)
                        {

                            sendid();
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                            "swal('Success','Registered Successfully!', 'success').then(function() { window.location ='CandidateRegistration.aspx'});", true);


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

        private void sendid()
        {
            string mail = TextBox2.Text;  //dt2.Rows[0][0].ToString();
            Random rnd = new Random();
            string rdnum = (rnd.Next(10000, 99999)).ToString();

            //      string filePath = pre_path + "/" + (TextBox2.Text + ".jpg");
            //  var filename = pre_path + "/" + (TextBox2.Text + ".jpg");
            string to = mail; //To address    
            string from = "emailmkagr@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);
            string mailbody = "Hello " + TextBox1.Text + " This is your ID: CDID"+rdnum;
            message.Subject = "Candidate ID";
            message.Body = mailbody;
         //   Attachment attachment = new Attachment(filePath);
         //   attachment.ContentDisposition.FileName = TextBox2.Text + ".jpg"; //ddl1.SelectedItem.Text;
          //  message.Attachments.Add(attachment);
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("emailmkagr@gmail.com", "nvznyoilfgmtssjg");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                    "swal('Success','Successfully Registered', 'success');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*   private void SendEmail()
           { 

               //  SQLiteCommand cmd2 = new SQLiteCommand("select email from tab1 where name in (select startby from tab3 where pathdoc like '" + ddl1.SelectedValue + "')", con);


               // SQLiteDataAdapter sda2 = new SQLiteDataAdapter(cmd2);
               //DataTable dt2 = new DataTable();
               //sda2.Fill(dt2);
               string mail = TextBox2.Text;  //dt2.Rows[0][0].ToString();

               string filePath = pre_path + "/" + (TextBox2.Text + ".jpg");
               //  var filename = pre_path + "/" + (TextBox2.Text + ".jpg");
               string to = mail; //To address    
               string from = "emailmkagr@gmail.com"; //From address    
               MailMessage message = new MailMessage(from, to);
               string mailbody = "Hello " + TextBox2.Text + "This is your QR Code";
               message.Subject = "QR Code";
               message.Body = mailbody;
               Attachment attachment = new Attachment(filePath);
               attachment.ContentDisposition.FileName = TextBox2.Text + ".jpg"; //ddl1.SelectedItem.Text;
               message.Attachments.Add(attachment);
               message.BodyEncoding = Encoding.UTF8;
               message.IsBodyHtml = true;
               SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
               System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("emailmkagr@gmail.com", "nvznyoilfgmtssjg");
               client.EnableSsl = true;
               client.UseDefaultCredentials = false;
               client.Credentials = basicCredential1;
               try
               {
                   client.Send(message);
                   ClientScript.RegisterClientScriptBlock(this.GetType(), "k",
                       "swal('Success','Document signed', 'success');", true);

               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
        */
        private void clean()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}