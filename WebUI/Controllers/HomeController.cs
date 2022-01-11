using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        [HttpPost]
        public ActionResult UserRoleCreate(UserNotExistRoleDto model)
        {
            ProjectService.InsertUserRole(new MvcProjectService.UserRoleDto()
            {
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                RoleId = Convert.ToInt32(model.SelectedRoleId),
                UserId = model.UserId
            });
            return RedirectToAction("UserRoleIndex", new { id = model.UserId });
        }
        public ActionResult UserRoleCreate(int userId, string userName)
        {
            UserNotExistRoleDto model = new UserNotExistRoleDto
            {
                UserId = userId,
                UserName = userName
            };

            var notSelectedRoles = new List<SelectListItem>();
            var userCurrentRoles = ProjectService.GetUserRoleAll(userId);
            var roles = ProjectService.GetRoleAll();

            foreach (var item in roles)
            {
                var isExistRole = userCurrentRoles.Any(x => x.RoleId == item.Id);
                if (!isExistRole)
                    notSelectedRoles.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Selected = false,
                        Text = item.Name
                    });
            }
            model.NotSelectedRoles = notSelectedRoles;
            return View(model);

        }
        public ActionResult UserRoleDelete(int id, int userId)
        {
            ProjectService.RemoveUserRole(id);
            return RedirectToAction("UserRoleIndex", new { id = userId });
        }
        public ActionResult UserRoleIndex(int id)
        {
            var userRoles = ProjectService.GetUserRoleAll(id);
            ViewBag.UserId = id;
            var userInfo = ProjectService.GetUserInfoById(id);
            ViewBag.UserName = userInfo.UserName;
            return View(userRoles);
        }
        public ActionResult RoleEdit(int id)
        {
            var result = ProjectService.GetRoleById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult RoleEdit(MvcProjectService.RoleDto model)
        {
            ProjectService.UpdateRole(model);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleDetails(int id)
        {
            var result = ProjectService.GetRoleById(id);
            return View(result);

        }
        public ActionResult RoleDelete(int id)
        {
            ProjectService.RemoveRole(id);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoleCreate(MvcProjectService.RoleDto roleDto)
        {
            roleDto.ModifiedOn = DateTime.Now;
            roleDto.CreatedOn = DateTime.Now;

            ProjectService.InsertRole(roleDto);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleIndex()
        {
            var data = ProjectService.GetRoleAll();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MvcProjectService.UserInfoDto userInfoDto)
        {
            ProjectService.InsertUserInfo(userInfoDto);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var result = ProjectService.GetUserInfoAll();
            return View(result);
        }
        public ActionResult Edit(int id)
        {
            var result = ProjectService.GetUserInfoById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(MvcProjectService.UserInfoDto model)
        {
            ProjectService.UpdateUserInfo(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var result = ProjectService.GetUserInfoById(id);
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            ProjectService.RemoveUserInfo(id);
            return RedirectToAction("Index");
        }
    }
}