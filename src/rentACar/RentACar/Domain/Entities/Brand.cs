using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence;
using Core.Persistence.Repositories;
namespace Domain.Entities;

public class Brand:Entity<Guid>
{
    public string Name { get; set; }
    public Brand()
    {
        
    }
    public Brand(Guid id,string Name)
    {
        Name = Name;
        Id=id;
    }
}
