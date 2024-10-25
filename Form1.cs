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
            lst.Items.Add(txt.Text); // при нажатии добавляется в lst, значения, которые введены
           txt.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Укажите путь к файлу");
            }
            else
            {
                string fileName = txtFileName.Text; // путь к файлу

                if (File.Exists(fileName))
                {
                    File.Delete(fileName); // если файл сущ - удаляем его
                }
                using (FileStream fs = File.Create(fileName, 1024)) //класс для работы с файлами
                using (BinaryWriter bw = new BinaryWriter(fs)) 
                {
                    for (var i = 0; i < lst.Items.Count; i++) //пока не конец спика, записывает в файл 
                    {
                        bw.Write(lst.Items[i].ToString());
                    }
                    bw.Close();
                    fs.Close();

                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Не указан путь, чтобы вывести содержимое. Укажите! ");
            }
            else
            {
                string fileName = txtFileName.Text;
                lstFromfile.Items.Clear();
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (br.PeekChar() != -1) // peekchar возвращает следующий прочитанный символ, если нет то -1
                    {
                        lstFromfile.Items.Add(br.ReadString()); // добавляем в список прочитаную строчку
                    }
                    br.Close();
                    fs.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
