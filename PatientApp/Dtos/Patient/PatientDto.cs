namespace PatientApp.Dtos.Patient;

public class PatientDto
{
  public int Id { get; set; }
  
  public String Name { get; set; } = String.Empty;

  public String Address { get; set; } = String.Empty;

  public String Phone { get; set; } = String.Empty;

  public int Age { get; set; }

  public String Doctor { get; set; } = String.Empty;

  public String Diagnosis { get; set; } = String.Empty;

  public String Prescription { get; set; } = String.Empty;  
}