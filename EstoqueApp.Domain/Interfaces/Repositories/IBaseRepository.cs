using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository <TModel,Tkey> where TModel : class
    {
        void Add(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        List<TModel> GetAll();
        List<TModel> GetAll(Func<TModel, bool> where);

        TModel ? GetById(Tkey id);
        TModel? Get(Func<TModel, bool> where);


    }
}
