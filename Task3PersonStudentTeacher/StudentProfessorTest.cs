namespace Task3PersonStudentTeacher;

internal static class StudentProfessorTest
{
    public static void RunTest()
    {
        var person = new Person { Age = 18 };
        person.Greet();

        var student = new Student { Age = 21 };
        student.Greet();
        student.ShowAge();
        student.Study();

        var teacher = new Teacher { Age = 40 };
        teacher.Greet();
        teacher.Explain();
    }
}
