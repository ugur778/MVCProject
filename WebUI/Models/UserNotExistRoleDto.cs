using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class UserNotExistRoleDto
    {
        public int UserId { get; set; }

        public List<SelectListItem> NotSelectedRoles { get; set; }

        public string UserName { get; set; }

        public string SelectedRoleId { get; set; }
    }
}
