using Academio.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface ICommunityService
    {
        Task<CommunityDto> Add(CommunityDto communityDto);
        Task<CommunityDto> GetCommunityByName(string communityName);
        Task<IEnumerable<CommunityDto>> GetAll();
        Task<CommunityDto> Get(int id);
    }
}
