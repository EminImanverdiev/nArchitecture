using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class Entity<TId>:IEntityTimestamps
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; } //nullable elemeyimizin meqsedi odurki ilk obyekt yaradanda bizim updatedate ve deleteddate daxil etmek mecburiyyetinde deyilik
    public Entity()
    {
        Id = default;// eger hec bir deyer verilmeyibse defaultun versin
    }
    public Entity(TId id)
    {
        Id = id;
    }

}
