using System;
using DebuggingExample.Interfaces;

namespace DebuggingExample.Services
{
    class GuidService : IGuidService
    {
        public Guid GenerateGuid()
        {
            return new Guid();
        }
    }
}
