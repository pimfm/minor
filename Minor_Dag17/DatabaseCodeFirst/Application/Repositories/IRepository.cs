using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DatabaseCodeFirst.Application.Repositories
{
    public interface IRepository<Entity, Key>
    {
        IEnumerable<Entity> FindAll();
        IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter); 
        Entity Find(Key id);

        int Count();
        void Insert(Entity item);
        void Update(Entity item);
        void Delete(Entity item);
    }
}
