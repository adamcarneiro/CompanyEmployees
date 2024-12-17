﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service {
    internal sealed class EmployeeService: IEmployeeService {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreationDto, bool trackChanges) {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company == null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreationDto);

            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid employeeId, bool trackChanges) {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeDb = _repository.Employee.GetEmployee(companyId, employeeId, trackChanges);
            if(employeeDb is null)
                throw new EmployeeNotFoundException(employeeId);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges) {
            var company = _repository.Company.GetCompany(companyId,trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
            var emoloyeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);

            return emoloyeesDto;
        }
    }
}
