namespace SmartEdu.Helpers.TimezoneConverter
{
    public class TimezoneConverter
    {
        public static DateTime ConvertFromUtc(DateTime utcDateTime, int targetTimezoneOffsetInMinutes)
        {
            // Calculate the offset between the target timezone and UTC
            TimeSpan targetUtcOffset = TimeSpan.FromMinutes(-targetTimezoneOffsetInMinutes);

            // Convert the UTC datetime to the target timezone
            DateTime targetDateTime = utcDateTime + targetUtcOffset;

            return targetDateTime;

        }

        public static DateTime ConvertToUtc(DateTime clientDateTime, int clientTimezoneOffsetInMinutes)
        {
            // Calculate the offset between client's timezone and UTC
            TimeSpan clientUtcOffset = TimeSpan.FromMinutes(-clientTimezoneOffsetInMinutes);

            // Convert the client's datetime to UTC
            DateTime utcDateTime = clientDateTime - clientUtcOffset;

            return utcDateTime;
        }
    }
}
