using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<TEntity,TEntityId>  :IQuery<TEntity>
    where TEntity : Entity<TEntityId>
{
    Task<TEntity?> GetAsync(
        Expression<Func<TEntity,bool>> predicate,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default);
 
    //Get list operasyonu.
    Task<Paginate<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );
    Task<Paginate<TEntity>> GetListByDynamicAsync(
      DynamicQuery dynamic,
      Expression<Func<TEntity, bool>>? predicate = null,
      Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
      int index = 0,
      int size = 10,
      bool withDeleted = false,
      bool enableTracking = true,
      CancellationToken cancellationToken = default
      );
    /*
        GetListAsync fonksiyonunda farkları;
        dinamik olarak filtreleyebiliriz. Mesela araç listesinde sol tarafta motor gücü, marka, renk, model gibi filtreleri dinamik olarka gönderip filtrelemeyi sağlar.
        orderBy ile sıralama özelliği yok.
     */

    //veritabanında ilgili şartlara uyan en az 1 veri var mı?
    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
        );

    //ilgili entity'i db'ye ekleme
    Task<TEntity> AddAsync(TEntity entity);

    //toplu ekleme
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

    //update
    Task<TEntity> UpdateAsync(TEntity entity);

    //toplu update
    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

    //silme işlemi, parmanent kalıcı olarak silme durumunu soruyor. değer false ise soft delete yapıyoruz.
    Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);

    //toplu silme işlemi, parmanent kalıcı olarak silme durumunu soruyor. değer false ise soft delete yapıyoruz.
    Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false);

}
