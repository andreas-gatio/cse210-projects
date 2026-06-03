using System;

// This is the base class. The Math and Writing assignments will inherit from it
// since they both share a student name and a topic.
public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // The child classes can't touch _studentName directly because it is private,
    // so I made this getter for them to use instead.
    public string GetStudentName()
    {
        return _studentName;
    }
}
