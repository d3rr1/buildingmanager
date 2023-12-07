using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IGasContractAgent
    {
        public Task<double> GetGasContract(string id);
    }
}
