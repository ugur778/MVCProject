using DTO;
using System.Collections.Generic;

namespace Service
{
    public interface IRoleService
    {
        RoleDto GetById(int id);
        IList<RoleDto> GetAll();
        KeyValuePair<bool, string> Insert(RoleDto roleDto);
        bool Remove(int id);
        bool Update(RoleDto roleDto);
    }
}
