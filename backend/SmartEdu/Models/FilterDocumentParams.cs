namespace SmartEdu.Models;

public class FilterDocumentParams
{
    public int SubjectId { get; set; } = 0;
    public int FromNumbersOfRating { get; set; } = 0;
    public int ToNumbersOfRating { get; set; } = 0;
    public double FromRating { get; set; } = 0;
    public double ToRating { get; set; } = 0;
}