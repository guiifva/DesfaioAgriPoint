using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.Company;

namespace Business.Interfaces
{
    public interface ICompanyService : IServiceCrud<Company, CompanyViewModel>
    {
    }
}
