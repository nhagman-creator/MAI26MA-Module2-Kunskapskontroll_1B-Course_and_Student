# Title: Courses and Students - Kunskapskontroll B

**Creator:**    Arne HAgman
**Date:**       23Sep2025
**Course:**     MAI26MA - Module II - Programmering och objektorienterad utveckling i C-sharp

**Description:** A simple program that introduces the concept of object oriented programming. Here classes, fields or properties, objects, constructor, and methods will be used to create at least a Student and a Course object. In short: A course has several students, and a student can join several courses.

A summary of fields/properties and methods belongning to each class is summarized below. 

**The Course**
has (fields with/without property):
- a Name                        
- a Capacity, available slots (MaxSeats)
- a List of students   

can (methods):
- Enroll(student)
- Remove(student)
- RollCall(), or print all students in the course
- ToString(), outputs i.e. "Mathematics (2/5 seats)"

**The Student**
has (fields with/without property):
- a Name             
- a List of courses 

 can (methods):
- Join(course)
- Leave(course)
- Schedule(), print out all courses they are attending 
- Print its names using ToString()  

Additional criterias:
- Paired, both instances need to be updated when a student joins or leaves a course
- Capacity, cannot enroll more students than allowed (MaxSeats). Notifies the user if the capacity is reached
- Uniqueness, the same student cannot enroll several times to the same course.
- Handles the event of trying to remove a non-existing student from a course