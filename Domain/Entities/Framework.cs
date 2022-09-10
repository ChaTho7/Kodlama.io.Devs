using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Framework : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Framework()
        {

        }

        public Framework(int programmingLanguageId, string name) : this()
        {
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }
    }
}
