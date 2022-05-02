using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Features.Transactions.Commands.CreateTransaction;

namespace Transactions.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TransactionController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTransactionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
