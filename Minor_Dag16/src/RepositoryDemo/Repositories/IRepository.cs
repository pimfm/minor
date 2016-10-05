using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RepositoryDemo.Repositories
{
    interface IRepository<Entity, Key>
    {
        IEnumerable<Entity> FindAll();
        IEnumerable<Entity> FindBy(Expression<Func<Entity, bool>> filter); 
        Entity Find(Key id);

        void Insert(Entity item);
        void Update(Entity item);
        void Delete(Entity item);
    }
}
