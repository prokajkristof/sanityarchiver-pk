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
using System.IO.Compression;
using System.Security.Cryptography;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        private DirectoryInfo baseDirectory = null;
        private string file = null;
        

        public Form1()
        {
            InitializeComponent();
            listView1.MouseDoubleClick += new MouseEventHandler(listView1_MouseDoubleClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if(baseDirectory == null)
            {
                button1.Enabled = false;
            }
            foreach(DriveInfo di in DriveInfo.GetDrives())
            {
                driveList.Items.Add(di);
            }
        }

        private void driveList_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            
            try
            {
                DriveInfo drive = (DriveInfo)driveList.SelectedItem;
                baseDirectory = drive.RootDirectory;
                foreach(DirectoryInfo dirInfo in drive.RootDirectory.GetDirectories())
                {
                    listView1.Items.Add(dirInfo.ToString());
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baseDirectory != null)
            {
                String currentDirectory = baseDirectory.FullName;
                DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentDirectory);
                if (currentDirectoryInfo.Parent != null && baseDirectory != null)
                {
                    String grandParentPath = currentDirectoryInfo.Parent.FullName;
                    listView1.Items.Clear();
                    DirectoryInfo dir = new DirectoryInfo(grandParentPath);
                    label1.Text = dir.FullName;
                    foreach (DirectoryInfo di in dir.GetDirectories())
                    {
                        ListViewItem item = new ListViewItem(di.ToString());
                        item.SubItems.Add("");
                        item.SubItems.Add(File.GetCreationTime(di.FullName).ToString());
                        listView1.Items.Add(item);
                    }
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        ListViewItem item = new ListViewItem(fi.ToString());
                        item.SubItems.Add(fi.Length.ToString());
                        item.SubItems.Add(File.GetCreationTime(fi.FullName).ToString());
                        listView1.Items.Add(item);
                    }
                    baseDirectory = new DirectoryInfo(grandParentPath);
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }



        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            if (info.Item != null)
            {
                DirectoryInfo dir = null;
                foreach (DirectoryInfo dirInf in baseDirectory.GetDirectories())
                {
                    if (dirInf.ToString() == info.SubItem.Text)
                    {
                        baseDirectory = dirInf;
                        dir = dirInf;
                    }
                }
                label1.Text = baseDirectory.FullName;
                Directory(dir);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String text = listView1.SelectedItems[0].Text;
            file = text;
        }

        private void Compress_Click(object sender, EventArgs e)
        {

            
        }

        private void Compress_File(string path)
        {
            FileStream sourceFile = File.OpenRead(path);
            FileStream destinationFile = File.Create(path + ".gz");

            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinationFile,
                CompressionMode.Compress))
            {
                Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
                    destinationFile.Name, false);

                output.Write(buffer, 0, buffer.Length);
            }

            sourceFile.Close();
            destinationFile.Close();
        }

        private void Compress_Click_1(object sender, EventArgs e)
        {
            foreach (DirectoryInfo dirInf in baseDirectory.GetDirectories())
            {
                if (dirInf.ToString() == file)
                {
                    Compress_File(dirInf.FullName);
                    Directory(baseDirectory);
                }
            }

            foreach (FileInfo fi in baseDirectory.GetFiles())
            {
                if (fi.ToString() == file)
                {
                    Compress_File(fi.FullName);
                    Directory(baseDirectory);
                }
            }
        }

        private void Directory(DirectoryInfo dir)
        {
            listView1.Items.Clear();
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ListViewItem item = new ListViewItem(di.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(File.GetCreationTime(di.FullName).ToString());
                listView1.Items.Add(item);
            }
            foreach (FileInfo fi in dir.GetFiles())
            {
                ListViewItem item = new ListViewItem(fi.ToString());
                item.SubItems.Add(fi.Length.ToString());
                item.SubItems.Add(File.GetCreationTime(fi.FullName).ToString());
                listView1.Items.Add(item);
            }
            button1.Enabled = true;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            foreach (FileInfo fi in baseDirectory.GetFiles())
            {
                if (fi.ToString() == file)
                {
                    System.IO.File.Delete(fi.FullName);
                    Directory(baseDirectory);
                }
            }

            foreach (DirectoryInfo dirInf in baseDirectory.GetDirectories())
            {
                if (dirInf.ToString() == file)
                {
                    System.IO.File.Delete(dirInf.FullName);
                    Directory(baseDirectory);
                }
            }
        }

        private void crypt_Click(object sender, EventArgs e)
        {
            string path = "";
            foreach (FileInfo fi in baseDirectory.GetFiles())
            {
                if (fi.ToString() == file)
                {
                    path = fi.FullName;
                }
            }

            foreach (DirectoryInfo dirInf in baseDirectory.GetDirectories())
            {
                if (dirInf.ToString() == file)
                {
                    path = dirInf.FullName;
                }
            }
            try
            {
                string password = "password";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = path + "crypted";
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(path, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MessageBox.Show("Encryption failed!", "Error");
            }
            Directory(baseDirectory);
        }
    }
}
