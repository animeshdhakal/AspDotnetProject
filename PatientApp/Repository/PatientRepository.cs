using PatientApp.Data;
using PatientApp.Models;

namespace PatientApp.Repository;

public class PatientRepository(ApplicationDbContext context) : Repository<Patient>(context), IPatientRepository;