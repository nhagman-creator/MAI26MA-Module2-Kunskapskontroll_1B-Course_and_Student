internal class Course //Only for this project, just for clarity (internal is already default according to google). All other public fields/properties/methods in this class will be encapsulated by this "internal" class statement
{
    private string Name {get; set;} //Hidden field only for the created instance/object. Already set to private by default (this is just to clarify)
    private int MaxSeats {get;set;} = 30; //Preset to 30. For additional conditions, such as reject negative values, individual more complete set{condition} code will be required
    public static List<string> students = []; //local student "database" accessible within the project, and that exists only when the program is running
    
    //Method to enroll a students
    public void Enroll (string student)
    {
        //--ADD CONDITIONS HERE i.e. check for doublets, check for MaxSeats...
        Course.students.Add(student);
        Student.Courses.Add(Name);
    }

    //method to remove a student
    public void Remove (string student)
    {
        //--ADD CONDITIONS HERE if a student doesnt exist etc..
        Course.students.Remove(student);
        Student.Courses.Remove(Name);
    }
    
    //Method to print all students in the course
    public void RollCall()
    {
        foreach(string student in students)
        {
            Console.WriteLine(student);
        }
    }

    //Method to override ToString and return "Course name" instead. To be combined i.e. with "(current student number/maxSeats)
    public override string ToString()
    {
        return Course.ToString();
    }
}