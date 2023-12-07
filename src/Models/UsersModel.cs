// Purpose of this file: Contains the UsersModel class. This class is used to represent a list of users in the B2C tenant.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace b2c_ms_graph
{
    public class UsersModel
    {
        [JsonPropertyName("users")]
        public UserModel[] Users { get; set; }

        public static UsersModel Parse(string JSON)
        {
            return JsonSerializer.Deserialize<UsersModel>(JSON);
        }
    }
}