using System;
using SWE.UI.interfaces;

namespace SWE.UI.Models.Domain
{
    public abstract class BaseClass 
    {
        public BaseClass()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
