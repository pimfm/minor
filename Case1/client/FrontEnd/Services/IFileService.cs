
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FrontEnd.Services
{
    public interface IFileService<TEntity>
    {
        void Validate(IFormFile file);
        IEnumerable<TEntity> Produce(DateTime? from, DateTime? to);
    }
}
