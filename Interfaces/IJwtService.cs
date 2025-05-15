using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}