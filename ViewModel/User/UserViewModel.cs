using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.Address;
using ViewModel.BaseEntity;
using ViewModel.Company;

namespace ViewModel.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public AddressViewModel Address { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
