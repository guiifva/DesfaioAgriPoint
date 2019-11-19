using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using ViewModel.Address;
using ViewModel.BaseEntity;

namespace ViewModel.Login
{
    public class RegisterUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserName { get; set; }

        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 11)]
        [RegularExpression("[0-9]{3}\\.?[0-9]{3}\\.?[0-9]{3}\\-?[0-9]{2}",ErrorMessage ="CPF Invalido")]
        public string Cpf { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser maior que {1}", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ser maior que {1}", MinimumLength = 6)]
        [Compare(nameof(Password), ErrorMessage = "As Senhas não conferem!")]
        public string ConfirmPassword { get; set; }

        public AddressViewModel AddressViewModel { get; set; }

        public long? CompanyId { get; set; }
    }
}
