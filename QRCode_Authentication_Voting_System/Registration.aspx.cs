using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Net.Mail;
using System.Drawing;
using System.Data;
using System.IO;
using static System.Net.WebRequestMethods;
using System.Text;
using System.Configuration;
using QRCoder;
using Image = System.Drawing.Image;
using System.Globalization;

namespace FingerPrint_Voting_Systen
{
    public partial class Registration : System.Web.UI.Page
    {
        SQLiteConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        string pre_path = ConfigurationManager.AppSettings["proj_path"].ToString();
        static string pass, photo, otp;
        int age;

    //static var x;
    //Env filename;
    //  //    string pre_path2 = ConfigurationManager.AppSettings["sign_path"].ToString();
    protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            bool checkValueOTP;
            checkValueOTP = checkOTP();
            
            if (checkValueOTP == true)
            {
                //   try
                //  {
                getqr();
                SendEmail();
                con.Open();
                    SQLiteCommand cmd = new SQLiteCommand("insert into registration values(@name,@email,@dob,@phone,@fp,@address,@qr,@id,@vote,@extra1)", con);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@email", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@dob", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@phone", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@fp", age);
                    cmd.Parameters.AddWithValue("@address", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@qr", "0");
                    cmd.Parameters.AddWithValue("@id", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@vote", "0");
                    cmd.Parameters.AddWithValue("@extra1", "0");
                   

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
                //}
                //catch
                //{
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Please try again.', 'error')", true);
                //}
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Wrong OTP. Please try again.', 'error')", true);

                //   ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Error', 'Wrong OTP. Please try again.', 'error').then(function() { window.location ='Registration.aspx'});", true);
            }
        }

        private void SendEmail()
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
            string mailbody = "Hello " + TextBox1.Text + " This is your QR Code";
            message.Subject = "QR Code" ;
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
                    "swal('Success','Successfully Registered', 'success');", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getqr()
        {
//            string only_path_original = pre_path + "/" + TextBox2.Text + "/";
            string only_path_original = pre_path + TextBox2.Text + "/";

            if (!Directory.Exists(only_path_original))
            {
                Directory.CreateDirectory(only_path_original);
            }

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(TextBox2.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            var x = code.GetGraphic(5);
            // var filename = pre_path + "/" + y;
            //  var filename = pre_path + "/" + (TextBox2.Text + ".jpg"); //filename;
            var filename = pre_path + (TextBox2.Text + ".jpg");
            x.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            photo = filename; // + Path.GetFileName(FileUpload1.PostedFile.FileName);

        }

        private void clean()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime birthdate = DateTime.ParseExact(TextBox3.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime currentDate = DateTime.Now;
            age = currentDate.Year - birthdate.Year;

            // Check if the birthdate has occurred this year
            if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
            {
                age--;
            }
            if (TextBox1.Text != null && TextBox2.Text != null && TextBox3.Text != null && TextBox4.Text != null &&  age >= 18 && TextBox4.Text.Length == 10)
            {
                

                    try
                    {
                        // SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\ishee\source\repos\DocTool\DocTool\bin\dbase.db;Version=3;New=False;Compress=True;");
                        con.Open();

                        SQLiteCommand cmd2 = new SQLiteCommand("select * from registration where email like '" + TextBox2.Text + "'", con);
                        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count == 0)
                        {
                           // pass = TextBox4.Text;


                            //int imagefilelenth = FileUpload1.PostedFile.ContentLength;
                            //byte[] imgarray = new byte[imagefilelenth];
                            //HttpPostedFile image = FileUpload1.PostedFile;
                            //image.InputStream.Read(imgarray, 0, imagefilelenth);
                            //image.SaveAs(pre_path2 + TextBox2.Text.Replace('.', 'a') + Path.GetFileName(FileUpload1.PostedFile.FileName));
                            //photo = "~/Image/" + TextBox2.Text.Replace('.', 'a') + Path.GetFileName(FileUpload1.PostedFile.FileName);
                            //   photo = getsign();
                            //string fp = Server.MapPath(photo);
                            //Bitmap source = new Bitmap(fp);
                            //    source.MakeTransparent();
                            //    for (int wid = 0; wid < source.Width; wid++)
                            //    {
                            //        for (int hei = 0; hei < source.Height; hei++)
                            //        {
                            //            Color currentColor = source.GetPixel(wid, hei);
                            //            if (currentColor.R >= 220 && currentColor.G >= 220 && currentColor.B >= 220)
                            //            {
                            //                source.SetPixel(wid, hei, Color.Transparent);
                            //            }
                            //        }
                            //    }
                            //    source.Save(fp);
                            sendOTP();
                            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowMyPopup()", true);
                        }

                        else
                        {
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Invalid Email', 'Voter already exists.', 'error')", true);
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
                ClientScript.RegisterClientScriptBlock(this.GetType(), "k", "swal('Empty Field', 'Please fill all the fields correctly.', 'warning')", true);
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
    }
}