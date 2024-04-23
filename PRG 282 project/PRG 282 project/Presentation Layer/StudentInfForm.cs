using Login.BusinessLogicLayer;
using Login.FileAccessLayer;
using PRG_282_project.DataAccessLayer;

namespace PRG_282_project.Presentation_Layer
{
    public partial class StudentInfForm : Form
    {
        public StudentInfForm()
        {
            InitializeComponent();
        }

        // Add Button
        private void button1_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            UserHandler userHandler = new UserHandler();
            try
            {
                int studentNumber;
                if (!int.TryParse(textBox7.Text, out studentNumber))
                {
                    throw new Exception("Invalid Student Number. Please Retry.");
                }
                string name = textBox6.Text.Trim();
                string surname = textBox5.Text.Trim();
                if (comboBox1.SelectedIndex == -1)
                {
                    comboBox1.SelectedIndex = 0;
                }
                string gender = comboBox1.SelectedItem.ToString();
                DateTime dob = dateTimePicker1.Value;
                string phoneNumber = textBox2.Text.Trim();
                string address = textBox3.Text.Trim();
                string moduleCodes = textBox1.Text.Trim();
                byte[] imgbytes = userHandler.ImageToByteArray(pictureBox1.Image);

                Student student = new Student(studentNumber, name, surname, gender, dob, phoneNumber, address, moduleCodes, imgbytes);

                dataHandler.AddStudentToDatabase(student);

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Student Information Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            pictureBox1.Image = fileHandler.GetImage();
        }

        private void StudentInfForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\blankpicture.png");
        }

        // Update Button
        private void button3_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            UserHandler userHandler = new UserHandler();
            try
            {
                int studentNumber;
                if (!int.TryParse(textBox7.Text, out studentNumber))
                {
                    throw new Exception("Invalid Student Number. Please Retry.");
                }
                string name = textBox6.Text.Trim();
                string surname = textBox5.Text.Trim();
                if (comboBox1.SelectedIndex == -1)
                {
                    comboBox1.SelectedIndex = 0;
                }
                string gender = comboBox1.SelectedItem.ToString();
                DateTime dob = dateTimePicker1.Value;
                string phoneNumber = textBox2.Text.Trim();
                string address = textBox3.Text.Trim();
                string moduleCodes = textBox1.Text.Trim();
                byte[] imgbytes = userHandler.ImageToByteArray(pictureBox1.Image);

                Student student = new Student(studentNumber, name, surname, gender, dob, phoneNumber, address, moduleCodes, imgbytes);

                dataHandler.UpdateStudentInDatabase(student);

                this.Hide();
                DisplayForm displayForm = new DisplayForm();
                displayForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Student Information Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Button GetButton3()
        {
            return button3;
        }
        public Button GetButton1()
        {
            return button1;
        }
        public TextBox GetTextBox7()
        {
            return textBox7;
        }
        public Label GetLabel11()
        {
            return label11;
        }

        private void StudentInfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
        }

        private void StudentInfForm_VisibleChanged(object sender, EventArgs e)
        {
            button1.Show();
            button3.Hide();
            textBox7.ReadOnly = false;
            textBox7.BackColor = SystemColors.Window;
            label11.Hide();
        }

        public void SetSelectedStudent(Student student)
        {
            textBox7.Text = student.StudentNumber.ToString();
            textBox6.Text = student.Name;
            textBox5.Text = student.Surname;
            dateTimePicker1.Value = student.DOB;
            comboBox1.SelectedItem = student.Gender;
            textBox2.Text = student.PhoneNumber;
            textBox3.Text = student.Address;
            textBox1.Text = student.ModuleCodes;
            UserHandler userHandler = new UserHandler();
            pictureBox1.Image = userHandler.ByteArrayToImage(student.ImageData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
        }
    }
}
