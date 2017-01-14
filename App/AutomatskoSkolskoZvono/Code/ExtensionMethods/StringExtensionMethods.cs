namespace AutomatskoSkolskoZvono.Code.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string ToCronExpression(this string time)
        {
            var timeArray = time.Split(':');
            var cronTime = $"{timeArray[1]} {timeArray[0]}";

            // Cron time  0 55 7 ? * MON-FRI
            return $"0 {cronTime} ? * MON-FRI";
        }
    }
}
