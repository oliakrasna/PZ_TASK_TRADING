using AutoMapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profile
{
    public class PublishingHouseProfile : AutoMapper.Profile
    {
        
        public PublishingHouseProfile()
        {
            CreateMap<PublishingHous, PublishingHouseDTO>().ReverseMap();
        }
    }
}
