using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceApp;
using DTO;

namespace WcfServiceApp
{
    //     NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    //     NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WcfService : BaseMvcSampleWcf, IWcfService
    {
        public IList<RoleDto> GetRoleAll()
        {
            var roles = RoleService.GetRoleAll();
            return roles;
        }

        public RoleDto GetRoleById(int id)
        {
            var role = RoleService.GetRoleById(id);
            return role;
        }


        public IList<UserInfoDto> GetUserInfoAll()
        {
            var result = UserInfoService.GetUserInfoAll();
            return result;
        }

        public UserInfoDto GetUserInfoById(int id)
        {
            var userInfo = UserInfoService.GetUserInfoById(id);
            return userInfo;
        }

        public IList<UserRoleDto> GetUserRoleAll(int userId)
        {
            var userRoles = UserRoleService.GetUserRoleAll(userId);
            return userRoles;
        }

        public UserRoleDto GetUserRoleById(int id, int userId)
        {
            var userRoles = UserRoleService.GetUserRoleById(id, userId);
            return userRoles;
        }

        public KeyValuePair<bool, string> InsertRole(RoleDto roleDto)
        {
            var result = RoleService.InsertRole(roleDto);
            return result;
        }

        public ResponseBase<bool> InsertUserInfo(UserInfoDto userInfoDto)
        {
            var result = UserInfoService.InsertUserInfo(userInfoDto);
            return result;
        }

        public KeyValuePair<bool, string> InsertUserRole(UserRoleDto userRoleDto)
        {
            var result = UserRoleService.InsertUserRole(userRoleDto);
            return result;
        }

        public bool RemoveRole(int id)
        {
            var result = RoleService.RemoveRole(id);
            return result;
        }

        public bool RemoveUserInfo(int Id)
        {
            var result = UserInfoService.RemoveUserInfo(Id);
            return result;
        }

        public bool RemoveUserRole(int id)
        {
            var result = UserRoleService.RemoveUserRole(id);
            return result;
        }

        public bool UpdateRole(RoleDto roleDto)
        {
            var result = RoleService.UpdateRole(roleDto);
            return result;
        }

        public bool UpdateUserInfo(UserInfoDto userInfoDto)
        {
            var result = UserInfoService.UpdateUserInfo(userInfoDto);
            return result;
        }

        public bool UpdateUserRole(UserRoleDto roleDto)
        {
            var result = UserRoleService.UpdateUserRole(roleDto);
            return result;
        }
    }
}
