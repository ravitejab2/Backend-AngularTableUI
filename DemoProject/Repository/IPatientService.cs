using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientModel>> GetAllPatientsAsync();
        Task<PatientModel> GetPatinetById(int patientId);
        Task<int> SavePatient(PatientModel patient);
        Task<int> DeletePatient(int patientId);
    }
}
