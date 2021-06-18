using SlotMachineApplication.Library.Data;
using SlotMachineApplication.Library.Interfaces;
using SlotMachineApplication.Library.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Repositories
{
    [ExcludeFromCodeCoverage]
    public class SpinRepository : Repository<Spin>, ISpinRepository
    {
        public SpinRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
