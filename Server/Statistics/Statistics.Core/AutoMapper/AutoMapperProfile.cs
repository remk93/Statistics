using AutoMapper;
using Statistics.Core.Endoints.Team.Models;
using Statistics.DataStorage.Entities;

namespace Statistics.Core.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TeamModel, Team>();
            CreateMap<Team, TeamModel>();

            CreateMap<TeamModel, Statistics.Core.Endoints.Team.UpdateCommand>();

        }
    }
}
