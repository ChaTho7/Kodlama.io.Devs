﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubProfiles.Dtos
{
    public class UpdatedGithubProfileDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OldProfileUrl { get; set; }
        public string NewProfileUrl { get; set; }
    }
}
