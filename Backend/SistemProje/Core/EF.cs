using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SistemProje.DataAccess;
using SistemProje.Entities.Concrete;
using SistemProje.Entities.I;

namespace SistemProje.Core
{
    public static class EF
    {
        public static List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter = null) 
            where TEntity : class, IEntity
        {
            using (WpContext _server = new WpContext())
            {
                return filter == null ? _server.Set<TEntity>().ToList() : _server.Set<TEntity>().Where(filter).ToList();
            }
        }

        public static TEntity Get<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity
        {
            using (WpContext _server = new WpContext())
            {
                return _server.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public static TEntity Add<TEntity>(TEntity entity) where TEntity : IEntity
        {
            using (WpContext _server = new WpContext())
            {
                _server.Add(entity);
                _server.SaveChanges();
                return entity;
            }
        }

        public static void Update(int Gönderen_id, int Alici_id, int Mesaj_id) 
        {
            using (WpContext _server = new WpContext())
            {
                var sonMesaj = _server.tbl_SonKonusulan.SingleOrDefault(x => x.Gonderici_id == Gönderen_id && x.Alici_id == Alici_id);
                if (sonMesaj == null)
                {
                    sonMesaj = _server.tbl_SonKonusulan.SingleOrDefault(x =>
                        x.Gonderici_id == Alici_id && x.Alici_id == Gönderen_id);
                    if (sonMesaj == null)
                    {
                        SonKonusulan son = new SonKonusulan
                            { Gonderici_id = Gönderen_id, Alici_id = Alici_id, Mesaj_id = Mesaj_id };
                        Add(son);
                        return;
                    }
                }

                sonMesaj.Gonderici_id = Gönderen_id;
                sonMesaj.Alici_id = Alici_id;
                sonMesaj.Mesaj_id = Mesaj_id;
                _server.SaveChanges();
            }
        } 
    }
}
