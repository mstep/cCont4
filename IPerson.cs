using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace cCont4
{
    [ContractClass(typeof(PersonContract))]
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime DOB { get; set; }
    }
}
