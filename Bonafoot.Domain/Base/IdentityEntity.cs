using System;

namespace Bonafoot.Domain.Base
{
    public abstract class IdentityEntity
    {
        protected IdentityEntity()
        {
            SetId(Guid.NewGuid());
        }

        public Guid Id { get; private set; }

        public void SetId(Guid id) => Id = id;
    }
}
