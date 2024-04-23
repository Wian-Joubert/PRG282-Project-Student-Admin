using Login.BusinessLogicLayer;
using PRG_282_project.DataAccessLayer;
using PRG_282_project.Presentation_Layer;

namespace PRG_282_project
{


    public partial class DisplayForm : Form
    {

        public DisplayForm()
        {
            InitializeComponent();
        }

        // Update Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Extract information from the selected row
                int studentNumber = Convert.ToInt32(selectedRow.Cells["StudentNumber"].Value);
                string name = Convert.ToString(selectedRow.Cells["Name"].Value);
                string surname = Convert.ToString(selectedRow.Cells["Surname"].Value);
                string gender = Convert.ToString(selectedRow.Cells["Gender"].Value);
                DateTime dob = Convert.ToDateTime(selectedRow.Cells["DOB"].Value);
                string phoneNumber = Convert.ToString(selectedRow.Cells["PhoneNumber"].Value);
                string address = Convert.ToString(selectedRow.Cells["Address"].Value);
                string moduleCodes = Convert.ToString(selectedRow.Cells["ModuleCodes"].Value);
                string imageData = Convert.ToString(selectedRow.Cells["ImageData"].Value);


                // Pass the selected student to StudentInfForm
                this.Hide();
                UserHandler userHandler = new UserHandler();
                Image imageDataToConvert = userHandler.ByteArrayToImage(imageData);
                byte[] imageBytes = userHandler.ImageToByteArray(imageDataToConvert);

                Student selectedStudent = new Student(studentNumber, name, surname, gender, dob, phoneNumber, address, moduleCodes, imageBytes);
                StudentInfForm Stufrm = new StudentInfForm();
                Stufrm.SetSelectedStudent(selectedStudent);
                Stufrm.Show();
                Stufrm.GetButton3().Visible = true;
                Stufrm.GetButton3().Left = Stufrm.GetButton1().Left;
                Stufrm.GetButton1().Visible = false;
                Stufrm.GetTextBox7().ReadOnly = true;
                Stufrm.GetTextBox7().BackColor = SystemColors.InactiveCaption;
                Stufrm.GetLabel11().Visible = true;
                Stufrm.GetLabel11().Text = "Read Only.";
            }
            else
            {
                // No row selected, handle accordingly
                MessageBox.Show("Please select a row before clicking the button.");
            }
        }

        private void DisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            dataGridView1.DataSource = dataHandler.GetData();
        }

        // Create Button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentInfForm Stufrm = new StudentInfForm();
            Stufrm.Show();
        }

        // Search Button
        private void button4_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            dataGridView1.DataSource = dataHandler.SearchStudentNumber(textBox1.Text);
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            dataGridView1.DataSource = dataHandler.GetData();
        }
        // Delete Button
        private void button1_Click(object sender, EventArgs e)
        {
            DataHandler dataHandler = new DataHandler();
            dataHandler.DeleteStudentFromDatabase();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the program?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModuleForm ModuleForm = new ModuleForm();
            ModuleForm.Show();
            this.Hide();
        }
    }
}