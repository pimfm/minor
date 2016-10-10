using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FrontEnd.Test.Mocks
{
    public class FormFileMock : IFormFile
    {
        public string ContentDisposition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ContentType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool CopyToHasBeenCalled { get; private set; }

        public string FileName
        {
            get
            {
                return "testfile.txt";
            }
        }

        public IHeaderDictionary Headers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Stream target)
        {
            CopyToHasBeenCalled = true;
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
