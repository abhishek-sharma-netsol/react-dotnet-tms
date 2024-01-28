using Domain.Request;
using Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Abstractions
{
    public interface IAuthService
    {
        Task<ApiResponse> RegisterAsync(UserRegisterationRequest request);
        Task<ApiResponse> LoginAsync(UserLoginRequest request);
        Task<ApiResponse> GetCurrentUserAsync();
    }
}
