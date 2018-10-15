﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Entities.Implementations
{
    public class Usuario : BaseEntity<int>
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Inhabilitado { set; get; }
    }
}
