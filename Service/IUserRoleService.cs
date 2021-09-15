using DTO;
using System.Collections.Generic;

namespace Service
{
    public interface IUserRoleService
    {
        UserRoleDto GetById(int id, int userId);
        IList<UserRoleDto> GetAll(int userId);
        KeyValuePair<bool, string> Insert(UserRoleDto userRoleDto);
        bool Remove(int id);
        bool Update(UserRoleDto roleDto);

    }
}
