// ⓒ2021
// email;ketchup2480@gmail.com
// github_name;zjvlwndehr
// github_repository;https://github.com/zjvlwndehr/SmartShare (비공개 그냥 깃 저장소임 나중에 오픈소스로 풀어줄께)
// 인천 대건고등학교 박태현
// SmartShare™

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Diagnostics;
using System.Resources;
using System.Net;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string basic_session = "ftp://localhost/";
        public int Upload_input_mode = 0;   //0=nothing/1=ftp upload button/2=dragdrop/3=dragdrop picturebox click
        public string session = "";
        public string jsonpath = "";
        public string container = "";
        public Bitmap bitmap = new Bitmap("resource\\dragdrop.png");
        private BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
            //ReadJson();
            Open_Directory.Visible = true; // = true; 애초에 ftp서버에 접속할 것이였으면 지금은 필요한지 모르겠음
        }

        // function : initialize  componets
        public void InitializeComponent2()
        {
            //인터넷 연결 확인하는것 추가하기. 맥주소에 따라서 서버인지 클라이언트인지 판단하여 이것을 적용하기. 서버면 ftp://localhost/ 로 인터넷 없이 접속가능
            checker();
            init();
            Maintain_LogOn_checkBox.Checked = true;     //  Maintain LogOn
            Maintain_LogOn_checkBox.Text = "로그온 유지";
            this.AllowDrop = true;      //  allow dargdrop event
            DragDropPictureBox.Image = bitmap;
            DragDropPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        // function : check file exisitence
        public void checker()
        {
            string jsonpath = Directory.GetCurrentDirectory().ToString() + @"\data.json";    //  data.json path to check whether it dosen't exist.
            if (File.Exists(jsonpath))   //  confirm data.json
            {
                this.jsonpath = jsonpath; Debug.WriteLine("status:200;data.json exist" + jsonpath);
                string container=File.ReadAllText(jsonpath);
                var json = JObject.Parse(container);
                CurrentSessionLabel.Text = (string)json["lastsession"];
                textBox1.Text = (string)json["lastsession"];
                if ((string)json["Id"] != "")
                    textBox2.Text = (string)json["Id"];
                if ((string)json["Pw"] != "")
                    textBox3.Text = (string)json["Pw"];
            }
            else
            {
                this.jsonpath = jsonpath;
                var json = new JObject();
                json.Add("lastsession", basic_session); Debug.WriteLine("sataus:200;json add data\n" + json.ToString());
                File.WriteAllText(jsonpath, json.ToString()); Debug.WriteLine("status:200;create and write the basic session" + jsonpath);
                CurrentSessionLabel.Text = basic_session;
            }
        }

        // function : read last path from data.json
        public void ReadJson()
        {
            using (StreamReader sr = new StreamReader(jsonpath))
            {
                container = sr.ReadToEnd();  //  read all data.json text
                Debug.WriteLine("status:100;\n"+container);

                if (container != "")
                {
                    var json = JObject.Parse(container);    //  create json object and parse text
                    string lastsession = (string)json["lastsession"]; //  extract last path   //  Debug.WriteLine(lastsession);
                    Debug.WriteLine("status:100;lastsession = " + lastsession);

                    if (lastsession != "")
                    {
                        CurrentSessionLabel.Text = lastsession;    //  return value
                        session = lastsession;
                    }
                    else
                    {
                        init();
                    }
                }
                else
                {
                    init();
                }
                sr.Close();
            }
        }

        // function : initialize values
        public void init()
        {
            //string current_session = session;   //  copy past session
            //labelCurrentDrive.Text = session;    // TextBox.Text is changed into new session path.

            //var json = new JObject();
            //json.Add("lastsession", session); Debug.WriteLine("sataus:200;json add data\n" + json.ToString());
            //container = json.ToString();
            //WriteJSON(jsonpath);
        }

        // function : write JSON file
        public void WriteJSON(string FileName)
        {
            //using (StreamWriter file = File.CreateText(FileName))
            //{
            //    file.Write(this.container);
            //    Debug.WriteLine("status:200;write container" + this.container); 
            //    file.Close();
            //}
        }

        // function : upload file 삭제할 예정
        //public void UploadFile(string path, string destFileName)
        //{
        //    destFileName = this.session+"\\" + destFileName;
        //    if(File.Exists(destFileName)==true)
        //    {
        //        MessageBox.Show("status:400;The file already exists!"); Debug.WriteLine("status:400;The file already exists: " + destFileName);
        //    }else
        //    {
        //        File.Copy(path,destFileName);Debug.WriteLine("status:200;uploading complete : "+destFileName);
        //    }

        //}

        // structure : Family of FtpSetting members
        struct FtpSetting
        {
            public string Server { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string FileName { get; set; }
            public string FullName { get; set; }
        }
        // constructor : constructor of FtpSetting
        FtpSetting _inputParameter;
        
        // worker_ : progress report(progressbar1)
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            Uploaded_status_label.Text = $"Uploaded {e.ProgressPercentage} %";
            progressBar1.Update();
        }

        // worker_ : complete work
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                MessageBox.Show(e.Error.Message,"Error!");                
            }
            Uploaded_status_label.Text = "Upload complete!";
        }
        // worker thread : work it do
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                worker.ReportProgress(0);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(string.Format("{0}/{1}", _inputParameter.Server, _inputParameter.FileName)));
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_inputParameter.Username, _inputParameter.Password);//Debug.WriteLine(_inputParameter.Username + _inputParameter.Password);
                Stream ftpStream = request.GetRequestStream();
                FileStream fs = File.OpenRead(_inputParameter.FullName);Debug.WriteLine(_inputParameter.FullName);
                byte[] buffer = new byte[1024];
                double total = (double)fs.Length;
                int byteRead = 0;
                double read = 0;
                do
                {
                    if (!worker.CancellationPending) { 
                    byteRead = fs.Read(buffer, 0, 1024);
                    ftpStream.Write(buffer, 0, byteRead);
                    read += (double)byteRead;
                    double percentage = read / total * 100;
                    worker.ReportProgress((int)percentage);Debug.WriteLine((int)percentage);
                    }
                } while (byteRead != 0);
                ftpStream.Close();
                Debug.WriteLine("complete!");

            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            
        }

        // function : get file list
        public bool SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "All files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                _inputParameter.Server = textBox1.Text;
                _inputParameter.Username = textBox2.Text;
                _inputParameter.Password = textBox3.Text;
                _inputParameter.FileName = fi.Name;
                _inputParameter.FullName = fi.FullName;
                Debug.WriteLine("status:200;SelectFile() return = true");
                return true;
            }
            else
            {
                Debug.WriteLine("status:200;SelectFile() return = false");
                return false;
            }
        }
        // function : FTPupload : upload file in ftp web request/async 비동기 처리됨
        public void FTPupload()
        {
            //Debug.WriteLine("status:" + (ftp_checker == true ? "200" : "false") + ";validation :" + ftp_checker);
            //if(DragDropChecker == true)
            //{
            //    worker.RunWorkerAsync();
            //    DragDropChecker = false;
            //}else if (SelectFile() == true)
            //{
            //    worker.RunWorkerAsync();
            //}
            if(Upload_input_mode == 1)          //  1=ftp upload button
            {
                if (SelectFile() == true)
                {
                    worker.RunWorkerAsync();
                }
            }else if(Upload_input_mode == 2)    //  2=dragdrop
            {              
                worker.RunWorkerAsync();
            }else if(Upload_input_mode == 3)    //  3=dragdrop picturebox click
            {
                worker.RunWorkerAsync();
            }
            Debug.WriteLine("status:100;upload input mode : "+Upload_input_mode);
            Upload_input_mode = 0;
        }

        // event : Click;choose directory to use as a drive
        private void Open_Directory_Click(object sender, EventArgs e)
        {
            //init();Debug.WriteLine("clicked!");
        }

        // event : Click;click and select file
        private void DragDropPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "All files|*.*" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                _inputParameter.Server = textBox1.Text;
                _inputParameter.Username = textBox2.Text;
                _inputParameter.Password = textBox3.Text;
                _inputParameter.FileName = fi.Name;
                _inputParameter.FullName = fi.FullName;
                Upload_input_mode = 3;
                Debug.WriteLine("status:100;upload input mode : " + Upload_input_mode);
                FTPupload();
            }else
            {
                Debug.WriteLine("status:400;no file selected");
                Upload_input_mode = 0;
            }
        }

        // event : DargEnter;Make effect
        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // event : form1_load
        private void Form1_Load(object sender, EventArgs e)
        {
            DragDropPictureBox.AllowDrop = true;
        }

        // event : DragDrop;Upload file
        private void DragDrop(object sender, DragEventArgs e)
        {
            var filename = (string[])e.Data.GetData(DataFormats.FileDrop);
            string destFileName = Path.GetFileName(filename[0]);
            Debug.Print("status:200;try FTPupload()");
            if (filename[0] != "")
            {
                _inputParameter.Server = textBox1.Text;
                _inputParameter.Username = textBox2.Text;
                _inputParameter.Password = textBox3.Text;
                _inputParameter.FileName = Path.GetFileName(filename[0]);
                _inputParameter.FullName = Path.GetFullPath(filename[0]);
                Upload_input_mode = 2;
                Debug.WriteLine("status:100;upload input mode : " + Upload_input_mode);
                FTPupload();
            }
            else
            {
                Debug.WriteLine("status:400;no file selected");
                Upload_input_mode = 0;
            }
        }

        // event : Click;Select accessable ipaddress and upload files via internet.
        private void FTP_Upload_Click(object sender, EventArgs e)
        {
            bool ftp_checker = true;
            if (textBox1.Text =="")
                ftp_checker = false;
            if (textBox2.Text == "")
                ftp_checker = false;
            if (textBox3.Text == "")
                ftp_checker = false;
            Debug.WriteLine("status:"+(ftp_checker == true ? "200" : "false")+";validation :"+ftp_checker);
            if (ftp_checker == true)
            {
                Upload_input_mode = 1;
                FTPupload(); Debug.WriteLine("status:200;FTPupload start");
            }
        }

        // event : closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Maintain_LogOn_checkBox.Checked == true)
            {
                var json = new JObject();
                json.Add("lastsession", textBox1.Text);
                json.Add("Id", textBox2.Text);
                json.Add("Pw", textBox3.Text);
                File.WriteAllText(jsonpath, json.ToString());Debug.WriteLine("status:200;lastsession and LogOn log saved");
            }else
            {
                var json = new JObject();
                json.Add("lastsession", textBox1.Text);
                json.Add("Id", "");
                json.Add("Pw", "");
                File.WriteAllText(jsonpath, json.ToString()); Debug.WriteLine("status:200;lastsession saved");
            }
        }
    }
}