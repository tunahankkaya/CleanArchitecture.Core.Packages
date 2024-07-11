using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Dynamic;
/*
     örneğin bir araba kiralama şirketi üzerinden konuşursak, kullanıcı 
     filtreleme yaparken marka, araç tipini vs. seçiyor.
     bazen de yakıt tipi gibi filtrelendirme yapıyor
     biz filtreleme yapmamız için önceden SQL Queryleri yazmamız gerekir.
     LINQ kullanarak bu filtrelemeyi dinamik hale getireceğiz.
 */
public class DynamicQuery
{
    public IEnumerable<Sort>? Sort { get; set; }
    public Filter? Filter { get; set; }

    public DynamicQuery()
    {
        
    }
    public DynamicQuery(IEnumerable<Sort>? sort, Filter? filter)
    {
        Filter = filter;
        Sort = sort;
    }
}
