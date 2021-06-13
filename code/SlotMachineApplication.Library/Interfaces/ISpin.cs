using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Interfaces
{
    public interface ISpin
    {
        public int ID { get; set; }
        public string Animals { get; set; }
        public bool BonusBall { get; set; }
        public string Prize { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
