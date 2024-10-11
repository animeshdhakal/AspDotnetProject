namespace PatientApp.Dtos;

public class Pagination<T>
{
    public int Page { get; set; }
    
    public int? NextPage { get; set; }
    
    public int? PreviousPage { get; set; }

    public int? Count { get; set; }
    
    public List<T> Results { get; set; } = new List<T>();
}