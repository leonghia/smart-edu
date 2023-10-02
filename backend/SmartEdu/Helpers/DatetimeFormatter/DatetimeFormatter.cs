namespace SmartEdu.Helpers.DatetimeFormatter;

public static class DatetimeFormatter
{
    public static string BuildFromTo(DateTime from, DateTime to)
    {
        var f = from.ToString("h:mm tt");
        var t = to.ToString("h:mm tt");
        return $"({f} - {t})";
    }
}