using ViewModel.BaseEntity;

namespace ViewModel.SubscriptionPlans
{
    public class SubscriptionPlanViewModel : BaseEntityViewModel
    {
        public string PlanName { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
    }
}
