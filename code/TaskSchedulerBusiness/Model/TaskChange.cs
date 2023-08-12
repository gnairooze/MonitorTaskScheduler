using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class TaskChange
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TaskHistoryId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [MaxLength(200)]
        public string HostName { get; set; } = string.Empty;
        [MaxLength(700)]
        public string TaskName { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
    }
}
