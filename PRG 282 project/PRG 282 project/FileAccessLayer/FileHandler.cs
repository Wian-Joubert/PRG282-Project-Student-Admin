namespace Login.FileAccessLayer
{
    internal class FileHandler
    {
        // Reads user data from a file and returns it as a list of strings
        public (List<string>, bool) ReadUserdata()
        {
            List<string> list = new List<string>();
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\userdata.txt";
                if (!File.Exists(path))
                {
                    throw new Exception("File not found.");
                }

                if (new FileInfo(path).Length == 0)
                {
                    throw new Exception("File is Empty. Please Create a New User.");
                }

                list = File.ReadAllLines(path).ToList();

                return (list, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return (list, false);
            }
        }

        // Writes a new user to the user data file
        public void WriteNewUser(string userDataToWrite)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\userdata.txt";
                (List<string> existingUsers, bool success) = ReadUserdata();
                if (success)
                {
                    if (existingUsers.Contains(userDataToWrite))
                    {
                        MessageBox.Show("User already exists.", "Write Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        // Ensure each user is on a new line
                        File.AppendAllText(path, userDataToWrite + Environment.NewLine);
                        MessageBox.Show("New User Added to File.", "Write Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Get Image from File Explorer Dialog
        public Bitmap GetImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return new Bitmap(openFileDialog.FileName);
                }
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "\\blankpicture.png");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
