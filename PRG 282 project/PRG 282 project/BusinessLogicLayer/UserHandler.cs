using Login.FileAccessLayer;
using PRG_282_project;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Login.BusinessLogicLayer
{
    internal class UserHandler
    {
        FileHandler fileHandler = new FileHandler();

        // Verifies user login data
        public bool VerifyUserInput(string[] loginData)
        {
            (List<string> userData, bool success) = fileHandler.ReadUserdata();
            if (success)
            {
                foreach (var user in userData)
                {
                    string[] splitdata = user.Split(',');
                    if (splitdata[0] == loginData[0] && splitdata[1] == EncryptPassword(loginData[1]))
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show("Incorrect Username or Password. Please Retry Login.", "Login Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        public bool ValidateUserPassword(string password)
        {
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,25}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(password);
        }

        // Encrypts a password using SHA256
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute hash from password
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Convert each byte to hexadecimal and append to the string builder
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Writes a new user to the user data file
        public bool WriteUser(string[] userData)
        {
            if (ValidateUserPassword(userData[1]))
            {
                userData[1] = EncryptPassword(userData[1]);
                string userDataToWrite = userData[0] + ',' + userData[1];
                fileHandler.WriteNewUser(userDataToWrite);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Images to/from Database
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                // Converts image to bytes to be stored
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ByteArrayToImage(string byteArrayString)
        {
            byte[] imageData = null;
            try
            {
                // Convert the base64 string back to a byte array
                imageData = Convert.FromBase64String(byteArrayString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (imageData != null)
            {
                using (var ms = new MemoryStream(imageData))
                {
                    // Reconstructs image from bytes 
                    Image returnImage = Image.FromStream(ms);
                    return returnImage;
                }
            }
            else
            {
                // Return a default image or handle the case when imageData is null
                return null;
            }
        }

        // Basic User data validation
        public bool ValidateStudent(Student student)
        {
            bool isValid = student.StudentNumber != null &&
                !string.IsNullOrEmpty(student.Name) &&
                !string.IsNullOrEmpty(student.Surname) &&
                !string.IsNullOrEmpty(student.Gender) &&
                !string.IsNullOrEmpty(student.PhoneNumber) &&
                !string.IsNullOrEmpty(student.Address) &&
                !string.IsNullOrEmpty(student.ModuleCodes) &&
                student.DOB != default(DateTime) &&
                !string.IsNullOrEmpty(student.ImageData) &&
                ValidateDOB(student.DOB);  // Include the ValidateDOB method here

            return isValid;
        }

        private bool ValidateDOB(DateTime dateOfBirth)
        {
            // Check if the date of birth is not in the future
            if (dateOfBirth > DateTime.Now)
            {
                // Date of birth is in the future, invalid
                return false;
            }
            // Check if the person is at least 18 years old
            DateTime eighteenYearsAgo = DateTime.Now.AddYears(-18);
            if (dateOfBirth > eighteenYearsAgo)
            {
                // Person is not at least 18 years old, invalid
                return false;
            }
            // The date of birth is valid
            return true;
        }

        public bool ValidateModule(Module module)
        {
            bool isValid = !string.IsNullOrEmpty(module.ModuleName) &&
                !string.IsNullOrEmpty(module.ModuleCode) &&
                !string.IsNullOrEmpty(module.ModuleDescription) &&
                !string.IsNullOrEmpty(module.ModuleLinks);

            return isValid;
        }
        public string[] FormatLinks(string links)
        {
            string[] linksArray = links.Split(',');

            for (int i = 0; i < linksArray.Length; i++)
            {
                linksArray[i] = linksArray[i].Trim();
            }

            return linksArray;
        }
    }
}
