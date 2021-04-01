using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppointments.Application.Appointments.Commands.CreateAppointment;
using MyAppointments.Application.Appointments.Commands.DeleteAppointment;
using MyAppointments.Application.Appointments.Commands.UpdateAppointment;
using MyAppointments.Application.Appointments.Queries.GetAllAppointments;
using MyAppointments.Application.Appointments.Queries.GetAllByUserName;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyAppointments.Api.Appointments
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

        [HttpGet]
        [Authorize(Roles = "Company_User")]
        public async Task<IActionResult> Get()
        {
            return Ok(await bus.Send(new GetAllAppointmentsQuery()));
        }

        [HttpGet]
        [Route("GetAllByName")]
        public async Task<IActionResult> GetByName()
        {
            return Ok(await bus.Send(new GetAllByUserNameQuery()));
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAppointmentCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateAppointmentCommand command)
        {
            return Ok(await bus.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteAppointmentCommand command)
        {
            return Ok(await bus.Send(command));
        }
    }
}
