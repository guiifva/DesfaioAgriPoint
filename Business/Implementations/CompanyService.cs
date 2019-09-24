using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class CompanyService : ServiceCrud<Company>, ICompanyService
    {
        public CompanyService(ICompanyRepository repository) 
            : base(repository)
        {
        }
    }
}
