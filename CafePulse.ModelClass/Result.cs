﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePulse.ModelClass
{
    public class Result
    {
        public bool Success { get; set; }
        public object Object { get; set; }
        public List<Object> Objects { get; set; }
        public string ErrorMessage { get; set; }
        public Exception exception { get; set; }

    }
}
