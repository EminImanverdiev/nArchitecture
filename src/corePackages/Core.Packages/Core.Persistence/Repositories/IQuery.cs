using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

//Istifade edilmesinde meqsed odurki bezen ele olurki mutleg biz sql querysi yazmag isteyirik bu zaman bundan istifade edilir
public interface IQuery<T>
{
    IQueryable<T> Query();  
}
