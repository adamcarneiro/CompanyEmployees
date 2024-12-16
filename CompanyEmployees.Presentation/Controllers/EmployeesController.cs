using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers {
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController: ControllerBase {
        private readonly IServiceManager _services;
        public EmployeesController (IServiceManager services)
            => _services = services;

        //[HttpGet("{id:guid}")]
        [HttpGet]
        public IActionResult GetEmployeesForComapny(Guid companyId) 
        {
            var employees = _services.EmployeeService.GetEmployees(companyId, trackChanges: false);
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeForComapny(Guid companyId, Guid id) {
            var employee = _services.EmployeeService.GetEmployee(companyId, id, trackChanges: false);
            return Ok(employee);
        }
    }
}
