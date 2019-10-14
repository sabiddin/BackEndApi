using System;
using System.Collections.Generic;
using System.Text;
using BackEndApi.Domain.Models;

namespace BackEndApi.Domain.Interfaces
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
    }
}
