﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.DTOs
{
    public class CreateUserMediator
    {
        public string Name { get; set; }
        public string IserName { get; set; }
        public string Bio { get; set; }
        public string email { get; set; }
        public string photo_path { get; set; }
        public int followers_count { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
