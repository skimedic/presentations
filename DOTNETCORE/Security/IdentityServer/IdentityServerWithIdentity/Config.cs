using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServerWithIdentity
{
    public class Config
    {
        private static IdentityResource rolesResource = new IdentityResource
        {
            Name = "roles",
            DisplayName = "Roles",
            Description = "Allow the service access to your user roles.",
            UserClaims = new[] { JwtClaimTypes.Role, ClaimTypes.Role },
            ShowInDiscoveryDocument = true,
            Required = true,
            Emphasize = true
        };
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                //new IdentityResource {
                //    Name = "role",
                //    DisplayName = "Role",
                //    UserClaims = new List<string> {"Role"}
                //},
                rolesResource
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myApi", "My Sample API")
                {
                    UserClaims = {"role"}
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
                    RequireConsent = true,

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
                        IdentityServerConstants.StandardScopes.Email,
                        "myApi",
                        "roles"
                    },
                    AllowOfflineAccess = true
                },
                // JavaScript Client
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = {"http://localhost:5003/callback.html"},
                    PostLogoutRedirectUris = {"http://localhost:5003/index.html"},
                    AllowedCorsOrigins = {"http://localhost:5003"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myApi"
                    }
                },
                //angular client
                new Client
                {
                    ClientId = "angular-cli-client",
                    ClientName = "Angular CLI Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = {"http://localhost:4200/?callback"},
                    PostLogoutRedirectUris = {"http://localhost:4200"},
                    AllowedCorsOrigins = {"http://localhost:4200"},

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "myApi"
                    }
                },
            };
        }
    }
}