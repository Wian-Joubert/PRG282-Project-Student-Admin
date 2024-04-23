using Login.BusinessLogicLayer;
using PRG_282_project.DataAccessLayer;

namespace PRG_282_project.Presentation_Layer
{
    public partial class ModuleForm : Form
    {
        DataHandler dataHandler = new DataHandler();
        public ModuleForm()
        {
            InitializeComponent();
        }

        // Add Module
        private void button1_Click(object sender, EventArgs e)
        {
            dataHandler.AddModule(GetInput());
        }

        // Search Button
        private void button4_Click(object sender, EventArgs e)
        {
            string code = textBox3.Text.ToUpper().Trim();
            if (!string.IsNullOrEmpty(code))
            {
                dataGridView1.DataSource = dataHandler.SearchModule(code);
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("Search Module Code Error. Please fill field with valid input.", "Module Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
        }

        private void ModuleForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataHandler.GetModuleData();
        }

        // Update Module
        private void button2_Click(object sender, EventArgs e)
        {
            dataHandler.UpdateModule(GetInput());
        }

        // Delete Module
        private void button3_Click(object sender, EventArgs e)
        {
            dataHandler.DeleteModule();
        }

        private Module GetInput()
        {
            string moduleName = textBox1.Text;
            string moduleCode = textBox2.Text;
            string moduleDescription = richTextBox1.Text;
            string[] linksArray = richTextBox2.Lines;
            string moduleLinks = string.Join(',', linksArray);

            Module newModule = new Module(moduleName, moduleCode, moduleDescription, moduleLinks);
            return newModule;
        }

        private void ModuleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataHandler.GetModuleData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Assuming the columns in your DataGridView match the properties of your Module class
                string moduleName = dataGridView1.SelectedRows[0].Cells["ModuleName"].Value.ToString();
                string moduleCode = dataGridView1.SelectedRows[0].Cells["ModuleCode"].Value.ToString();
                string moduleDesc = dataGridView1.SelectedRows[0].Cells["ModuleDesc"].Value.ToString();
                string linksToResources = dataGridView1.SelectedRows[0].Cells["LinksToResources"].Value.ToString();

                // Now you can populate your form fields
                textBox1.Text = moduleName;
                textBox2.Text = moduleCode;
                textBox2.ReadOnly = true;
                textBox2.BackColor = SystemColors.InactiveCaption;
                label7.Visible = true;
                label7.Text = "Read Only.";
                richTextBox1.Text = moduleDesc;

                UserHandler userHandler = new UserHandler();
                string formattedLinksString = string.Join(Environment.NewLine, userHandler.FormatLinks(linksToResources));
                richTextBox2.Text = formattedLinksString;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox2.ReadOnly = false;
            textBox2.BackColor = SystemColors.Window;
            label7.Visible = false;
            richTextBox1.Clear();
            richTextBox2.Clear();
        }
    }
}
