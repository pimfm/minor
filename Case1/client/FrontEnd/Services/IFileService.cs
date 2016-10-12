
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FrontEnd.Services
{
    public interface IFileService<TEntity>
    {
        IList<TEntity> ReadFile(IFormFile file, DateTime? from, DateTime? to);
    }
}
