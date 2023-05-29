using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll_System.Contracts
{
    public abstract class BaseEntity : BaseEntity<string>
    {

        protected BaseEntity() => Id = Guid.NewGuid().ToString();
    }

    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;
    }
}

