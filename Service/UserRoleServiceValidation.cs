using DTO;
using System.Collections.Generic;

namespace Service
{
    public partial class UserRoleService
    {
        private KeyValuePair<bool, string> UserSameRoleValidation(UserRoleDto dto)
        {

            return new KeyValuePair<bool, string>(true, "İşlem Başarılı");
        }
        private KeyValuePair<bool, string> UserSameRoleValidationForUpdate(UserRoleDto dto)
        {

            return new KeyValuePair<bool, string>(true, "İşlem Başarılı");
        }
    }
}
