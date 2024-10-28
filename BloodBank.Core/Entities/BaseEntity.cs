using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
    }
}
