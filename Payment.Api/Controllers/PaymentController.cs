using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payment.Api.Commands;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PaymentController(ILogger<PaymentController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePaymentRequestDto request)
        {
            try
            {
                var paymentCommand = _mapper.Map<CreatePaymentCommand>(request);
                var result = await _mediator.Send(paymentCommand, CancellationToken.None);

                if (result)
                    return Ok();

                return BadRequest("!!!Not Completed!!! (return service error)");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"Error on Insert Payment {request}");
                return BadRequest("Error");
            }
        }
    }
}
    

    