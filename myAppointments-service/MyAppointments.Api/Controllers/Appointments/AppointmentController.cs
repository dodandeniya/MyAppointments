using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppointments.Application.Appointments.Commands.CreateAppointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAppointments.Api.Controllers.Appointments
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator bus;

        public AppointmentController(IMediator bus)
        {
            this.bus = bus;
        }

        /* // GET: api/<AppointmentController>
         [HttpGet]
         public IEnumerable<string> Get()
         {
             return new string[] { "value1", "value2" };
         }

         // GET api/<AppointmentController>/5
         [HttpGet("{id}")]
         public string Get(int id)
         {
             return "value";
         }*/

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAppointmentCommand command)
        {
            return Ok(await bus.Send(command));
        }

        // PUT api/<AppointmentController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
