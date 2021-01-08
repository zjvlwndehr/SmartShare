// ⓒ2021
// email;ketchup2480@gmail.com
// github_name;zjvlwndehr
// github_repository;https://github.com/zjvlwndehr/SmartShare
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
        public string directory = "";
        public string jsonpath = "";
        public string container = "";
        public Bitmap bitmap = new Bitmap("resource\\dragdrop.png");
        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
            checker();
            ReadJson();
            
        }

        // function : initialize  componets
        public void InitializeComponent2()
        {
            this.AllowDrop = true;
            DragDropPictureBox.Image = bitmap;
            DragDropPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // function : check file exisitence
        public void checker()
        {
            string jsonpath = Directory.GetCurrentDirectory().ToString() + @"\data.json";    //  data.json path to check whether it dosen't exist.
            if(File.Exists(jsonpath))   //  confirm data.json
            {
                this.jsonpath = jsonpath; Debug.WriteLine("status:200;data.json exist");
            }else
            {
                File.Create(jsonpath);this.jsonpath = jsonpath; Debug.WriteLine("status:200;create "+jsonpath);
            }
        }

        // function : read last path from data.json
        public void ReadJson()
        {
            using (StreamReader sr = new StreamReader(jsonpath))
            {
                container = sr.ReadToEnd();  //  read all data.json text
                if (container != "")
                {
                    var json = JObject.Parse(container);    //  create json object and parse text
                    string lastpath = (string)json["lastpath"]; //  extract last path   //  Debug.WriteLine(lastpath);
                    if(lastpath != "")
                    {
                        labelCurrentDrive.Text = lastpath;    //  return value
                        directory = lastpath;
                    }else
                    {
                        init();
                    }
                }else
                {
                    init();
                }   
                sr.Close();
            }
        }

        // function : initialize values
        public void init()
        {
            //string current_directory = directory;   //  copy past directory
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();    //  folderBrowserDialog
            folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.SelectedPath != "") //  폴더를 선택하지 않았을 경우 디렉토리가 바뀌는 경우를 방지하기 위함
            {
                directory = folderBrowserDialog.SelectedPath;   //  direcory is changed into new directory path.
                labelCurrentDrive.Text = directory;    // TextBox.Text is changed into new directory path.
                var json = new JObject();
                json.Add("lastpath", directory); Debug.WriteLine("sataus:200;json add data\n" + json.ToString());
                container = json.ToString();
                WriteJSON(jsonpath);
            }
            else
            {
                labelCurrentDrive.Text = directory;    // TextBox.Text is changed into new directory path.
            }


        }

        // function : write JSON file
        public void WriteJSON(string FileName)
        {
            using (StreamWriter file = File.CreateText(FileName))
            {
                file.Write(this.container);
                Debug.WriteLine("status:200;write container" + this.container); 
                file.Close();
            }
        }

        // function : upload file
        public void UploadFile(string path, string destFileName)
        {
            destFileName = this.directory +"\\" + destFileName;
            if(File.Exists(destFileName)==true)
            {
                MessageBox.Show("status:400;The file already exists!"); Debug.WriteLine("status:400;The file already exists: " + destFileName);
            }else
            {
                File.Copy(path,destFileName);Debug.WriteLine("status:200;uploading complete : "+destFileName);
            }

        }

        // function : get file list
        public void GetFileList()
        {
        }

        // function : FTPupload : upload file in ftp web request
        public void FTPupload()
        {
            FtpWebRequest FTPrequestUploader = (FtpWebRequest)WebRequest.Create("ftp://192.168.27:21/DataSenter/drive01/");
            string ID =textBox1.Text; string PW = textBox2.Text;
            FTPrequestUploader.Credentials = new NetworkCredential("ID", "PW");
            
            var request = FTPrequestUploader;
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            Debug.WriteLine("status:200;create ftp server : " + request.GetResponse());

            try
            {
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Debug.WriteLine("status:200;response : " + resp);
                    resp.Close();
                }
            }catch(WebException e)
            {
            }
        }

        // event : Click;choose directory to use as a drive
        private void choose_drive_Click(object sender, EventArgs e)
        {
            init();
        }

        // event : Click;click and select file
        private void DragDropPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            string filename = file.FileName;
            string destFileName = Path.GetFileName(filename);
            Debug.WriteLine("status:200;click event ok, selected file :" + filename);
            if(filename != "")
            {
                UploadFile(filename,destFileName);
            }
            else
            {
                Debug.WriteLine("status:400;no file selected");
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
            Debug.Print("status:200;drag and drop ok..., try UploadFile()...");
            if (filename[0] != "")
            {
                UploadFile(filename[0], destFileName);
            }
            else
            {
                Debug.WriteLine("status:400;no file selected");
            }
        }

        // event : Click;Select accessable ipaddress and upload files via internet.
        private void FTP_Upload_Click(object sender, EventArgs e)
        {
            FTPupload();
        }
    }
}
