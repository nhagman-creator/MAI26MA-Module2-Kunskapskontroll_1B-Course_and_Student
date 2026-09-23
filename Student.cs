internal class Student //Only for this project, just for clarity (internal is already default according to google). All other public fields/properties/methods in this class will be encapsulated by this "internal" class statement
{
    private string _name;//Hidden field only for the created instance/object. Already set to private by default (this is just to clarify)    List<string> courses

    public static List<string> Courses = []; //local student "database" accessible within the project, and that exists only temporarily when the program is running

    public Student (string name) //constructor that accepts the student name argument
    {
        NameExists = name;
    }

    //the student name argument is passed on to the Property so it can be checked with a condition (if the student already exists)
    public string NameExists
    {
        get
        {
            return NameExists;
        }
        set
        {
            //check if the student already exist, if not true, save the hidden field _name
            if(!Course.students.Contains(value))
            {
                _name = value;
            }
            else
            {   
                //else student exists (or upgrade the code to CALL A FUNCTION for repeating reader input until valid name that is not null)
                Console.WriteLine("The student is already registered.\nReturning to main menu");
            }
        }
    }

    //method to join a course, check conditions for doublet names
    public void Join(string course)
    {
        Student.Courses.Add(course);
        Course.students.Add(_name);
    }

    //method to leave a course
     public void Leave(string course)
    {
        Student.Courses.Remove(course);
        Course.students.Remove(_name);
    }

    //method to print all courses that the current student is attending
        public void RollCall()
    {
        foreach(string course in courses)
        {
            Console.WriteLine(course);
        }
    }
}
