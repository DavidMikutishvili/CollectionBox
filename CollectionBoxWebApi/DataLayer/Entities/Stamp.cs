﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionBoxWebApi.DataLayer.Entities
{
    public class Stamp
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Tags { get; set; }

        public int CollectionId { get; set; }

        public int UserId { get; set; }
    }
}
