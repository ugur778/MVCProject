namespace DTO
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
