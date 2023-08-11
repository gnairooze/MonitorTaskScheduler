﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusiness.Model
{
    [PrimaryKey(nameof(HostName), nameof(TaskName))]
    [Index(nameof(Modified))]
    public class Task:TaskBase
    {
        
    }
}
