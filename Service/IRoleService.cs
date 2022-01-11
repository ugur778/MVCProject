using DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{

    [ServiceContract]
    public interface IRoleService
    {
        [OperationContract]
        RoleDto GetRoleById(int id);
        [OperationContract]
        IList<RoleDto> GetRoleAll();
        [OperationContract]
        KeyValuePair<bool, string> InsertRole(RoleDto roleDto);
        [OperationContract]
        bool RemoveRole(int id);
        [OperationContract]
        bool UpdateRole(RoleDto roleDto);
    }
}
