using Login.BusinessLogicLayer;
using System.Data;
using System.Data.SqlClient;

namespace PRG_282_project.DataAccessLayer
{
    internal class DataHandler
    {

        /*
         * NOTE: CHANGE SERVER = <ServerName> ; TO WORK ON YOUR MACHINE!
         */
        string connect = "Server=(local)\\SQLEXPRESS;Database=BCStudents;Integrated Security=SSPI;";

        /*
         * START OF STUDENT TABLE DB PROCEDURES
         */

        public DataTable GetData()
        {
            try
            {
                string query = @"SELECT * FROM Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void AddStudentToDatabase(Student student)
        {
            try
            {
                UserHandler userHandler = new UserHandler();
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    string query = @"INSERT INTO Students (StudentNumber, Name, Surname, Gender, DOB, PhoneNumber, Address, ModuleCodes, ImageData)
                             VALUES (@StudentNumber, @Name, @Surname, @Gender, @DOB, @PhoneNumber, @Address, @ModuleCodes, @ImageData)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        bool success = userHandler.ValidateStudent(student);

                        if (success)
                        {
                            command.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                            command.Parameters.AddWithValue("@Name", student.Name);
                            command.Parameters.AddWithValue("@Surname", student.Surname);
                            command.Parameters.AddWithValue("@Gender", student.Gender);
                            command.Parameters.AddWithValue("@DOB", student.DOB);
                            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                            command.Parameters.AddWithValue("@Address", student.Address);
                            command.Parameters.AddWithValue("@ModuleCodes", student.ModuleCodes);
                            command.Parameters.AddWithValue("@ImageData", student.ImageData);

                            // Execute the SQL command
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Student {student.StudentNumber}: {student.Name} {student.Surname} Added.", "Add Student Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Validation of Student data failed. Please Enter valid Data.", "Student Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Insert Student Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateStudentInDatabase(Student student)
        {
            try
            {
                UserHandler userHandler = new UserHandler();
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    string query = @"UPDATE Students
                             SET Name = @Name,
                                 Surname = @Surname,
                                 Gender = @Gender,
                                 DOB = @DOB,
                                 PhoneNumber = @PhoneNumber,
                                 Address = @Address,
                                 ModuleCodes = @ModuleCodes,
                                 ImageData = @ImageData
                             WHERE StudentNumber = @StudentNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        bool success = userHandler.ValidateStudent(student);

                        if (success)
                        {
                            command.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.Int)).Value = student.StudentNumber;
                            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar)).Value = student.Name;
                            command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar)).Value = student.Surname;
                            command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar)).Value = student.Gender;
                            command.Parameters.Add(new SqlParameter("@DOB", SqlDbType.Date)).Value = student.DOB;
                            command.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar)).Value = student.PhoneNumber;
                            command.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar)).Value = student.Address;
                            command.Parameters.Add(new SqlParameter("@ModuleCodes", SqlDbType.NVarChar)).Value = student.ModuleCodes;
                            command.Parameters.Add(new SqlParameter("@ImageData", SqlDbType.NVarChar)).Value = student.ImageData;

                            // Execute the SQL command
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Student {student.StudentNumber}: {student.Name} {student.Surname} updated successfully.", "Update Student Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Validation of Student data failed. Please Enter valid Data.", "Student Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Update Student Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeleteStudentFromDatabase()
        {
            int studentNumber = 0;
            bool success = false;

            try
            {
                // Show an input box to enter the student number
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Student Number:", "Student Number Input", "");

                // Check if the user clicked Cancel or entered an empty string
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Operation canceled or no input provided.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (int.TryParse(input, out studentNumber))
                {
                    success = true;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred when giving Input. Please Retry.\n{ex}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connect))
                    {
                        connection.Open();

                        string query = @"DELETE FROM Students WHERE StudentNumber = @StudentNumber";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.Add(new SqlParameter("@StudentNumber", SqlDbType.Int)).Value = studentNumber;

                            // Execute the SQL command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Student {studentNumber} deleted successfully.", "Delete Student Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Student {studentNumber} not found.", "Delete Student Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Delete Student Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public DataTable SearchStudentNumber(string studentNumber)
        {
            try
            {
                SqlConnection con = new SqlConnection(connect);

                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Students WHERE StudentNumber=@StudentNumber", con);

                cmd.Parameters.AddWithValue("StudentNumber", int.Parse(studentNumber));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Check if any rows were returned
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    // Student does not exist, show a message box
                    MessageBox.Show("Student does not exist.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Search Student Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return GetData();
            }
        }


        /*
         * START OF MODULE TABLE DB PROCEDURES
         */

        public DataTable GetModuleData()
        {
            try
            {
                string query = @"SELECT * FROM ModuleInformation";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable SearchModule(string moduleCode)
        {
            try
            {
                SqlConnection con = new SqlConnection(connect);

                con.Open();

                SqlCommand cmd = new SqlCommand(@"SELECT * FROM ModuleInformation WHERE ModuleCode=@ModuleCode", con);

                cmd.Parameters.AddWithValue("ModuleCode", moduleCode);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Check if any rows were returned
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    // ModuleCode does not exist, show a message box
                    MessageBox.Show("Module Code does not exist.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return GetModuleData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Search Module Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return GetModuleData();
            }
        }

        public void AddModule(Module module)
        {
            UserHandler userHandler = new UserHandler();
            try
            {
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    string query = @"INSERT INTO ModuleInformation (ModuleName, ModuleCode, ModuleDesc, LinksToResources) 
                             VALUES (@ModuleName, @ModuleCode, @ModuleDesc, @LinksToResources)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL command
                        command.Parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar)).Value = module.ModuleName;
                        command.Parameters.Add(new SqlParameter("@ModuleCode", SqlDbType.VarChar)).Value = module.ModuleCode;
                        command.Parameters.Add(new SqlParameter("@ModuleDesc", SqlDbType.NVarChar)).Value = module.ModuleDescription;
                        command.Parameters.Add(new SqlParameter("@LinksToResources", SqlDbType.NVarChar)).Value = module.ModuleLinks;

                        bool success = userHandler.ValidateModule(module);
                        if (success)
                        {
                            // Execute the SQL command
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Module {module.ModuleCode}: Added.", "Add Module Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Validation of Module data failed. Please Enter valid Data.", "Module Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Insert Module Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateModule(Module module)
        {
            try
            {
                UserHandler userHandler = new UserHandler();
                using (SqlConnection connection = new SqlConnection(connect))
                {
                    connection.Open();

                    string query = @"UPDATE ModuleInformation
                             SET ModuleName = @ModuleName,
                                 ModuleDesc = @ModuleDesc,
                                 LinksToResources = @LinksToResources
                             WHERE ModuleCode = @ModuleCode";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        bool success = userHandler.ValidateModule(module);

                        if (success)
                        {
                            // Add parameters to the SQL command
                            command.Parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar)).Value = module.ModuleName;
                            command.Parameters.Add(new SqlParameter("@ModuleDesc", SqlDbType.NVarChar)).Value = module.ModuleDescription;
                            command.Parameters.Add(new SqlParameter("@LinksToResources", SqlDbType.NVarChar)).Value = module.ModuleLinks;
                            command.Parameters.Add(new SqlParameter("@ModuleCode", SqlDbType.VarChar)).Value = module.ModuleCode;

                            // Execute the SQL command
                            command.ExecuteNonQuery();

                            MessageBox.Show($"Module {module.ModuleCode} updated successfully.", "Module Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Validation of Module data failed. Please Enter valid Data.", "Module Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Update Module Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteModule()
        {
            string moduleCode = "";
            bool success = false;

            try
            {
                // Show an input box to enter the module code
                string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Module Code:", "Module Code Input", "");

                // Check if the user clicked Cancel or entered an empty string
                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Operation canceled or no input provided.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!string.IsNullOrEmpty(input))
                {
                    moduleCode = input.ToUpper();
                    success = true;
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid module code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred when giving input. Please retry.\n{ex}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connect))
                    {
                        connection.Open();

                        // DELETE query based on ModuleCode
                        string query = @"DELETE FROM ModuleInformation WHERE ModuleCode = @ModuleCode";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for ModuleCode
                            command.Parameters.Add(new SqlParameter("@ModuleCode", SqlDbType.VarChar)).Value = moduleCode;

                            // Execute the SQL command
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Module {moduleCode} deleted successfully.", "Delete Module Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show($"Module {moduleCode} not found.", "Delete Module Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Delete Module Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
