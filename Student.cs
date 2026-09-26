internal class Student //Ment only for this project, and just for clarity (internal is already default according to google). All other public fields/properties/methods in this class will be encapsulated by this "internal" class statement
{
//*************** FIELDS ******************
    private readonly string? _studentName; //Private field created only once and cannot change. Already set to private by default (this is just to clarify).

//************ Property (standard) ***********  

//************ Property (auto-implemented) ***********  
    public List<string> Courses {get; private set;} = []; //local "Courses database" will be publically accessible by other classes/objects (i.e. objects instanciiated by the class Course). This property and the wrapped field will be accessible only within the current project (due to being wrapped in the "internal" class statement). This "courses database" will cease to exist when the program ends


//************** CONSTRUCTOR *************   

    public Student (string testStudentName) //constructor that accepts the student name argument
    {
        //simple check for null/empty/whitespace/tabs. Note, this check probably makes more sense to do this with a try-catch, so that the object does not need to be created at all if the name is not valid. This could be combined with other conditions to avoid duplicated students etc..
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
    public void Join(string courseName, Course course)
    {
        if(Courses.Contains(courseName, StringComparer.OrdinalIgnoreCase)) //use in-build system string comparer for case-insensitive string comparison (similar to toUpper, or toLower on both sides)
        {
            Console.WriteLine($"{_studentName} has already been registered to {courseName}");
        }
        else if(course.Students.Count == course.MaxSeats)
        {
            Console.WriteLine($"{courseName} is full, {_studentName} can not be added to this course");
        }
        else
        {
        Courses.Add(courseName);
        course.Students.Add(_studentName!); //Note: _studentName cannot be null, constructor does not allow that
        }
    }

    //method to leave a course
     public void Leave(string course, Course courseName)
    {
        if(Courses.Remove(course))
        {
        courseName.Students.Remove(_studentName!); //Sync with the Course object. Note: _studentName cannot be null, constructor does not allow that
        }
        else
        {
            Console.WriteLine($"{_studentName} does not exist");
        }
    }
    
    //method to print all courses that the current student is attending
        public void Schedule()
    {
        Console.WriteLine($"These are all the courses that {_studentName} is enrolled in:");
        foreach(string course in Courses)
        {
            Console.WriteLine(course);
        }
    }

    //Method to override ToString and return the name of the current object instead, without the full path. To be combined i.e. with "(current student number/maxSeats)
    public override string ToString()
    {
        string courseName = this.GetType().Name; //get the "name" from the "(Get)Type" path of "this" current object. Dynamic code that always point to the current object name.
        return courseName;
    }
}
