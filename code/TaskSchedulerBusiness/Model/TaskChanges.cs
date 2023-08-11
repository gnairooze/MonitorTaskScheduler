using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerBusiness.Model
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Created))]
    [Index(nameof(HostName))]
    [Index(nameof(TaskName))]
    public class TaskChanges
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string HostName { get; set; } = string.Empty;
        public string TaskName { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
}
