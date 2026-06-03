using System;

// MathAssignment inherits from Assignment. It only adds the section and the
// problems, because the student name and topic already live in the base class.
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // The first two parameters get passed up to the base constructor with "base".
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
