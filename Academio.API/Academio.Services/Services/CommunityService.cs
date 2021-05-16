using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Services
{
    public class CommunityService : ICommunityService
    {
        readonly ICommunityRepository<Community> _communityRepository;
        readonly ICommunityRoleService _communityRoleService;
        readonly ICommunityMemberService _communityMemberService;
        public CommunityService(ICommunityRepository<Community> communityRepository, ICommunityRoleService communityRoleService, ICommunityMemberService communityMemberService)
        {
            _communityRepository = communityRepository;
            _communityRoleService = communityRoleService;
            _communityMemberService = communityMemberService;
        }
        public async Task<CommunityDto> Add(CommunityDto communityDto)
        {
            var communityExists = await GetCommunityByName(communityDto.Name);
            if(communityExists != null)
            {
                return null;
            }

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", communityDto.Name);
            dynamicParameters.Add("@Description", communityDto.Description);
            dynamicParameters.Add("@Guidelines", communityDto.Guidelines);
            dynamicParameters.Add("@Wiki", communityDto.Wiki);
            dynamicParameters.Add("@DateCreated", DateTime.Now);
            var addedCommunity = await _communityRepository.Add(dynamicParameters, @"spAddCommunity");
            
            var role = await _communityRoleService.GetCommunityRoleByName("Moderator");
            var inserted = await _communityMemberService.Add(addedCommunity.Id, communityDto.CommunityCreator.Id, role.Id);
            
            if(inserted == null)
            {
                throw new Exception("Community member insertion failed when creating the community");
            }

            communityDto.Id = addedCommunity.Id;
            communityDto.DateCreated = addedCommunity.DateCreated;

            return communityDto;
        }

        public async Task<IEnumerable<CommunityDto>> GetAll()
        {
            var communityDtos = new List<CommunityDto>();
            var communities =  await _communityRepository.GetAll(@"spGetAllCommunities");
            foreach(var community in communities)
            {
                var communityDto = new CommunityDto()
                {
                    Id = community.Id,
                    Name = community.Name,
                    Description = community.Description,
                    Guidelines = community.Guidelines,
                    Wiki = community.Wiki,
                    DateCreated = community.DateCreated
                };
                communityDtos.Add(communityDto);
            }
            return communityDtos;
        }

        public async Task<CommunityDto> GetCommunityByName(string communityName)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", communityName);
            var existingCommunity = await _communityRepository.GetCommunityByName(dynamicParameters, @"spGetCommunityByName");

            var communityDto = new CommunityDto()
            {
                Id = existingCommunity.Id,
                Name = existingCommunity.Name,
                Description = existingCommunity.Description, 
                Guidelines = existingCommunity.Guidelines, 
                Wiki = existingCommunity.Wiki, 
                DateCreated = existingCommunity.DateCreated,
            };
            return communityDto;
        }
    }
}
