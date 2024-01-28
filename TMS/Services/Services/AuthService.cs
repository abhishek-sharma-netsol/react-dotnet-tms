using Domain.Custom;
using Domain.Entities;
using Domain.Helpers;
using Domain.Repository;
using Domain.Request;
using Domain.Response;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction.Abstractions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.Services
{
    internal class AuthService : IAuthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IConfiguration _configuration;

        public AuthService(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _repositoryManager = repositoryManager;
            _configuration = configuration;
        }

        public async Task<ApiResponse> RegisterAsync(UserRegisterationRequest request)
        {
            var userByEmail = await _repositoryManager.UserRepository.FindByEmailAsync(request.Email);

            var userByUsername = await _repositoryManager.UserRepository.FindByUserNameAsync(request.Username);

            if (userByEmail is not null || userByUsername is not null)
            {
                return ApiResponses.Conflict($"User with email {request.Email} or username {request.Username} already exists.");
            }

            var user = new User()
            {
                Email = request.Email,
                UserName = request.Username,
                Password = request.Password,
            };

            await _repositoryManager.UserRepository.AddAsync(user);
            var result = await _repositoryManager.UserRepository.SaveChangesAsync();

            if (!result)
            {
                return ApiResponses.InternalServerError($"Unable to register user {request.Username}");
            }

            return await LoginAsync(new UserLoginRequest()
            {
                Username = request.Username,
                Password = request.Password,
            });
        }

        public async Task<ApiResponse> LoginAsync(UserLoginRequest request)
        {
            var user = await _repositoryManager.UserRepository.FindByUserNameAsync(request.Username);

            user ??= await _repositoryManager.UserRepository.FindByEmailAsync(request.Username);

            if (user is null || !await _repositoryManager.UserRepository.CheckPasswordAsync(user, request.Password))
            {
                return ApiResponses.RequestorDoesNotExist(request.Username);
            }

            var token = GetToken(user);

            var response = new UserResponse(user, new JwtSecurityTokenHandler().WriteToken(token));

            return ApiResponses.Success("", response);
        }

        public async Task<ApiResponse> GetCurrentUserAsync()
        {
            var claims = await Task.Run(() => ClaimsPrincipleHelper.GetClaims());

            if (claims is null)
                return ApiResponses.Success("");

            var response = new UserResponse
            {
                Id = Convert.ToInt32(claims.Find(c => c.Type == ClaimTypes.NameIdentifier)?.Value),
                Username = claims.Find(c => c.Type == ClaimTypes.Name)?.Value,
                Email = claims.Find(c => c.Type == ClaimTypes.Email)?.Value,
            };

            return ApiResponses.Success("", response);
        }

        private JwtSecurityToken GetToken(User user)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}
