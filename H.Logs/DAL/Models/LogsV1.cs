using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace H.Logs.DAL.Models
{
    public class LogsV1
    {
        [Key]
        public int Id { get; set; }
        public string Application { get; set; }
        public string Requestor { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        
    }
}
