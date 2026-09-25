internal class Student //Ment only for this project, and just for clarity (internal is already default according to google). All other public fields/properties/methods in this class will be encapsulated by this "internal" class statement
{
//*************** FIELDS ******************
    private readonly string? _studentName; //Hidden field created only once and cannot change. Already set to private by default (this is just to clarify). No need for a method to set the name after creating the Course instance

    public List<string> Courses = []; //local "Courses database" will be publically accessible by other classes/objects (i.e. objects instanciiated by the class Student). This property and the wrapped field will be accessible only within the current project (due to being wrapped in the "internal" class statement). This enrolled "course database" will cease to exist when the program ends


//************** CONSTRUCTOR *************   

    public Student (string testStudentName) //constructor that accepts the student name argument
    {
        //simple check for null/empty/whitespace/tabs 
        if (string.IsNullOrWhiteSpace(testStudentName))
        {
            _studentName = "invalid";
        }
        else
        {
            _studentName = testStudentName;
        }
    }
//************* METHODS ******************
    //method to join a course, check conditions for doublet names
    public void Join(string course, Course courseName)
    {
        Courses.Add(course);
        courseName.Students.Add(_studentName!); //Note: _studentName cannot be null, constructor does not allow that
    }

    //method to leave a course
     public void Leave(string course, Course courseName)
    {
        Courses.Remove(course);
        courseName.Students.Remove(_studentName!); //Note: _studentName cannot be null, constructor does not allow that
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
