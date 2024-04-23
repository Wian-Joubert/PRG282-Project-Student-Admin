using Login.BusinessLogicLayer;

namespace PRG_282_project.Presentation_Layer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        UserHandler userHandler = new UserHandler();
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.ToUpper().Trim();
            string password = textBox2.Text.Trim();
            string[] loginData = new string[] { username, password };

            if (userHandler.VerifyUserInput(loginData))
            {
                this.Hide();
                DisplayForm displayForm = new DisplayForm();
                displayForm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Regform regForm = new Regform();
            regForm.Show();
        }

        private void LoginForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string credits = "Bradley Pretorius:           577475\n" +
                             "Cleavan Jeseltè:              577733\n" +
                             "Wian Joubert:                 577737\n" +
                             "Vutivi Maswanganyi:       577800";
            MessageBox.Show(credits, "Credit To Group Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
