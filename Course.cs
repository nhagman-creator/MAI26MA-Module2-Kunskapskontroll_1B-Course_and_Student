internal class Course //This class is meant only for this project, and just for clarity (internal is already default according to google). All other public fields/properties/methods in this class will be encapsulated by this "internal" class statement
{
//*************** FIELDS ******************
    private readonly string? _courseName; //Hidden field created only once and cannot change. Already set to private by default (this is just to clarify). No need for a method to set the name after creating the Course instance
    private int MaxSeats {get;set;} = 30; //Preset to 30. For additional conditions, such as reject negative values etc.., wrapping the field in additional conditional properties will be required. For now a default value 30, and an option to change it will suffice
    
    public List<string> Students {get; set;} = []; //local enrolled students "database" will be publically accessible by other classes/objects (i.e. objects instanciiated by the class Course). This property and the wrapped field will be accessible only within this current project (due to whole class being wrapped in the "internal" statement). This enrolled "student database" will cease to exist when the program ends

 //************** CONSTRUCTOR *************   
    public Course (string testCourseName)
    {
        //simple check for null/empty/whitespace/tabs 
        if (string.IsNullOrWhiteSpace(testCourseName))
        {
            _courseName = "invalid";
        }
        else
        {
            _courseName = testCourseName;
        }
    }


//************* METHODS ******************
    //Method to enroll a students. Conditions: if not already registered, or the Course is not full, then register
    public void Enroll (string studentName, Student student)
    {
        if(Students.Contains(studentName))
        {
            Console.WriteLine($"{studentName} has already been registered to {_courseName!.ToString()}"); //Note: CourseName cannot be null, the constructor does not allow that. Testing the ToString method here
        }
        else if(Students.Count <= MaxSeats)
        {
            Console.WriteLine($"{_courseName} is full, {studentName} can not be added to this course");
        }
        else
        {
            Students.Add(studentName);
            student.Courses.Add(_courseName!);
        }
    }

    //method to remove a student. Condition: if student exist, remove him, else notify that the student does not exist
    public void Remove (string studentName, Student student)
    {
        if(Students.Contains(studentName))
        {
            Students.Remove(studentName);
            student.Courses.Remove(studentName);
        }
        else
        {
            Console.WriteLine($"{student} does not exist");
            student.Courses.Remove(studentName); //Sync with the student object
        }
    }
    
    //Method to print all students in the course
    public void RollCall()
    {
        foreach(string student in Students)
        {
            Console.WriteLine(student);
        }
    }

    //Method to override ToString and return "Course name" instead. To be combined i.e. with "(current student number/maxSeats)
    public override string ToString()
    {
        return _courseName!.ToString(); //CourseName cannot be null, its already by the constructor
    }
}