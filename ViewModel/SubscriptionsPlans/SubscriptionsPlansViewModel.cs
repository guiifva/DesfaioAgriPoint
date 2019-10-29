using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel.BaseEntity;

namespace ViewModel.SubscriptionsPlans
{
    public class SubscriptionsPlansViewModel : BaseEntityViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PlanName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Description { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int PlanMonths { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Value { get; set; }
    }
}
