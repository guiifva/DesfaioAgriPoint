using System;
using System.ComponentModel.DataAnnotations;
using Data.Models;
using ViewModel.BaseEntity;

namespace ViewModel.Order
{
    public class OrderViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [RegularExpression("^(\\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\\}{0,1})$",
            ErrorMessage = "Id de usuario inválido!")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long SubscriptionPlanId { get; set; }

        public long CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }

    }
}
