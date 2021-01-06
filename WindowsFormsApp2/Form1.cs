using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static string FilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //フォルダ選択ダイアログを生成する
            FolderBrowserDialog fo = new FolderBrowserDialog();
            fo.Description = "フォルダ選択";
            fo.RootFolder = Environment.SpecialFolder.MyComputer;    //Myドキュメントをルートフォルダにする

            //フォルダ選択ダイアログを表示する
            DialogResult result = fo.ShowDialog();

            if (result == DialogResult.OK)
            {
                //リストボックス初期化
                listBox1.Items.Clear();
                listBox2.Items.Clear();

                //「OK」ボタンが選択された時の処理
                string folderPath = fo.SelectedPath;  //こんな感じで選択されたフォルダのパスが取得できる
                string folderName = System.IO.Path.GetFileName(folderPath);
                FilePath = folderPath;
                textBox1.Text = folderName;

                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(@folderPath);
                System.IO.FileInfo[] files =
                    di.GetFiles("*.jpg", System.IO.SearchOption.AllDirectories);

                System.IO.FileInfo[] files1 =
                    di.GetFiles("*.fdat", System.IO.SearchOption.AllDirectories);

                System.IO.FileInfo[] files2 =
                    di.GetFiles("*.jdat", System.IO.SearchOption.AllDirectories);

                //ListBox1に結果を表示する
                foreach (System.IO.FileInfo f in files)
                {
                    listBox1.Items.Add(f.Name);
                    listBox2.Items.Add(f.FullName);
                }

                label2.Text = files.Count().ToString();
                label4.Text = files2.Count().ToString();
            }
            else if (result == DialogResult.Cancel)
            {
                //「キャンセル」ボタンまたは「×」ボタンが選択された時の処理
            }

            fo.Dispose();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string path = listBox2.Items[listBox1.SelectedIndex].ToString();
            textBox4.Text = listBox1.SelectedItem.ToString();
            pictureBox1.ImageLocation = path;
            Console.WriteLine(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox3.Text;
            string fname = textBox1.Text + ".fdat";

            StreamWriter writer = new StreamWriter(FilePath + "\\" + fname, true);
            writer.WriteLine(text);
            writer.Close();
        }
    }
}
