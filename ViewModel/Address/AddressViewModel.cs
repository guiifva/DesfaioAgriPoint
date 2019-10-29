using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.BaseEntity;

namespace ViewModel.Address
{
    public class AddressViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string City { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Street { get; set; }
        public int PlaceNumber { get; set; }
        public string Complement { get; set; }
    }
}
