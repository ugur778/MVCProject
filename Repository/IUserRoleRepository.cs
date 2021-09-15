using DTO;
using System.Collections.Generic;

namespace Repository
{
    public interface IUserRoleRepository
    {
        List<UserRoleDto> GetRolesByUserId(int userId);
    }
}
