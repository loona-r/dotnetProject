using System.Linq;
using System.Collections.Generic;
using Isen.DotNet.Library.Models.Base;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public abstract class BaseInMemoryRepository<T> : BaseRepository<T>
        where T : BaseModel
    {
        protected IList<T> _modelCollection;
        public int NewId()
        {
            var all = GetAll().ToList();
            return all.Count == 0 ? 1 :
                all.Max(m => m.Id) + 1;
        }
        public override void Delete(int id)
        {
            var list = ModelCollection.ToList();
            var modelToRemove = Single(id);
            list.Remove(modelToRemove);
            _modelCollection = list;
        }

        public override void Update(T model)
        {
            if (model == null) return;
            var list = ModelCollection.ToList();
            if (model.IsNew)
            {
                model.Id = NewId();
                list.Add(model);
            }
            else
            {
                var existing = 
                    list.FirstOrDefault(
                        m => m.Id == model.Id);
                existing = model;
            }
            _modelCollection = list;
        }
    }
}