using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{

    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : BaseModel
    {
        public abstract IQueryable<T> ModelCollection { get; }
        public virtual IEnumerable<T> GetAll() => ModelCollection;
        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            var queyrable = ModelCollection;
            queyrable = queyrable.Where(m => predicate(m));
            return queyrable;
        }
        public virtual T Single(int id) =>
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public virtual T Single(string name) =>
            ModelCollection.FirstOrDefault(c => c.Name == name);
        // Méthodes de delete
        public virtual void Delete(int id){}
        public virtual void Delete(T model) => 
            Delete(model.Id);
        public virtual void DeleteRange(IEnumerable<T> models)
        {
            foreach(var m in models) Delete(m);
        }
        public virtual void DeleteRange(params T[] models) =>
            DeleteRange(models.AsEnumerable());
        // Méthodes d'Update
        public abstract void Update(T model);
    }
}