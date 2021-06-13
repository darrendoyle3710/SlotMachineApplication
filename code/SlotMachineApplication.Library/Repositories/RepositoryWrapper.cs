using SlotMachineApplication.Library.Data;
using SlotMachineApplication.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachineApplication.Library.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        ISpinRepository _spins;

        public ISpinRepository Spins
        {
            get
            {
                if (_spins == null)
                {
                    _spins = new SpinRepository(_repoContext);
                }
                return _spins;
            }
        }
       

        void IRepositoryWrapper.Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
