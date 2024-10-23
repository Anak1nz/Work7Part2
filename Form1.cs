using System;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lst.Items.Add(txt.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Укажите путь к файлу");
            }
            string fileName = txtFileName.Text;
           
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName, 1024))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                for (var i = 0; i < lst.Items.Count; i++)
                {
                    bw.Write(lst.Items[i].ToString());
                }
                bw.Close();
                fs.Close();
               
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text;
            lstFromfile.Items.Clear();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                while (br.PeekChar() != -1)
                {
                    lstFromfile.Items.Add(br.ReadString());
                }
                br.Close();
                fs.Close();
            }
        }
    }
}
