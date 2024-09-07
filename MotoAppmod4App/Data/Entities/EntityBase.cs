using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MotoAppmod4App.Data.Entities
{
    public abstract class EntityBase : IEntity// baza klas do dziedziczenia
    {
        public int Id { get; set; }
    }
}
