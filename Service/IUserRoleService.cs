using DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    public interface IUserRoleService
    {
        [OperationContract]
        UserRoleDto GetUserRoleById(int id, int userId);
        [OperationContract]
        IList<UserRoleDto> GetUserRoleAll(int userId);
        [OperationContract]
        KeyValuePair<bool, string> InsertUserRole(UserRoleDto userRoleDto);
        [OperationContract]
        bool RemoveUserRole(int id);
        [OperationContract]
        bool UpdateUserRole(UserRoleDto roleDto);

    }
}
