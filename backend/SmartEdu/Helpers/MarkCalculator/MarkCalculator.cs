using SmartEdu.Entities;
using SmartEdu.Models;

public static class MarkCalculator
{
    public static double CalculateGPA(List<Mark> marks, MarkFilterOption markFilterOption)
    {
        // Calculate GPA for a single semester
        if (markFilterOption.Semester == 1 || markFilterOption.Semester == 2)
        {
            return CalculateGPASemester(marks, markFilterOption);
        }

        // Calculate GPA for a summary year
        // 1.1 Calculate the avarage marks of semester 1
        var marksSemester1 = (marks.Where<Mark>(m => m.Semester == 1 && m.FromYear == markFilterOption.FromYear && m.ToYear == markFilterOption.ToYear)).ToArray<Mark>();
        var marksSemester2 = (marks.Where<Mark>(m => m.Semester == 2 && m.FromYear == markFilterOption.FromYear && m.ToYear == markFilterOption.ToYear)).ToArray<Mark>();
        double sum = 0;
        foreach (var m1 in marksSemester1)
        {
            var average1 = CalculateAverageMark(m1);
            var m2 = marksSemester2.FirstOrDefault<Mark>(mark => mark.SubjectId == m1.SubjectId);
            var average2 = CalculateAverageMark(m2);
            sum += (average1 + average2 * 2) / 3;
        }
        return sum / marksSemester1.Length;
    }

    private static double CalculateGPASemester(List<Mark> marks, MarkFilterOption markFilterOption)
    {
        var marksFiltered = (marks.Where<Mark>(m => m.Semester == markFilterOption.Semester && m.FromYear == markFilterOption.FromYear && m.ToYear == markFilterOption.ToYear)).ToArray<Mark>();
        double sum = 0.0;
        foreach (var m in marksFiltered)
        {
            var average = CalculateAverageMark(m);
            sum += average;
        }
        return sum / marksFiltered.Length;
    }

    private static double CalculateAverageMark(Mark mark)
    {
        return (double)(mark.Oral_1 + mark.Oral_2 + mark.Test15_1 + mark.Test15_2 + mark.Test15_3 + mark.Test45_1 * 2 + mark.Test45_2 * 2 + mark.Test60 * 3) / 12;
    }

    
}