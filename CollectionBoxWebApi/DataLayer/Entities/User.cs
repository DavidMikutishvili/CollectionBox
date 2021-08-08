using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}
