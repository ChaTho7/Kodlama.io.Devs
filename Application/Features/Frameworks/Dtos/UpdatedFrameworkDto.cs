using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Dtos
{
    public class UpdatedFrameworkDto
    {
        public int Id { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public string OldProgrammingLanguageName { get; set; }
        public string NewProgrammingLanguageName { get; set; }
    }
}
