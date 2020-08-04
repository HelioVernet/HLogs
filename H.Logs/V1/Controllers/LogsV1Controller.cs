using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using H.Logs.DAL;
using H.Logs.DAL.Models;

namespace H.Logs.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogsV1Controller : ControllerBase
    {
        private readonly HLogsContext hLogsContext;

        public LogsV1Controller(HLogsContext context)
        {
            hLogsContext = context;
        }

        // GET: api/LogsV1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogsV1>>> GetLogsV1()
        {
            return await hLogsContext.LogsV1.ToListAsync();
        }

        // GET: api/LogsV1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogsV1>> GetLogsV1(int id)
        {
            var logsV1 = await hLogsContext.LogsV1.FindAsync(id);

            if (logsV1 == null)
            {
                return NotFound();
            }

            return logsV1;
        }

        // PUT: api/LogsV1/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogsV1(int id, LogsV1 logsV1)
        {
            if (id != logsV1.Id)
            {
                return BadRequest();
            }

            hLogsContext.Entry(logsV1).State = EntityState.Modified;

            try
            {
                await hLogsContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogsV1Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LogsV1
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LogsV1>> PostLogsV1(LogsV1 logsV1)
        {
            hLogsContext.LogsV1.Add(logsV1);
            await hLogsContext.SaveChangesAsync();

            return CreatedAtAction("GetLogsV1", new { id = logsV1.Id }, logsV1);
        }

        // DELETE: api/LogsV1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogsV1>> DeleteLogsV1(int id)
        {
            var logsV1 = await hLogsContext.LogsV1.FindAsync(id);
            if (logsV1 == null)
            {
                return NotFound();
            }

            hLogsContext.LogsV1.Remove(logsV1);
            await hLogsContext.SaveChangesAsync();

            return logsV1;
        }

        private bool LogsV1Exists(int id)
        {
            return hLogsContext.LogsV1.Any(e => e.Id == id);
        }
    }
}
