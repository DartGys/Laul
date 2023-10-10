﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Domain.Entities
{
    public class ListeningStat
    {
        public int Id { get; set; }
        public DateTime ListeningDate { get; set; }
        public int UserId { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
    }
}
