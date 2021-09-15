using DTO;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public partial class RoleService : BaseService, IRoleService
    {
        public IList<RoleDto> GetAll()
        {
            var result = RoleRepository.GetAll();
            var roleDtoList = RoleToRoleDtoMapper.Map<List<RoleDto>>(result);
            return roleDtoList;
        }

        public RoleDto GetById(int id)
        {
            var result = RoleRepository.GetById(id);

            var roleDto = RoleToRoleDtoMapper.Map<RoleDto>(result);

            return roleDto;
        }

        public KeyValuePair<bool, string> Insert(RoleDto roleDto)
        {

            var validationResult = SameNameValidation(roleDto.Name);

            if (validationResult.Key)
            {
                var role = RoleDtoToRoleMapper.Map<Role>(roleDto);
                RoleRepository.Insert(role);
            }

            return validationResult;
        }



        public bool Remove(int id)
        {
            var removedItem = RoleRepository.GetById(id);
            RoleRepository.Remove(removedItem);
            return true;
        }

        public bool Update(RoleDto roleDto)
        {
            var updatedModel = RoleRepository.GetById(roleDto.Id);
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfoDto, UserInfo>());
            //var mapper = new Mapper(config);
            //var mappedModel = mapper.Map(userInfoDto, updatedModel);
            updatedModel.Name = roleDto.Name;
            updatedModel.ModifiedOn = DateTime.Now;
            updatedModel.IsActive = roleDto.IsActive;

            var result = RoleRepository.Update(updatedModel);
            return result;
        }
    }
}
