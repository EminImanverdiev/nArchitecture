using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities;

//claimler ideallardir meselen men bu isi gore bilerem ve yaxud menim bu ishleri gormeye icazem var. daha degig desek menim emailim var yashim  var ve s...
public class OperationClaim:Entity<int>
{
    public string Name { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
    }
    public OperationClaim(string name)
    {
        Name = name;
    }
    public OperationClaim(int id,string name):base(id)
    {
        Name = name;
    }
}
