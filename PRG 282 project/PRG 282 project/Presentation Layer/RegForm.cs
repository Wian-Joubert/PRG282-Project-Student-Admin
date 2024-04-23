using Login.BusinessLogicLayer;

namespace PRG_282_project.Presentation_Layer
{
    public partial class Regform : Form
    {
        UserHandler userHandler = new UserHandler();

        public Regform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.ToUpper().Trim();
            string password = textBox2.Text.Trim();
            string[] userInput = new string[] { username, password };
            if (userInput[0] == "")
            {
                MessageBox.Show("Username may not be empty. Please Retry.", "Valid Username Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!userHandler.WriteUser(userInput))
                {
                    MessageBox.Show("Password must have the following:\n" +
                        "- At least 8 characters, Max 25\n" +
                        "- At least One Uppercase and One Lowercase character\n" +
                        "- At least One Digit\n" +
                        "- At least One Special Character", "Valid Password Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.Hide();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
            }
        }

        private void Regform_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void Regform_Load(object sender, EventArgs e)
        {

        }
    }
}
