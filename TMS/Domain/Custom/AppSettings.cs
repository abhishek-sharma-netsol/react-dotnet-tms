using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Custom
{
    public class AppSettings
    {
        public string DbConnection { get; set; } = "ConnectionStrings:DbConnection";

        public string JwtKey { get; set; } = "Jwt:Key";
        public string JwtIssuer { get; set; } = "Jwt:Issuer";
    }
}
