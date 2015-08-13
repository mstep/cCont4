using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace cCont4
{
    /// <summary>
    /// This class defines the contract class for IPerson. Note that it's abstract, but we
    /// never define a concrete implementation - we don't have to.
    /// </summary>
    [ContractClassFor(typeof(IPerson))]
    public abstract class PersonContract : IPerson
    {
        #region IPerson Members

        public int Id
        {
            get
            {
                return default(int);
                Console.Write("xxyy");
            }
            set
            {
                Contract.Requires(value > 0);
            }
        }

        public string Name
        {
            get
            {
                return string.Empty;
            }
            set
            {
                Contract.Requires(!string.IsNullOrEmpty(value),
                    "The name must be greater than 0 characters long.");
            }
        }

        public DateTime DOB
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                Contract.Requires(value < DateTime.Now);
            }
        }

        #endregion
    }
}
