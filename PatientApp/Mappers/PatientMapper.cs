using PatientApp.Dtos.Patient;
using PatientApp.Models;

namespace PatientApp.Mappers;

public static class PatientMapper
{
   public static PatientDto ToDto(this Patient patient)
   {
      return new PatientDto
      {
         Id = patient.Id,
         Name = patient.Name,
         Address = patient.Address,
         Phone = patient.Phone,
         Age = patient.Age,
         Doctor = patient.Doctor,
         Diagnosis = patient.Diagnosis,
         Prescription = patient.Prescription
      };
   } 
   
   public static Patient ToModel(this CreatePatientDto createPatientDto)
   {
      return new Patient
      {
         Name = createPatientDto.Name,
         Address = createPatientDto.Address,
         Phone = createPatientDto.Phone,
         Age = createPatientDto.Age,
         Doctor = createPatientDto.Doctor,
         Diagnosis = createPatientDto.Diagnosis,
         Prescription = createPatientDto.Prescription
      };
   }
   
   public static Patient ToModel(this UpdatePatientDto updatePatientDto)
   {
      return new Patient
      {
         Name = updatePatientDto.Name,
         Address = updatePatientDto.Address,
         Phone = updatePatientDto.Phone,
         Age = updatePatientDto.Age,
         Doctor = updatePatientDto.Doctor,
         Diagnosis = updatePatientDto.Diagnosis,
         Prescription = updatePatientDto.Prescription
      };
   }
}