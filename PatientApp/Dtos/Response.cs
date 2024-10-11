using Microsoft.AspNetCore.Http.HttpResults;

namespace PatientApp.Dtos;

public class Response<T> where T : class
{
    public bool Success { get; set; }

    public string Message { get; set; } = String.Empty;
    
    public T? Data { get; set; }
}