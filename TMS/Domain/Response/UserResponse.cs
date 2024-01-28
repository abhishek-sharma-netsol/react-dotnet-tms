using Domain.Entities;

namespace Domain.Response
{
    public class UserResponse
    {
        public UserResponse() { }

        public UserResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.UserName;
            Email = user.Email;
            Token = token;
        }

        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string Token { get; set; }
    }
}
