using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class GithubProfile : Entity
    {
        public int UserId { get; set; }
        public string ProfileUrl { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }

        public GithubProfile()
        {

        }

        public GithubProfile(string profileUrl, int userId) : this()
        {
            ProfileUrl = profileUrl;
            UserId = userId;
        }
    }
}
