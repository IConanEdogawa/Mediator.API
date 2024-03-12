using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.Entities
{
    public class User
    {

        public string Name { get; set; }
        public string NickName { get; set; }
        public string Login { get; set; }
        public string? Password { get; set; }

        public string Bio { get; set; }

        public DateTimeOffset RegistiredDay { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
