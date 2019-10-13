using System;
using System.Collections.Generic;
using System.Text;
using WoundExpert.Domain.Interfaces;
using WoundExpert.Domain.Models;

namespace WoundExpert.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(WoundExpertDataContext dbContext) : base(dbContext)
        {
        }
    }
}
