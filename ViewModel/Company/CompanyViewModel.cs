﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.BaseEntity;

namespace ViewModel.Company
{
    public class CompanyViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Digite apenas os numeros do Cnpj!")]
        public string Cnpj { get; set; }

    }
}
