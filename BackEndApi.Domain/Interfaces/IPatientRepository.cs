using System;
using System.Collections.Generic;
using System.Text;
using WoundExpert.Domain.Models;

namespace WoundExpert.Domain.Interfaces
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
    }
}
