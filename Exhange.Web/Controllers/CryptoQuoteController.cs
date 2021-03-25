using System.Threading.Tasks;
using Exchange.Command.Queries;
using Exchange.Web.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.Web.Controllers
{
    public class CryptoQuoteController:BaseController
    {
        public CryptoQuoteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestQuote(int id)
        {
            var queryResult = await Mediator.Send(new GetLatestCryptoCurrencyQuotes(id));
            if (queryResult.Succeed) return Ok(queryResult);

            return BadRequest(queryResult);

        }
    }
}