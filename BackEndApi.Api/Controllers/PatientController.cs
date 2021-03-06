﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndApi.Domain.Interfaces;
using BackEndApi.Domain.Models;

namespace BackEndApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        [HttpGet]
        public IActionResult Get() {
            return Ok( _patientRepository.GetAll());
        }
        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _patientRepository.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {            
            return Ok(await _patientRepository.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Patient model)
        {
            await _patientRepository.Create(model);
            return Ok(new
            {
                message = "Patient added successfully."
            });
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id,Patient model)
        {          
            await _patientRepository.Update(id,model);
            return Ok(new
            {
                message = "Patient is updated successfully."
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientRepository.Delete(id);
            return Ok(new
            {
                message = "Patient is deleted successfully."
            });
        }

    }
}