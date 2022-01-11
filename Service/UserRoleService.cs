using DTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public partial class UserRoleService : BaseService, IUserRoleService
    {
        public IList<UserRoleDto> GetUserRoleAll(int userId)
        {
            var result = UserRoleRepository.GetRolesByUserId(userId);
            return result;
        }



        public UserRoleDto GetUserRoleById(int id, int userId)
        {
            return GetUserRoleAll(userId).FirstOrDefault(x => x.Id == id);
        }

        public KeyValuePair<bool, string> InsertUserRole(UserRoleDto userRoleDto)
        {
            var validationResult = UserSameRoleValidation(userRoleDto);

            if (validationResult.Key)
            {
                UserRole userRole = new UserRole();
                userRole.RoleId = userRoleDto.RoleId;
                userRole.UserId = userRoleDto.UserId;
                userRole.ModifiedOn = DateTime.Now;
                userRole.CreatedOn = DateTime.Now;
                UserRoleRepository.Insert(userRole);
            }

            return validationResult;


        }

        public bool RemoveUserRole(int id)
        {
            var removedItem = UserRoleRepository.GetById(id);
            UserRoleRepository.Remove(removedItem);
            return true;
        }

        public bool UpdateUserRole(UserRoleDto userRoleDto)
        {
            var validationResult = UserSameRoleValidationForUpdate(userRoleDto);

            if (validationResult.Key)
            {
                var updatedItem = UserRoleRepository.GetById(userRoleDto.Id);
                updatedItem.ModifiedOn = DateTime.Now;
                updatedItem.UserId = userRoleDto.UserId;
                updatedItem.RoleId = userRoleDto.RoleId;
                UserRoleRepository.Update(updatedItem);
            }

            return true;

        }
    }
}
