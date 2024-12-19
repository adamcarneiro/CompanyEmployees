using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts {
    public interface ICompanyService {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto GetCompany(Guid id, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto company);
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);
        
        //Delete a company
        void DeleteCompany(Guid companyId, bool trackChanges);

        //Update a Company
        void UpdateCompany(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
    }
}
