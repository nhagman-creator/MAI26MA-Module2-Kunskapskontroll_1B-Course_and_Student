internal class Course //This class is meant only for this project. Just for clarity, it is set to internal even if that is byd efault, according to google. All other public fields/properties/methods in this class should be encapsulated and overriden by this "internal" class statement
{
//*************** FIELDS ******************
    private readonly string? _courseName; //Private field created only once and does not need to be changed (should be set to private by default)

//************ Property (standard) ***********  

//************ Property (auto-implemented) ***********  
    public int MaxSeats {get;set;} = 30; //Preset to 30. For additional conditions, such as reject negative values etc.., wrapping the field in additional conditional properties will be required. For now a default value 30, and an option to change it will suffice
    
    public List<string> Students {get; private set;} = []; //local enrolled students "database" will be publically accessible by other classes/objects (i.e. objects instanciiated by the class Student). This property and the wrapped field will be accessible only within this current project (due to whole class being wrapped in the "internal" statement). This enrolled "students database" will cease to exist when the program ends

 //************** CONSTRUCTOR *************   
    public Course (string testCourseName)
    {
        //simple check for null/empty/whitespace/tabs. Note, this check probably makes more sense to do this with a try-catch, so that the object does not need to be created at all if the name is not valid. This could be combined with other conditions to avoid course-duplicates etc..
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
    //Method to enroll a students. Conditions: if the student is not already registered, or the Course is not full, then register
    public void Enroll (string studentName, Student student)
    {
        if(Students.Contains(studentName, StringComparer.OrdinalIgnoreCase)) //use in-build system string comparer for case-insensitive string comparison (similar to toUpper, or toLower on both sides)
        {
            Console.WriteLine($"{studentName} has already been registered to {_courseName}");
        }
        else if(Students.Count == MaxSeats)
        {
            Console.WriteLine($"{_courseName} is full, {studentName} can not be added to this course");
        }
        else
        {
            student.Courses.Add(_courseName!);
            Students.Add(studentName);
        }
    }

    //method to remove a student. Condition: if student was successfully removed from the course - then remove course from the student, else notify that the student does not exist
    public void Remove (string studentName, Student student)
    {
        if(Students.Remove(studentName))
        {
            student.Courses.Remove(studentName); //Sync with the student object
        }
        else
        {
            Console.WriteLine($"{student} does not exist");
        }
    }
    
    //Method to print all students in the course
    public void RollCall()
    {
        Console.WriteLine($"These are all students enrolled in {_courseName}:");
        foreach(string student in Students)
        {
            Console.WriteLine(student);
        }
    }

    //Method to override ToString and return the name of the current object instead, without the full path. To be combined i.e. with "(current student number/maxSeats)
    public override string ToString()
    {
        string courseName = this.GetType().Name; //get the "name" from the "(Get)Type" path of "this" current object. Dynamic code that always point to the current object name.
        return $"{courseName} ({Students.Count}/{MaxSeats} places)";
    }
}