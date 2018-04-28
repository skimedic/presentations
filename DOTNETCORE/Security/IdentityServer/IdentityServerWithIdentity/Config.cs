using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServerWithIdentity
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myApi", "My Sample API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "Role",
                    UserClaims = new List<string> {"Role"}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //Client for the API
                new Client()
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {"myApi"}
                },
                // resource owner password grant client
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"myApi"}
                },
                //Implicit Flow
                //new Client()
                //{
                //    ClientId = "MVCSample",
                //    ClientName = "MVC Sample Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,

                //    RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                //    AllowedScopes = new List<string>
                //    {
                //      IdentityServerConstants.StandardScopes.OpenId,
                //      IdentityServerConstants.StandardScopes.Profile,
                //      IdentityServerConstants.StandardScopes.Email
                //    }
                //},
                //Hybrid Flow
                new Client
                {
                    ClientId = "MVCSample",
                    ClientName = "MVC Sample Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = {"http://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:5002/signout-callback-oidc"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myApi"
                    },
                    AllowOfflineAccess = true
                }
            };
        }
    }
}