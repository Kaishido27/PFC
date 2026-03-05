using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFC.Domain.Models
{
    public class SystemSetting
    {
        public int Id { get; set; }
        public string AdminPassword { get; set; } = "1234";
        public string MasterKey { get; set; } = "0000";
    }
}
