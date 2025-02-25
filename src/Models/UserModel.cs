// Purpose: Contains the UserModel class. This class is used to represent a user in the B2C tenant.
// Path: src/Models/UserModel.cs
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Graph;

namespace b2c_ms_graph
{
    public class UserModel : User
    {
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public void SetB2CProfile(string TenantName)
        {
            this.PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = this.Password,
                ODataType = null
            };
            this.PasswordPolicies =  "DisablePasswordExpiration,DisableStrongPassword";
            this.Password = null;
            this.ODataType = null;

            foreach (var item in this.Identities)
            {
                if (item.SignInType == "emailAddress" || item.SignInType == "userName")
                {
                    item.Issuer = TenantName;
                }
            }
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}