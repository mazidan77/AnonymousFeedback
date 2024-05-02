using AnonymousFeedback.Application.Dtos.FeedBackDto;
using AnonymousFeedback.Domian.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Application.Mapper
{
    public class FeedBackMapper :Profile
    {
        public FeedBackMapper()
        {
            CreateMap<FeedBack,FeedBackPostDto>().ReverseMap();
            CreateMap<FeedBack, FeedBackPutDto>().ReverseMap();
            CreateMap<FeedBack, FeedBackGetDto>()
                .ForMember(x => x.SenderId , opt=>opt.MapFrom(src=>src.SenderId))
                .ForMember(x => x.ReceiverId , opt=>opt.MapFrom(src=>src.ReceiverId))
                .ForMember(x=>x.SenderUserName,opt=>opt.MapFrom(src=>src.Sender.UserName))
                .ForMember(x=>x.ReceiverUserName,opt=>opt.MapFrom(src=>src.Receiver.UserName))
                .ReverseMap();



        }
    }
}
