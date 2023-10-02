using SmartEdu.Entities;
using SmartEdu.Helpers.DatetimeFormatter;

namespace SmartEdu.Helpers.AcademicRandomer
{
    public static class AcademicRandomer
    {
        public static bool ContainsDate(this Dictionary<DateTime, AcademicTracker> dictionary, DateTime date)
        {
            var keys = dictionary.Keys.ToArray<DateTime>();
            return keys.Any<DateTime>(k => k.Date == date.Date);
        }

        public static AcademicTracker GetAcademicTrackerAtDate(this Dictionary<DateTime, AcademicTracker> dictionary, DateTime date)
        {
            var values = dictionary.Values.ToArray<AcademicTracker>();
            return values.FirstOrDefault<AcademicTracker>(v => v.Date.Date == date.Date, null);
        }

        public static string BuildAttendance(AcademicProgress academicProgress)
        {
            var subject = academicProgress.Timetable.Teacher.Subject.Name;
            var fromTo = SmartEdu.Helpers.DatetimeFormatter.DatetimeFormatter.BuildFromTo(academicProgress.Timetable.From, academicProgress.Timetable.To);
            switch (academicProgress.Attendance)
            {
                case -2:
                    return $"Being late in {subject} lecture {fromTo}.|";
                case -1:
                    return $"Absent without leave in {subject} lecture {fromTo}.|";
                case 0:
                    return $"Absent with leave in {subject} lecture {fromTo}.|";
                default:
                    return null;
            }
        }
        
        public static string BuildHomework(AcademicProgress academicProgress)
        {
            var subject = academicProgress.Timetable.Teacher.Subject.Name;
            var fromTo = SmartEdu.Helpers.DatetimeFormatter.DatetimeFormatter.BuildFromTo(academicProgress.Timetable.From, academicProgress.Timetable.To);
            return academicProgress.IsDoneHomework ? null : $"Not done homework in {subject} lecture {fromTo}.|";
        }

        public static string BuildTeacherComment(AcademicProgress academicProgress)
        {
            if (academicProgress.TeacherComment is null || academicProgress.TeacherComment == "Nothing to comment.") return null;
            var subject = academicProgress.Timetable.Teacher.Subject.Name;
            var fromTo = SmartEdu.Helpers.DatetimeFormatter.DatetimeFormatter.BuildFromTo(academicProgress.Timetable.From, academicProgress.Timetable.To);
            return academicProgress.TeacherComment + "|";
        }
    }
}