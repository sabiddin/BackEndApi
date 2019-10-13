using System;
using System.Collections.Generic;
using System.Text;
using WoundExpert.Domain.Interfaces;

namespace WoundExpert.Domain.Models
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
