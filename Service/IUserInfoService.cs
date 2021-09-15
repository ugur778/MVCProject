using DTO;
using System.Collections.Generic;

namespace Service
{
    public interface IUserInfoService
    {
        UserInfoDto GetById(int id);
        IList<UserInfoDto> GetAll();
        ResponseBase<bool> Insert(UserInfoDto userInfoDto);
        bool Remove(int Id);
        bool Update(UserInfoDto userInfoDto);
    }
}
