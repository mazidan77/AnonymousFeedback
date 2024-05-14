using AnonymousFeedback.Application.Dtos.FeedBackDto;
using AnonymousFeedback.Domian.IManagers;
using AnonymousFeedback.Domian.IUsers;
using AnonymousFeedback.Domian.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnonymousFeedback.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IBaseManager<FeedBack> _feedBackManager;
        protected readonly IMapper _mapper;
        private readonly IUserContext _userContextService;

        public FeedBackController(IBaseManager<FeedBack> feedBackManager, IMapper mapper, IUserContext userContextService)
        {
            _feedBackManager= feedBackManager;
            _mapper= mapper;
            _userContextService = userContextService;
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedBack(FeedBackPostDto feedBackPostDto)
        {
            FeedBack entity = _mapper.Map<FeedBack>(feedBackPostDto);

            

            entity.SenderId = _userContextService.GetCurrentUserId();
            await _feedBackManager.AddWithComplete(entity);

            return Ok(feedBackPostDto);

        }

        [HttpGet("GetRecivedFeedback")]
        public virtual IActionResult GetRecivedFeedback(int recevierId)
        {
            var entity = _feedBackManager.GetSome(x=>x.ReceiverId ==recevierId);

            var dtoList = _mapper.Map<List<FeedBackGetDto>>(entity);
            return Ok(dtoList);
        }


        [HttpGet("GetSendFeedback")]
        public virtual IActionResult GetSendFeedback(int senderId)
        {
            var entity = _feedBackManager.GetSome(x => x.SenderId == senderId);
           
            var dtoList = _mapper.Map<List<FeedBackGetDto>>(entity);
            return Ok(dtoList);
        }

        [HttpDelete]

        public async virtual Task<IActionResult> Delete(int id)
        {
            var entity =await _feedBackManager.GetById(id);

            _feedBackManager.DeleteWithComplete(entity);
            return Ok();
        }


    }
}
