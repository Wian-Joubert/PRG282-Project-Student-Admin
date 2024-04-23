namespace PRG_282_project
{
    public class Student
    {
        public int StudentNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ModuleCodes { get; set; }
        public string ImageData { get; set; }


        public Student(int studentNumber, string name, string surname, string gender, DateTime dob, string phoneNumber, string address, string moduleCodes, byte[] imageData)
        {
            StudentNumber = studentNumber;
            Name = name;
            Surname = surname;
            Gender = gender;
            DOB = dob;
            PhoneNumber = phoneNumber;
            Address = address;
            ModuleCodes = moduleCodes;
            ImageData = Convert.ToBase64String(imageData);
        }
    }

}

