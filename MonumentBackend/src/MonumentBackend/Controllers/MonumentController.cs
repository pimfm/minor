using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MonumentBackend.Entities;
using MonumentBackend.Repositories;

namespace MonumentBackend.Controllers
{
    public class MonumentController : Controller
    {
        private IEntityRepository<Monument, int> _repository; 

        public MonumentController(IEntityRepository<Monument, int> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Monument> All()
        {
            return _repository.FindAll();
        }

        public Monument Get(int id)
        {
            return _repository.Find(id);
        }

        public void Post(int id, string name)
        {
            Monument monument = new Monument(id, name);
            _repository.Insert(monument);
        }

        public void Put(Monument monument)
        {
            _repository.Update(monument);
        }
    }
}