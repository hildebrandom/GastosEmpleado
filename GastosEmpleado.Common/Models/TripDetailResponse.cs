﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GastosEmpleado.Common.Models
{
    public class TripDetailResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        
    }
}

