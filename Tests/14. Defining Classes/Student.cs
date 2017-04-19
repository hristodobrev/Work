public class Student
{
    private static int StudentsCount = 0;

    public Student(string firstName, string lastName,
        string university)
        : this(firstName, null, lastName, null, null, university, null, null)
    {
    }

    public Student(string firstName, string lastName,
        string speciality, string university, string email)
        : this(firstName, null, lastName, null, speciality, university, email, null)
    {
    }

    public Student(string firstName, string lastName, string course,
        string speciality, string university, string email)
        : this(firstName, null, lastName, course, speciality, university, email, null)
    {
    }

    public Student(string firstName, string middleName, string lastName,
        string course, string speciality, string university,
        string email, string phoneNumber)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.Course = course;
        this.Speciality = speciality;
        this.University = university;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
        StudentsCount++;
    }

    public static int StudentsRegistered
    {
        get { return StudentsCount; }
    }

    public string FirstName { get; set; }
    
    public string MiddleName { get; set; }
    
    public string LastName { get; set; }
    
    public string Course { get; set; }
    
    public string Speciality { get; set; }
    
    public string University { get; set; }
    
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public override string ToString()
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();

        result.AppendLine("First name: " + this.FirstName);
        if (this.MiddleName != null)
        {
            result.AppendLine("Middle name: " + this.MiddleName);
        }
        result.AppendLine("Last name: " + this.LastName);

        result.AppendLine("University: " + this.University);
        if (this.Speciality != null)
        {
            result.AppendLine("Speciality: " + this.Speciality);
        }

        if (this.Course != null)
        {
            result.AppendLine("Course: " + this.Course);
        }

        if (this.Email != null)
        {
            result.AppendLine("Email: " + this.Email);
        }

        if (this.PhoneNumber != null)
        {
            result.AppendLine("Phone number: " + this.PhoneNumber);
        }

        return result.ToString();
    }
}