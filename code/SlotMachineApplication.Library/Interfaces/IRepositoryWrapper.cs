using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Interfaces
{
    public interface IRepositoryWrapper
    {
        ISpinRepository Spins { get; }
        void Save();
    }
}
