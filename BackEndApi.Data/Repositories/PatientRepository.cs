using System;
using System.Collections.Generic;
using System.Text;
using BackEndApi.Domain.Interfaces;
using BackEndApi.Domain.Models;

namespace BackEndApi.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(WoundExpertDataContext dbContext) : base(dbContext)
        {
        }
    }
}
