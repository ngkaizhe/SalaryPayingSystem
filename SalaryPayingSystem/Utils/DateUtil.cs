namespace SalaryPayingSystem.Utils;

public static class DateUtil
{
    public static bool IsInBetween(this DateTime payDateTime, DateTime startDateTime, DateTime endDateTime)
    {
        return payDateTime >= startDateTime && payDateTime <= endDateTime;
    }
    
    public static bool IsLastDayOfMonth(this DateTime date)
    {
        return date.AddDays(1).Month != date.Month;
    }
}