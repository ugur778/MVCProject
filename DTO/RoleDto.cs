using System.Runtime.Serialization;

namespace DTO
{
    [DataContract]
    public class RoleDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public System.DateTime CreatedOn { get; set; }
        [DataMember]
        public System.DateTime ModifiedOn { get; set; }
    }
}
