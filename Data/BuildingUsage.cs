﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BuildingUsage
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public List<double> GasUsage { get; set; }

    }
}
