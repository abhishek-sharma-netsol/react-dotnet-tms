using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Abstractions
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
    }
}
