using Core.Persistence.Repositories;
using System.Reflection;

namespace Domain.Entities;

public class Fuel : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<Model> Models{ get; set; }
    public Fuel()
    {
        Models = new List<Model>();

    }
    public Fuel(Guid id, string name) : this()
    {
        Name = Name;
        Id = id;
    }

}
