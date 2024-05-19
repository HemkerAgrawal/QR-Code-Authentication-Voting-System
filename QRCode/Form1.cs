using AForge.Video.DirectShow;
using AForge.Video;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ZXing;
using System.Net.Http;
using System.Security.Policy;
using System.Net.Http.Headers;
using System.Reflection;
using System.Diagnostics;

namespace FingerPrint
{
    public partial class Form1 : Form
    {

        FilterInfoCollection CaptureDevice;
        VideoCaptureDevice FinalFrame;
        static HttpClient client = new HttpClient();
        Result result = null;
       // static int flag = 0;
        
        // Put the following code where you want to initialize the class
        // It can be the static constructor or a one-time initializer
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
         //   textBox1.Visible = false;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in CaptureDevice)
            {
                device.Items.Add(Device.Name);
            }
            device.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            pictureBox1.Visible = true;
            //    string url = "https://localhost:7025/api/Value?id=hemkeragrawal@gmail.com";
           // string url = "https://balancer.in/VotingApi/api/Value?id=hemkeragrawal@gmail.com";


            // Form2 f2 = new Form2(); // Instantiate a Form3 object.


            // GetRESTData("http://localhost:28642/api/platypi/1/42");
            //  string url2 = "https://localhost:7025/api/Value";
            // GetRESTData2(url2);
            //            GetRESTData(url);
            FinalFrame = new VideoCaptureDevice(CaptureDevice[device.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += new NewFrameEventHandler(captureDevice_NewFrame);
            FinalFrame.Start();
            timer2.Enabled = true;
            timer2.Start();
          

        }

     

        private async Task<List<ClassMail>> GetApiData()
        {
             string apiUrl = "https://localhost:7025/api/Value?id=" + result.ToString();//textBox1.Text.ToString();
         // main  string apiUrl = "https://balancer.in/VotingApi/api/Value?id=" + result.ToString();//textBox1.Text.ToString();
               
            
            
            
            
            //  string apiUrl = "https://localhost:7025/api/Value?id=isheetaagrawal@gmail.com"; // Replace with your API endpoint URL

            //    string apiUrl = "https://balancer.in/VotingApi/api/Value?id=" + textBox1.Text.ToString();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        List<ClassMail> data = await response.Content.ReadAsAsync<List<ClassMail>>();
                        return data;   
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve data from the API.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<ClassMail>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<ClassMail>();
                }
            }
        }

        private void GetRESTData2(string url2)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url2);
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                MessageBox.Show(webRequest.ToString());
                MessageBox.Show(webResponse.ToString());
                if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                {
                    var reader = new StreamReader(webResponse.GetResponseStream());
                    string s = reader.ReadToEnd();
                    var arr = JsonConvert.DeserializeObject<JArray>(s);
                    dataGridView1.DataSource = arr;
                }
                else
                {
                    MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    
        private void captureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private async void GetRESTData(string uri)
        {


        /*   // client.BaseAddress = new Uri("http://localhost:4354/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
          //  var response = await client.GetAsync(uri);
            var response = await client.GetStringAsync(uri);
            var data = JsonConvert.DeserializeObject(response);
            MessageBox.Show(data.ToString());
          //  this.productBindingSource.DataSource = data;*/
             try
             {
                 var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                 var webResponse = (HttpWebResponse)webRequest.GetResponse();
               //  MessageBox.Show(webResponse.ContentLength.ToString());
                // MessageBox.Show(webResponse.ToString());
                 if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength != 0))
                 {
                     //var reader = new StreamReader(webResponse.GetResponseStream());
                     //string s = reader.ReadToEnd();
                     //MessageBox.Show(s);
                     var reader = new StreamReader(webResponse.GetResponseStream());
                     string s = reader.ReadToEnd();
                     var arr = JsonConvert.DeserializeObject<string[]>(s);
                     //  var arr = JsonConvert.DeserializeObject<JArray>(s);
                     dataGridView1.DataSource = arr;
                 }
                 else
                 {
                     MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }

            /* try
             {
                 var webRequest = (HttpWebRequest)WebRequest.Create(uri);
                 var webResponse = (HttpWebResponse)webRequest.GetResponse();
                 if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                 {
                     var reader = new StreamReader(webResponse.GetResponseStream());
                     string s = reader.ReadToEnd();
                     var arr = JsonConvert.DeserializeObject<JArray>(s);
                     dataGridView1.DataSource = arr;
                 }
                 else
                 {
                     MessageBox.Show(string.Format("Status code == {0}", webResponse.StatusCode));
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }*/
        }



        private async Task<bool> PutD()
        {
            string url = "https://balancer.in/VotingApi/api/Value?id=" + textBox1.Text;
          //  string apiUrl = $"http://yourapiendpoint.com/api/mycontroller/update/{id}";

            try
            {
                HttpResponseMessage response = await client.PutAsync(url, null);

                // Check if the update was successful (e.g., HTTP status code 204)
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }



        private async Task<String> PutApiData()
        {
             string apiUrl = "https://localhost:7025/api/Value?id=" +textBox1.Text.ToString();
         //main     string apiUrl = "https://balancer.in/VotingApi/api/Value?id=" + result.ToString();//textBox1.Text.ToString();






            // string apiUrl = "https://balancer.in/VotingApi/api/Value?id=" + textBox1.Text.ToString();

            string id = textBox1.Text;
           // string apiUrl = "https://balancer.in/VotingApi/api/Value?id=isheetaagrawal%40gmail.com";
         //   MessageBox.Show(apiUrl);
            //   string apiUrl = ; // Replace with your actual API URL
           // string id = textBox1.Text; // Replace with the ID you want to update

            using (HttpClient client = new HttpClient())
            {
                // Prepare the data you want to send in the request body (if needed)
                // For example, you may want to send a JSON payload
                /*
                var model = new ClassMail
                {
                    Name = "UpdatedName",
                    Description = "UpdatedDescription"
                };
                */

                // Create the HTTP request message
                 using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put,apiUrl))
             //   using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"{apiUrl}/id"))
                {
                    // Set the content type if sending data in the request body
                    // request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    // Send the HTTP request and get the response
                    HttpResponseMessage response = await client.SendAsync(request);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and display the response content
                        string result2 = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result2);
                        //Console.WriteLine(result);
                    }
                    else
                    {
                        // Display the error status code
                        MessageBox.Show(response.StatusCode.ToString());
                        //Console.WriteLine($"Error: {response.StatusCode}");

                    }
                }
            }
            return "yes";
        }


        private async void timer2_TickAsync(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    textBox1.Text = result.ToString();
                    Console.Beep(800, 750);
                    if (result != null)
                    {
                        List<ClassMail> data = await GetApiData();
                        //  MessageBox.Show(textBox1.Text);

                       // bool v = await PutD();
                       // PutApiData();
                        // MessageBox.Show(v.ToString());
                      //  MessageBox.Show(data2);
                        // Bind the data to the DataGridView
                        dataGridView1.DataSource = data;
                        //update

                        nextform();
                      //  String data2 = await PutApiData();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }

        private void nextform()
        {
            if (textBox1.Text != "")
            {
                string x = (String)dataGridView1[8, 0].Value;
                string y = (String)dataGridView1[9, 0].Value;
                if (x == "0" && y == "1")
                {
                   // for (int i = 0; i < 1; i++)
                   // {
                        //Session["id"] = mail;
                        //url = "dashboard.aspx";
                        //Response.Redirect(url);
                        Process.Start(@"https://www.balancer.in/WebForm1.aspx");
                    //Process.Start(@"https://localhost:7025/WebForm1.aspx");
                    textBox1.Text = "";
                        pictureBox1.Visible = false;
                        this.Close();
                        Environment.Exit(0);
                      //  break;
                    //}

                    //    Form2 f2 = new Form2();
                    //  f2.Show();
                    // return;                
                    //   this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                    textBox1.Text = "";
                    pictureBox1.Visible = false;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Done");
            }


        }
    }
}



//String name = @"C:\Users\ishee\OneDrive\Desktop\try.json";
//if (File.Exists(name) == false)
//{
//    MessageBox.Show("NO");
//    return;
//}
//var json = File.ReadAllText(name);
////List<JsonResult>? _people = JsonConvert.DeserializeObject<List<JsonResult>>(json);
//var _people = JsonConvert.DeserializeObject<List<JsonResult>>(json);



////     var result = JsonConvert.DeserializeObject<List<JsonResult>> (input);
//dataGridView1.DataSource = null;
//if (_people != null)
//{
//    dataGridView1.DataSource = _people;
//}