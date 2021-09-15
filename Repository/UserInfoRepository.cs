using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Repository
{
    public class UserInfoRepository : BaseRepository, IRepository<UserInfo>, IUserInfoRepository
    {
        public IEnumerable<UserInfo> GetAll()
        {
            return Model.UserInfo.ToList();
        }

        public UserInfo GetById(int id)
        {
            return Model.UserInfo.FirstOrDefault(x => x.Id == id);
        }

        public bool Insert(UserInfo entity)
        {
            Model.UserInfo.Add(entity);
            Model.SaveChanges();
            return true;
        }

        public List<UserInfo> GetByUserName(string userName)
        {
            var userInfo = Model.UserInfo.Where(x => x.UserName == userName).ToList();
            return userInfo;
        }

        public bool Remove(UserInfo entity)
        {
            Model.UserInfo.Remove(entity);
            Model.SaveChanges();
            return true;
        }

        public bool Update(UserInfo entity)
        {
            Model.SaveChanges();
            return true;
        }
    }
}
