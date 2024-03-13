using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string email { get; set; }
        public string photo_path { get; set; }
        public int followers_count { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }

        public DateTimeOffset JoinDate { get; set; } = DateTimeOffset.UtcNow; 
        public DateTimeOffset ModifiedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public bool isDeleted { get; set; } = false;


   

    }
}
