using System.Globalization;

namespace MyRecipeBook.Domain.Extensions;

public static class DateTimeInTimeZone
{
    public static DateTime Brasilia()
    {
        var timeZoneId = OperatingSystem.IsWindows()
            ? "E. South America Standard Time"  
            : "America/Sao_Paulo";               
        var brasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, brasiliaTimeZone);
    }

    public static string DayToday(this DateTime date)
    {
       return date.ToString("dddd", CultureInfo.InvariantCulture).ToUpper();
    }    
    
    public static string DateToday(this DateTime date)
    {
       return date.ToString("yyyy-MM-dd");
    }
    
    
}