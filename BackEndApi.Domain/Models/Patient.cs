using System;
using System.Collections.Generic;
using System.Text;
using BackEndApi.Domain.Interfaces;

namespace BackEndApi.Domain.Models
{
    public class Patient: IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public int? PhysicianId { get; set; }        
    }
}
