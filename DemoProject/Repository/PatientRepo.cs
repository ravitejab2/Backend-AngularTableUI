using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class PatientRepo : IPatientService
    {
        private readonly PatientDbContext _context;
        public PatientRepo(PatientDbContext context)
        {
            _context = context;
        }
        //public async Task<int> DeletePatientss(int patientId)
        //{
        //    if (_context != null)
        //    {
        //      
        //        if (p != null)
        //        {
        //            _context.Patients.Remove(p);
        //            return await _context.SaveChangesAsync();
        //        }
        //        //var p=  _context.Database.ExecuteSqlRaw($"DeletePatient {patientId}");
        //        return 0;
               
        //    }
        //    return 0;
        //}

        public async Task<int> DeletePatient(int patientId)
        {
            if (_context != null)
            {
               
                return  _context.Database.ExecuteSqlInterpolated($"DeletePatient {patientId}");
                

            }
            return 0;
        }

        public async Task<IEnumerable<PatientModel>> GetAllPatientsAsync()
        {

            if (_context != null)
            {
                return await _context.Patients.FromSqlRaw<PatientModel>($"GetAllPatients").ToListAsync();

            }
            return null;
        }

        public async Task<PatientModel> GetPatinetById(int patientId)
        {
            if (_context != null)
            {
                return  _context.Patients.FromSqlRaw<PatientModel>($"GetPatientById {patientId}").ToList().FirstOrDefault();             
                            }
            return null;
        }

        //public async Task<int> SavePatientss(PatientModel patient)
        //{
        //    if (_context != null)
        //    {
        //       
        //        if (patient.PatientId == 0)
        //        {
        //            _context.Patients.Add(patient);
        //            return await _context.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            PatientModel p=_context.Patients.FromSqlRaw<PatientModel>($"GetPatientById {patient.PatientId}").ToList().FirstOrDefault();
        //            p.FirstName = patient.FirstName;
        //            p.LastName = patient.LastName;
        //            p.Gender = patient.Gender;
        //            patient.BirthDate = patient.BirthDate;
        //            p.JoiningDate = patient.JoiningDate;

        //            _context.Patients.Update(p);
        //           return await _context.SaveChangesAsync();


        //        }
        //        //return (PatientModel)_context.Patients.FromSqlRaw($"GetPatientById {patientId}");
               
        //    }
        //    return 0;
        //}
        public async Task<int> SavePatient(PatientModel patient)
        {
            if (_context != null)
            {
                var p=  await _context.Database.ExecuteSqlInterpolatedAsync($"AddorEditPatient {patient.PatientId},{patient.FirstName},{patient.LastName},{patient.Gender},{patient.BirthDate},{patient.JoiningDate}");
                return p;

            }
            return 0;
        }
    }
}
