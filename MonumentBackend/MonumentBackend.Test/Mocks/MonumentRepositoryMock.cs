using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MonumentBackend.Entities;
using MonumentBackend.Repositories;

namespace MonumentBackend.Test.Mocks
{
    public class MonumentRepositoryMock : IEntityRepository<Monument, int>
    {
        private List<Monument> _monuments = new List<Monument>();

        public bool FindAllIsCalled { get; internal set; }
        public bool FindByIsCalled { get; private set; }
        public bool FindIsCalled { get; private set; }
        public bool InsertIsCalled { get; private set; }
        public bool UpdateIsCalled { get; private set; }

        public int Count()
        {
            return _monuments.Count();
        }

        public void Delete(Monument item)
        {
            throw new NotImplementedException();
        }

        public Monument Find(int key)
        {
            FindIsCalled = true;
            return _monuments.First(monument => monument.ID == key);
        }

        public IEnumerable<Monument> FindAll()
        {
            FindAllIsCalled = true;
            return _monuments.ToList();
        }

        public IEnumerable<Monument> FindBy(Expression<Func<Monument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Monument monument)
        {
            InsertIsCalled = true;
            _monuments.Add(monument);
        }

        public void Update(Monument monument)
        {
            UpdateIsCalled = true;

            Monument oldMonument = _monuments.Find(m => m.ID == monument.ID);

            _monuments.Remove(oldMonument);
            _monuments.Add(monument);
        }
    }
}