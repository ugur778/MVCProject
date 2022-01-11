using System.Runtime.Serialization; 

namespace DTO
{
    [DataContract]
    public class UserRoleDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public System.DateTime ModifiedOn { get; set; }
        [DataMember]
        public System.DateTime CreatedOn { get; set; }
    }
}
