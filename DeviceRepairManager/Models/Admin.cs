﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceRepairManager.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
