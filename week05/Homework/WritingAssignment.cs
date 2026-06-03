using System;

// WritingAssignment also inherits from Assignment. It adds the title of the paper.
public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // I need the student name here, but it is private in the base class, so I call
    // the GetStudentName() getter instead of using _studentName directly.
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}
