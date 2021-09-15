using AutoMapper;
using DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public partial class UserInfoService : BaseService, IUserInfoService
    {
        public IList<UserInfoDto> GetAll()
        {
            var result = UserInfoRepository.GetAll();
            var userInfoDto = UserInfoToUserInfoDtoMapper.Map<List<UserInfoDto>>(result);
            var userRoles = UserRoleRepository.GetRoles();

            foreach (var user in userInfoDto)
            {
                var roles = userRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleName);
                foreach (var item in roles)
                {
                    user.SeperatedRoles += item + ",";
                }
                if (string.IsNullOrWhiteSpace(user.SeperatedRoles) == false)
                {
                    user.SeperatedRoles = user.SeperatedRoles.Remove(user.SeperatedRoles.Length - 1);
                }
            }

            return userInfoDto;
        }

        public UserInfoDto GetById(int id)
        {
            var result = UserInfoRepository.GetById(id);

            var userInfoDto = UserInfoToUserInfoDtoMapper.Map<UserInfoDto>(result);

            return userInfoDto;
        }

        public ResponseBase<bool> Insert(UserInfoDto userInfoDto)
        {
            var response = ResponseBase<bool>.CreateResponse(true);

            var validationResult = SameUserNameValidation(userInfoDto.UserName);

            if (validationResult.Key)
            {
                var userInfo = UserInfoDtoToUserInfoMapper.Map<UserInfo>(userInfoDto);
                UserInfoRepository.Insert(userInfo);
            }
            else
            {
                response.Error(new Exception());
            }
            return response;
        }

        public bool Remove(int Id)
        {
            var deletedItem = UserInfoRepository.GetById(Id);
            var result = UserInfoRepository.Remove(deletedItem);
            return result;
        }

        public bool Update(UserInfoDto userInfoDto)
        {
            var updatedModel = UserInfoRepository.GetById(userInfoDto.Id);
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<UserInfoDto, UserInfo>());
            //var mapper = new Mapper(config);
            //var mappedModel = mapper.Map(userInfoDto, updatedModel);
            updatedModel.FirstName = userInfoDto.FirstName;
            updatedModel.LastName = userInfoDto.LastName;
            updatedModel.Password = userInfoDto.Password;
            updatedModel.UserName = userInfoDto.UserName;
            updatedModel.ModifiedDate = DateTime.Now;


            var result = UserInfoRepository.Update(updatedModel);
            return result;
        }


    }
}
