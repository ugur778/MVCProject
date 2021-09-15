using AutoMapper;
using DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BaseService
    {
        private UserInfoRepository _userInfoRepository;
        private RoleRepository _roleRepository;
        private UserRoleRepository _userRoleRepository;

        private MapperConfiguration _userInfoToUserInfoDtoConfig;
        private Mapper _userInfoToUserInfoDtoMappper;

        private MapperConfiguration _userInfoDtoToUserInfoConfig;
        private Mapper _userInfoDtoToUserInfoMappper;

        private MapperConfiguration _roleToRoleDtoConfig;
        private Mapper _roleToRoleDtoMappper;

        private MapperConfiguration _roleDtoToRoleConfig;
        private Mapper _roleDtoToRoleMappper;

        internal Mapper RoleToRoleDtoMapper
        {
            get
            {
                if (_roleToRoleDtoConfig is null)
                    _roleToRoleDtoConfig = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDto>());
                if (_roleToRoleDtoMappper is null)
                    _roleToRoleDtoMappper = new Mapper(_roleToRoleDtoConfig);

                return _roleToRoleDtoMappper;
            }
        }
        internal Mapper RoleDtoToRoleMapper
        {
            get
            {
                if (_roleDtoToRoleConfig is null)
                    _roleDtoToRoleConfig = new MapperConfiguration(cfg => cfg.CreateMap<RoleDto, Role>());
                if (_roleDtoToRoleMappper is null)
                    _roleDtoToRoleMappper = new Mapper(_roleDtoToRoleConfig);

                return _roleDtoToRoleMappper;
            }
        }

        internal Mapper UserInfoToUserInfoDtoMapper
        {
            get
            {
                if (_userInfoToUserInfoDtoConfig is null)
                    _userInfoToUserInfoDtoConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, UserInfoDto>());
                if (_userInfoToUserInfoDtoMappper is null)
                    _userInfoToUserInfoDtoMappper = new Mapper(_userInfoToUserInfoDtoConfig);

                return _userInfoToUserInfoDtoMappper;
            }
        }
        internal Mapper UserInfoDtoToUserInfoMapper
        {
            get
            {
                if (_userInfoDtoToUserInfoConfig is null)
                    _userInfoDtoToUserInfoConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserInfoDto, UserInfo>());
                if (_userInfoDtoToUserInfoMappper is null)
                    _userInfoDtoToUserInfoMappper = new Mapper(_userInfoDtoToUserInfoConfig);

                return _userInfoDtoToUserInfoMappper;
            }
        }

        internal UserInfoRepository UserInfoRepository
        {
            get
            {
                if (_userInfoRepository is null)
                    _userInfoRepository = new UserInfoRepository();
                return _userInfoRepository;

            }
        }
        internal RoleRepository RoleRepository
        {
            get
            {
                if (_roleRepository is null)
                    _roleRepository = new RoleRepository();
                return _roleRepository;

            }
        }
        internal UserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository is null)
                    _userRoleRepository = new UserRoleRepository();
                return _userRoleRepository;

            }
        }


    }
}

