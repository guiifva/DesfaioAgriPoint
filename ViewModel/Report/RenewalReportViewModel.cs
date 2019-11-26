using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Report
{
    public class RenewalReportViewModel
    {
        public long OrderId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Plan { get; set; }
        public double PlanValue { get; set; }
        public string PlanRenewalDate { get; set; }
    }
}
