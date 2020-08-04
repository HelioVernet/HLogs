using H.Logs.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H.Logs.DAL
{
    public class HLogsContext : DbContext
    {
        public HLogsContext(DbContextOptions<HLogsContext> options) : base(options) { }
        public DbSet<LogsV1> LogsV1 { get; set; }
    }
}
