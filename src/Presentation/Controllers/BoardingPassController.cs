using Application.BoardingPasses.Commands.CreateBoardingPass;
using Application.BoardingPasses.Commands.DeleteBoardingPass;
using Application.BoardingPasses.Commands.UpdateBoardingPass;
using Application.BoardingPasses.Queries.GetBoardingPass;
using Application.BoardingPasses.Queries.GetBoardingPassList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.BoardingPass;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    public class BoardingPassController : BaseController
    {
        private readonly IMapper _mapper;

        public BoardingPassController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BoardingPassListVm>> GetAll()
        {
            var query = new GetBoardingPassListQuery { };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BoardingPassVm>> Get(Guid id)
        {
            var query = new GetBoardingPassQuery { Id = id };
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBoardingPassDto createBoardingPass)
        {
            var command = _mapper.Map<CreateBoardingPassCommand>(createBoardingPass);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateBoardingPassDto updateBoardingPass)
        {
            var command = _mapper.Map<UpdateBoardingPassCommand>(updateBoardingPass);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var command = new DeleteBoardingPassCommand { Id = id };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
