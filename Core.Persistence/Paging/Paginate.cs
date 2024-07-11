﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Paging;
//sayfalama
//hangi indexteyiz, kaçıncı sayfadayız, elemanlarımız neler?
public class Paginate<T>
{
    public Paginate()
    {
        Items=Array.Empty<T>();
    }
    public int Size { get; set; }
    public int Index { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index > 0; //önceki sayfa var mı?
    public bool HasNext => Index+1 < Pages; //sonraki sayfa var mı?
}

