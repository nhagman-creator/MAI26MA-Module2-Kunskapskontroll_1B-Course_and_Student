//Format for printing course-participants - might be moved to Course as a method, or to the menu-SWITCH-CASE later
string message1 = Course.ToString() + "("+Course.students.Count+"/"Course.maxSeats+")";
Console.WriteLine(message1);