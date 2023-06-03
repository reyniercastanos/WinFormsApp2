using System;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();





        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var splashform = new FormSplash();
            splashform.ShowDialog();
            var password = splashform.Password;
            if (password != "a")
                Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var l = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                l.Add(new Person()
                {
                    Id = i + 1,
                    Name = "person" + (i + 1).ToString()
                });
            }

            using (var fileStream = System.IO.File.Create("C:\\Users\\luyan\\OneDrive\\Desktop\\peopleList"))
            {
                foreach (var person in l)
                {
                    var buffer = System.Text.Encoding.UTF8.GetBytes(person.Name!);
                    var buffer2 = System.BitConverter.GetBytes(buffer.Length);

                    fileStream.Write(buffer2, 0, buffer2.Length);

                    fileStream.Write(buffer, 0, buffer.Length);
                    buffer = System.BitConverter.GetBytes(person.Id);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
                fileStream.Flush();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fileStream = System.IO.File.OpenRead("C:\\Users\\luyan\\OneDrive\\Desktop\\peopleList"))
            {
                var buffer2 = new byte[4];


                while (true)
                {
                    var byteRead = fileStream.Read(buffer2, 0, 4);
                    if (byteRead == 0)
                        break;
                    var totalByteUsedByName = System.BitConverter.ToInt32(buffer2, 0);
                    var buffer = new byte[totalByteUsedByName];
                    fileStream.Read(buffer, 0, totalByteUsedByName);
                    var name = System.Text.Encoding.UTF8.GetString(buffer);
                    fileStream.Read(buffer, 0, 4);
                    var id = System.BitConverter.ToInt32(buffer, 0);
                    var person = new Person { Id = id, Name = name };
                    listBox1.Items.Add(person);
                }
            }
        }
    }
}