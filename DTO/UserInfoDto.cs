using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class UserInfoDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string SeperatedRoles { get; set; }
        [DataMember]
        public DateTime ModifiedDate { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
    }
}
