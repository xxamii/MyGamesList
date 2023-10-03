﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Abstractions
{
    public interface IDBWorker
    {
        public Task WriteToDB(string data);
        public Task<string> ReadFromDB();
    }
}
