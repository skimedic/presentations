using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IdentityServerWithIdentity.Data;
using IdentityServerWithIdentity.Models;

namespace IdentityServerWithIdentity.Services
{
    public interface IAuthRepository
    {
        ApplicationUser GetUserById(string id);
        ApplicationUser GetUserByUsername(string username);
        bool ValidatePassword(string username, string plainTextPassword);
    }
    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext db;

        public AuthRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public ApplicationUser GetUserById(string id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(u => String.Equals(u.Email, username));
            return user;
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            var user = db.Users.FirstOrDefault(u => String.Equals(u.Email, username));
            if (user == null) return false;
            if (String.Equals(plainTextPassword, user.PasswordHash)) return true;
            return false;
        }
    }
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        IAuthRepository _rep;

        public ResourceOwnerPasswordValidator(IAuthRepository rep)
        {
            this._rep = rep;
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (_rep.ValidatePassword(context.UserName, context.Password))
            {
                context.Result = new GrantValidationResult(_rep.GetUserByUsername(context.UserName).Id, "password", null, "local", null);
                return Task.FromResult(context.Result);
            }
            context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The username and password do not match", null);
            return Task.FromResult(context.Result);
        }
    }
    public class ProfileService : IProfileService
    {
        private IAuthRepository _repository;

        public ProfileService(IAuthRepository rep)
        {
            this._repository = rep;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var subjectId = context.Subject.GetSubjectId();
                var user = _repository.GetUserById(subjectId);

                var claims = new List<Claim>
                {
                    new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
                    //add as many claims as you want!new Claim(JwtClaimTypes.Email, user.Email),new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean)
                };

                context.IssuedClaims = claims;
                return Task.FromResult(0);
            }
            catch (Exception x)
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var user = _repository.GetUserById(context.Subject.GetSubjectId());
            context.IsActive = (user != null); // && user.Active;
            return Task.FromResult(0);
        }
    }
}
