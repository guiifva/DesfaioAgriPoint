using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.BaseEntity
{
    public class BaseEntityViewModel
    {
        public long Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
