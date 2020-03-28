using System;

namespace Bonafoot.Domain.Base
{
    public abstract class IdentityEntity
    {
        public Guid Id { get; private set; }

        public void SetId(Guid id) => Id = id;
    }
}
