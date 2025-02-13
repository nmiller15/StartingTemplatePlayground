using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.RandomFactProvider;

namespace Services.Interfaces
{
    public interface IRandomFactProvider
    {
        string GetFact(FactTypes factType);
    }
}
