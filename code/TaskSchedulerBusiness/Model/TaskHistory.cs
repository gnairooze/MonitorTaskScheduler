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
    public class TaskHistory:TaskBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public TaskHistory()
        {
            
        }

        public TaskHistory(TaskBase task)
        {
            CopyFrom(task);
            Modified = task.Modified;
        }
    }
}
