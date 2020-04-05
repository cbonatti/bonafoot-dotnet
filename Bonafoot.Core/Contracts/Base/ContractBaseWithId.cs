using System;

namespace Bonafoot.Core.Contracts.Base
{
    public abstract class ContractBaseWithId : ContractBase
    {
        public Guid Id { get; set; }
    }
}
