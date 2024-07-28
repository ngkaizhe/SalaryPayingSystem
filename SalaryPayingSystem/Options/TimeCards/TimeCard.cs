namespace SalaryPayingSystem.Options.TimeCards;

public class TimeCard(DateTime date, int hours)
{
    public DateTime Date { get; } = date;
    public int Hours { get; } = hours;
}