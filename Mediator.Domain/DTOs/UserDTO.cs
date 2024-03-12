using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Login { get; set; }
        public string? Password { get; set; }
    }
}
