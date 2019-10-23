using AutoMapper;
using Business.Interfaces;
using Data.Models;
using Data.Repository.Interfaces;
using ViewModel.Company;

namespace Business.Implementations
{
    public class CompanyService : ServiceCrud<Company, CompanyViewModel>, ICompanyService
    {
        public CompanyService(ICompanyRepository repository,
                                IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
