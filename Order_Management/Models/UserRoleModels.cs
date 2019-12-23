using A2C.BusinessLayer;
using BusinessEntity;
using Order_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
namespace Order_Management.Models
{
    public  static class UserRoleModels
    {

        public static List<Roles_Model> Userpagedetails(string username, string User_type)
        {
            LoginBL log = new LoginBL();

            List<Roles_Model> logdetails = log.GetPagebyroles(username, User_type);

            return logdetails;
        }
    }
}