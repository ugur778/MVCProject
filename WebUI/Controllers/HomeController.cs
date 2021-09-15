using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult AddUserRole(int roleId, int userId)
        {
            UserRoleService.Insert(new UserRoleDto()
            {
                RoleId = roleId,
                UserId = userId
            });

            //return RedirectToAction("UserRoleList", new { id = userId }); //userId almıyor???
            return RedirectToAction("Index");
        }
        public ActionResult UserRoleList(int userId, string userName)
        {
            UserNotExistRoleDto model = new UserNotExistRoleDto
            {
                UserId = userId,
                UserName = userName
            };
            var notSelectedRoles = new List<SelectListItem>();

            var userCurrentRoles = UserRoleService.GetAll(userId);
            var roles = RoleService.GetAll();

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
        [HttpPost]
        public ActionResult UserRoleCreate(UserNotExistRoleDto model)
        {
            UserInfoDto userInfoDto = new UserInfoDto();
            userInfoDto.ModifiedDate = DateTime.Now;

            UserRoleService.Insert(new UserRoleDto()
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

            var userCurrentRoles = UserRoleService.GetAll(userId);
            var roles = RoleService.GetAll();

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
            UserInfoDto userInfoDto = new UserInfoDto();
            userInfoDto.ModifiedDate = DateTime.Now;
            UserRoleService.Remove(id);
            return RedirectToAction("UserRoleIndex", new { id = userId });
        }
        public ActionResult UserRoleIndex(int id)
        {
            var userRoles = UserRoleService.GetAll(id);
            ViewBag.UserId = id;
            var userInfo = UserInfoService.GetById(id);
            ViewBag.UserName = userInfo.UserName;
            return View(userRoles);
        }
        public ActionResult RoleEdit(int id)
        {
            var result = RoleService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult RoleEdit(RoleDto model)
        {
            RoleService.Update(model);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleDetails(int id)
        {
            var result = RoleService.GetById(id);
            return View(result);

        }
        public ActionResult RoleDelete(int id)
        {
            RoleService.Remove(id);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RoleCreate(RoleDto roleDto)
        {
            roleDto.ModifiedOn = DateTime.Now;
            roleDto.CreatedOn = DateTime.Now;

            RoleService.Insert(roleDto);
            return RedirectToAction("RoleIndex");
        }
        public ActionResult RoleIndex()
        {
            var data = RoleService.GetAll();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfoDto userInfoDto)
        {
            userInfoDto.CreatedDate = DateTime.Now;
            userInfoDto.ModifiedDate = DateTime.Now;
            UserInfoService.Insert(userInfoDto);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var result = UserInfoService.GetAll();
            return View(result);
        }
        public ActionResult Edit(int id)
        {
            var result = UserInfoService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(UserInfoDto model)
        {
            model.ModifiedDate = DateTime.Now;
            UserInfoService.Update(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var result = UserInfoService.GetById(id);
            return View(result);
        }
        public ActionResult Delete(int id)
        {
            UserInfoService.Remove(id);
            return RedirectToAction("Index");
        }

    }
}