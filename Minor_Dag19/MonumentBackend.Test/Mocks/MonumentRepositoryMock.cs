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
        private int _count;

        public bool FindAllIsCalled { get; internal set; }
        public bool FindIsCalled { get; private set; }
        public int FindParameter { get; internal set; }
        public bool InsertIsCalled { get; private set; }
        public Monument InsertParameter { get; private set; }
        public bool UpdateIsCalled { get; private set; }
        public Monument UpdateParameter { get; private set; }

        public int Count()
        {
            return _count;
        }

        public void Delete(Monument item)
        {
            throw new NotImplementedException();
        }

        public Monument Find(int key)
        {
            FindIsCalled = true;
            FindParameter = key;
            return null;
        }

        public IEnumerable<Monument> FindAll()
        {
            FindAllIsCalled = true;
            return null;
        }

        public IEnumerable<Monument> FindBy(Expression<Func<Monument, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Monument monument)
        {
            InsertIsCalled = true;
            InsertParameter = monument;
            _count++;
        }

        public void Update(Monument monument)
        {
            UpdateIsCalled = true;
            UpdateParameter = monument;
        }
    }
}