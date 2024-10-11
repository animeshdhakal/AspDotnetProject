using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientApp.Dtos;
using PatientApp.Dtos.Patient;
using PatientApp.Mappers;
using PatientApp.Models;
using PatientApp.Repository;

namespace PatientApp.Controllers;

[ApiController]
[Route("api/patient")]
[Authorize]
public class PatientController(IPatientRepository patientRepo) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatients(int page = 1, int pageSize = 10)
    {
        var patients = await patientRepo.GetAll();

        var count = await patients.CountAsync();
        var pageCount = (int)Math.Ceiling(count / (double)pageSize);

        patients = patients.Skip((page - 1) * pageSize).Take(pageSize);

        int? nextPage = page >= pageCount ? null : page + 1;
        int? previousPage = page == 1 ? null : page - 1;

        var patientsDto = await patients.Select(p => p.ToDto()).ToListAsync();

        return Ok(new PaginatedResponse<PatientDto>
        {
            Success = true,
            Data = new Pagination<PatientDto>
            {
                Page = page,
                NextPage = nextPage,
                PreviousPage = previousPage,
                Count = pageCount,
                Results = patientsDto
            }
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = await patientRepo.GetById(id);

        if (patient == null)
            return NotFound(new Response<PatientDto>
            {
                Success = false,
                Message = "Patient not found"
            });

        return Ok(new Response<PatientDto>
        {
            Success = true,
            Data = patient.ToDto()
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(CreatePatientDto createPatientDto)
    {
        var patient = createPatientDto.ToModel();
        await patientRepo.Add(patient);

        return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, new Response<PatientDto>
        {
            Success = true,
            Message = "Patient added successfully",
            Data = patient.ToDto()
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, UpdatePatientDto updatePatientDto)
    {
        var existingPatient = await patientRepo.GetById(id);

        if (existingPatient == null)
            return NotFound(new Response<Patient>
            {
                Success = false,
                Message = "Patient not found"
            });

        existingPatient.Name = updatePatientDto.Name;
        existingPatient.Age = updatePatientDto.Age;
        existingPatient.Address = updatePatientDto.Address;
        existingPatient.Phone = updatePatientDto.Phone;
        existingPatient.Doctor = updatePatientDto.Doctor;
        existingPatient.Prescription = updatePatientDto.Prescription;
        existingPatient.Diagnosis = updatePatientDto.Diagnosis;

        await patientRepo.Update(existingPatient);

        return Ok(new Response<Patient>
        {
            Success = true,
            Message = "Patient updated successfully",
            Data = existingPatient
        });
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await patientRepo.GetById(id);

        if (patient == null)
            return NotFound(new Response<Patient>
            {
                Success = false,
                Message = "Patient not found"
            });

        await patientRepo.Delete(patient);

        return Ok(new Response<object>
        {
            Success = true,
            Message = "Patient deleted"
        });
    }
}