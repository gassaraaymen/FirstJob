﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FirstJob.Models
{
   public  interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
