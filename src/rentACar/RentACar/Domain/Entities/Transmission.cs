using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Transmission:Entity<Guid> {
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }
    public Transmission()
    {
        Models = new List<Model>();

    }
    public Transmission(Guid id, string name) : this()
    {
        Name = Name;
        Id = id;
    }
}
