﻿using MicrosServices.Entities.Common;
using MicrosServices.Helper.Core.Common;
using MicrosServices.Helper.Core.Form;
using MicrosServices.Helper.Core.VO;
using MicrosServices.SDK.PermissionSystem;
using Newtonsoft.Json;
using PermissionSystem.UI.WebSites.Global;
using PermissionSystem.UI.WebSites.Models;
using SkeFramework.Core.Network.DataUtility;
using SkeFramework.Core.Network.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermissionSystem.UI.WebSites.Controllers
{
    public class OrganizationController : Controller
    {
        private OrganizationSdk organizationSdk = new OrganizationSdk();

        #region 页面
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrganizationList()
        {
            return View();
        }
        /// <summary>
        /// 更新页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrganizationUpdate(int id)
        {
            return View();
        }
        /// <summary>
        /// 新增页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrganizationAdd()
        {
            return View();
        }
        #endregion 

        #region Basic GET POST
        /// <summary>
        /// 根据主键ID获取信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPsOrganizationInfo(int id)
        {
            PsOrganization Info = new PsOrganization();
            JsonResponses responses = organizationSdk.GetPsOrganizationInfo(id);
            if (responses.code == JsonResponses.SuccessCode)
            {
                Info = responses.data as PsOrganization;
            }
            return Json(Info, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 获取列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPsOrganizationList(int curPage = 1, string keywords = "")
        {
            PageModel page = new PageModel(curPage);
            PageResponse<PsOrganization> pageResponse = organizationSdk.GetOrganizationPageList(page, keywords);
            return Json(new PageResponseView<PsOrganization>(pageResponse), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 新增提交方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PsOrganizationAdd(PsOrganization model)
        {
            model.InputUser = AppBusiness.loginModel.UserNo;
            JsonResponses responses = organizationSdk.OrganizationAdd(model);
            return Json(responses, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 更新提交方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PsOrganizationUpdate(PsOrganization model)
        {
            JsonResponses responses = organizationSdk.OrganizationUpdate(model);
            return Json(responses, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除提交方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult PsOrganizationDelete(int id)
        {
            JsonResponses responses = organizationSdk.GetPsOrganizationInfo(id);
            if (responses.ValidateResponses())
            {
                PsOrganization platform = responses.data as PsOrganization;
                responses = organizationSdk.OrganizationDelete(id);
            }
            return Json(responses, JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// 获取列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOptionValues()
        {
            List<OptionValue> optionValues = organizationSdk.GetOptionValues();
            optionValues.Insert(0, OptionValue.Default);
            return Json(optionValues, JsonRequestBehavior.AllowGet);
        }

        #region 机构角色分配
        /// <summary>
        /// 用户角色分配页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrganizationAssign(long OrgNo)
        {
            return View();
        }

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOrgAssign(long OrgNo)
        {
            OrgAssignVo assignVo = new OrgAssignVo();
            JsonResponses jsonResponses = organizationSdk.GetOrgAssign(OrgNo);
            if (jsonResponses.ValidateResponses())
            {
                assignVo = JsonConvert.DeserializeObject<OrgAssignVo>(JsonConvert.SerializeObject(jsonResponses.data));
            }
            return Json(assignVo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新提交方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult RolesAssignUpdate(OrgRolesForm model)
        {
            JsonResponses responses = organizationSdk.CreateOrgRoles(model);
            return Json(responses, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}