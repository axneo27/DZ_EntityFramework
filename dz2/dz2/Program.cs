using dz2.Entities;
using Microsoft.EntityFrameworkCore;

namespace dz2
{
    class Program
    {
        static void DeleteAllData(AppDbContext context)
        {
            context.StudentsCourses.RemoveRange(context.StudentsCourses);
            context.SaveChanges();

            context.StudentCards.RemoveRange(context.StudentCards);
            context.SaveChanges();

            context.Students.RemoveRange(context.Students);
            context.SaveChanges();

            context.Courses.RemoveRange(context.Courses);
            context.SaveChanges();

            context.Teachers.RemoveRange(context.Teachers);
            context.SaveChanges();
        }

        static void GetAllData(AppDbContext context)
        {
            var students = context.Students
                .Include(s => s.StudentCard)
                .Include(s => s.Courses)
                .ToList();

            var teachers = context.Teachers
                .Include(t => t.Courses)
                .ToList();

            var courses = context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .ToList();

            var studentCards = context.StudentCards
                .Include(sc => sc.Student)
                .ToList();

            var studentsCourses = context.StudentsCourses.ToList();

            foreach (var student in students) PrintStudent(student);
            foreach (var teacher in teachers) PrintTeacher(teacher);
            foreach (var course in courses) PrintCourse(course);
            foreach (var studentCard in studentCards) PrintStudentCard(studentCard);
            foreach (var sc in studentsCourses) PrintStudentsCourses(sc);
        }

        static void PrintStudent(Student student)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, StudentCardId: {student.StudentCardId}");
            if (student.StudentCard != null)
                Console.WriteLine($"Student Card: {student.StudentCard.CardNumber}");

            Console.WriteLine("Courses:");
            foreach (var course in student.Courses)
                Console.WriteLine($"- {course.Title}");
        }

        static void PrintTeacher(Teacher teacher)
        {
            Console.WriteLine($"Id: {teacher.Id}, Name: {teacher.Name}, Subject: {teacher.Subject}");
            Console.WriteLine("Courses:");
            foreach (var course in teacher.Courses)
                Console.WriteLine($"- {course.Title}");
        }

        static void PrintCourse(Course course)
        {
            Console.WriteLine($"Id: {course.Id}, Title: {course.Title}, Credits: {course.Credits}");
            if (course.Teacher != null)
                Console.WriteLine($"Teacher: {course.Teacher.Name}");

            Console.WriteLine("Students:");
            foreach (var student in course.Students)
                Console.WriteLine($"- {student.Name}");
        }

        static void PrintStudentCard(StudentCard studentCard)
        {
            Console.WriteLine($"Id: {studentCard.Id}, CardNumber: {studentCard.CardNumber}");
            if (studentCard.Student != null)
                Console.WriteLine($"Student: {studentCard.Student.Name}");
        }

        static void PrintStudentsCourses(StudentsCourses sc)
        {
            Console.WriteLine($"StudentId: {sc.StudentId}, CourseId: {sc.CourseId}");
        }

        static void AddStudent(AppDbContext context, Student student, StudentCard studentCard)
        {
            student.StudentCard = studentCard;
            context.Students.Add(student);
            context.SaveChanges();
        }

        static void AddTeacher(AppDbContext context, Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
        }

        static void AddCourse(AppDbContext context, Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        static void AddStudentToCourse(AppDbContext context, int studentId, int courseId)
        {
            var sc = new StudentsCourses { StudentId = studentId, CourseId = courseId };
            context.StudentsCourses.Add(sc);
            context.SaveChanges();
        }

        static void UpdateStudentName(AppDbContext context, int studentId, string newName)
        {
            var student = context.Students.Find(studentId);
            if (student != null)
            {
                student.Name = newName;
                context.SaveChanges();
            }
        }

        static void UpdateTeacherSubject(AppDbContext context, int teacherId, string newSubject)
        {
            var teacher = context.Teachers.Find(teacherId);
            if (teacher != null)
            {
                teacher.Subject = newSubject;
                context.SaveChanges();
            }
        }

        static void UpdateCourseCredits(AppDbContext context, int courseId, int newCredits)
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                course.Credits = newCredits;
                context.SaveChanges();
            }
        }

        static void DeleteStudent(AppDbContext context, int studentId)
        {
            var student = context.Students.Include(s => s.StudentCard).FirstOrDefault(s => s.Id == studentId);
            if (student != null)
            {
                context.StudentCards.Remove(student.StudentCard);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }

        static void DeleteTeacher(AppDbContext context, int teacherId)
        {
            var teacher = context.Teachers.Find(teacherId);
            if (teacher != null)
            {
                context.Teachers.Remove(teacher);
                context.SaveChanges();
            }
        }

        static void DeleteCourse(AppDbContext context, int courseId)
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            //DeleteAllData(context);
            //AddStudent(context, new Student { Name = "John Doeeeee" }, new StudentCard { CardNumber = "SC12345" });

            //DeleteTeacher(context, 3);
            // AddTeacher(context, new Teacher { Name = "New Teacher", Subject = "History" });
            // var historyTeacherId = context.Teachers.First(t => t.Name == "New Teacher").Id;
            // AddCourse(context, new Course { Title = "World History", Credits = 3, Description = "Desc", TeacherId = historyTeacherId });

            // AddStudent(context, new Student { Name = "New Student" }, new StudentCard { CardNumber = "SC99999" });
            var newStudentId = context.Students.First(s => s.Name == "New Student").Id;
            var newCourseId = context.Courses.First(c => c.Title == "World History").Id;
            AddStudentToCourse(context, newStudentId, newCourseId);

            //GetAllData(context);
        }
    }
}

