using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Uibasoft.Smedia.DataAccess.Interfaces;
using Uibasoft.Smedia.DataAccess.Options;

namespace Uibasoft.Smedia.DataAccess.Services
{
    public class PasswordService : IPasswordHasher
    {
        private readonly PasswordOptions _options;
        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }
        public bool Check(string hash, string password)
        {
            throw new NotImplementedException();
        }

        public string Hash(string password)
        {
            // PBKDF2 Implementation
            using (var algorithm = new Rfc2898DeriveBytes(password,_options.SaltSize,_options.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_options.Iterations}.{salt}.{key}";
            }
        }
    }
}
