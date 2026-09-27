//Create 4 courses
Course course1 = new("C");
Course course2 = new("C+");
Course course3 = new("C++");
Course course4 = new("C-sharp");

//create 4 students
Student student1 = new("Kalle");
Student student2 = new("Laban");
Student student3 = new("Niklas");
Student student4 = new("Nils");

// 1) try to enroll 4 students (Max capacity is 3 students)
Console.WriteLine("\n1) try to enroll 4 students (Max capacity is 3 students)");
course1.Enroll("Kalle", student1);
course1.Enroll("Laban", student2);
course1.Enroll("Niklas", student3);
course1.Enroll("Nils", student4);

// 2) check that the course is really full: "Course 3/3 places"
Console.WriteLine("\n2) check that the course is really full: 'Course 3/3 places'");
Console.WriteLine(course1.ToString());

// 3) check that all 3 students were added - exept the 4th one Nils that was not added
Console.WriteLine("\n3) check that all 3 students were added - exept the 4th one Nils that was not added");
course1.RollCall();

// 4) try to remove the 4th student Nils (who was never enrolled)
Console.WriteLine("\n4) try to remove the 4th student Nils (who was never enrolled)");
course1.Remove("Nils", student4);

// 5) remove an existing 3rd student Niklas
Console.WriteLine("\n5) remove an existing 3rd student Niklas");
course1.Remove("Niklas", student3);

// 6) check that Niklas was removed, and there are only 2 students enrolled
Console.WriteLine("\n6) check that Niklas was removed, and there are only 2 students enrolled");
course1.RollCall();
Console.WriteLine(course1.ToString());

// 7) try to enroll the 1st student Kalle again
Console.WriteLine("\n7) try to enroll the 1st student Kalle again");
course1.Enroll("Kalle", student1);

// 8) check that only the 1st student (Kalle) and 2nd student (Laban) are registered in C
Console.WriteLine("\n8) check that only the 1st student (Kalle) and 2nd student (Laban) are registered in C");
student1.Schedule();
student2.Schedule();
student3.Schedule();
student4.Schedule();

// 9) Let 1st student Kalle join 3 more courses
Console.WriteLine("\n9) Let 1st student Kalle join 3 more courses");
student1.Join("C+",course2);
student1.Join("C++",course3);
student1.Join("C-sharp",course4);

// 10) Check that Kalle is now enrolled in 4 courses
Console.WriteLine("\n10) Check that Kalle is now enrolled in 4 courses");
student1.Schedule();

// 11) check that all 4 courses now contain Kalle
Console.WriteLine("\n11) check that all 4 courses now contain Kalle");
course1.RollCall();
course2.RollCall();
course3.RollCall();
course4.RollCall();

// 12) try make 3 more students join 4th course (C-sharp)
Console.WriteLine("\n12) try make 3 more students join 4th course (C-sharp)");
student2.Join("C-sharp",course4);
student3.Join("C-sharp",course4);
student4.Join("C-sharp",course4);

// 13) try to make the 4th student (Nils) leave the 4th course (C-sharp)
Console.WriteLine("\n13) try to make the 4th student (Nils) leave the 4th course (C-sharp)");
student4.Leave("C-sharp",course4);

// 14) check that the 4th student (Nils) was never enrolled in any courses
Console.WriteLine("\n14) check that the 4th student (Nils) was never enrolled in any courses");
student4.Schedule();

// 15) check that the 4th student (Nils) still exist
Console.WriteLine("\n15) check that the 4th student (Nils) still exist");
Console.WriteLine($"{student4.ToString()} exists!");