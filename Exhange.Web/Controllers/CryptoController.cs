using System.Threading.Tasks;
using Exchange.Command.Commands;
using Exchange.Command.Queries;
using Exchange.Web.Controllers.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Exchange.Web.Controllers
{
    
    public class CryptoController : BaseController
    {
        
        public CryptoController(IMediator mediator):base(mediator)
        {
            
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            var commandResponse = await Mediator.Send(new FillDataFromServerCommand());

            if (!commandResponse.Succeed) BadRequest(commandResponse);

            var query = await Mediator.Send(new CryptoCurrencyListQuery
            {
                Skip = (page - 1) * pageSize,
                Take = pageSize
            });

            return Ok(query);
        }
        

    }
}