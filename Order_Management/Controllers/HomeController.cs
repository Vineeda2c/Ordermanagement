using System;
using A2C.BusinessLayer;
using BusinessEntity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Order_Management.Models;
using System.Web.Security;


namespace Order_Management.Controllers
{
    public class HomeController : Controller
    {
        public static string Username;
      
        public ActionResult Index()
        {
            Session["Username"] = "";
            Session["Orderno"] = "";
            return View();
        }

        public ActionResult LoginPage()
        {
        
            return View();

            
        }
        public ActionResult AddUserMaster()
        {

            return View();


        }
        public ActionResult UserLogin(LoginModel loginObj, string returnUrl)
        {
            try
            {
                LoginBL loginBl = new LoginBL();
                //   UserRolesDetail rol = new UserRolesDetail();
                LoginEntity loginEntity = new LoginEntity();
                LoginEntity newloginEntity = new LoginEntity();
                Roles_Model rm = new Roles_Model();
                LoginModel loginmodel = new LoginModel();

                int i = 0;
              //  string UserType = "";
                if (ModelState.IsValid)
                {
                    loginEntity.UserName = loginObj.UserName;
                    loginEntity.Password = loginObj.Password;


                    i = loginBl.UserLoginCheck(loginEntity);

                    if (i == 1)
                    {
                        newloginEntity = loginBl.GetUserDetails(loginEntity);

                        Session["Username"] = newloginEntity.UserName;
                        Session["UserType"] = newloginEntity.UserType;
                        Session["Password"] = newloginEntity.Password;
                        Session["UserPage"] = newloginEntity.Userpage;
                        Session["Controler_Name"] = newloginEntity.ActionName;
                        FormsAuthentication.SetAuthCookie(Session["Username"].ToString(), false);
                        Username = Session["Username"].ToString();
                        //    int IsAuth=loginBl.UserPageAuth(Session["Username"].ToString(), Session["UserType"].ToString());
                         var Toppage = loginBl.GetTopPageMenu(Session["Username"].ToString());
                        return Redirect(returnUrl ?? Url.Action(Toppage.Userpage, Toppage.ActionName));
                        //   return RedirectToAction(Toppage.Userpage.ToString(), Toppage.Controller_Name.ToString());

                    }
                    ModelState.AddModelError("", "Incorrect Username and Password");
                    Session["Username"] = "";
                    Session["Password"] = "";
                    Session["UserType"] = "";
                    Session["UserId"] = "";
                }

            }
            catch (Exception ex)
            {

            }

            return View("LoginPage");
        }


        public ActionResult AddNewOrder(List<OrderEntity> OrderDetails)
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("PageNotfound");
            //}
            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddNewOrder(OrderDetails), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddOrderSpec(List<OrderSpecEntity> OrderSpecDetails)
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("PageNotfound");
            //}
            AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddOrderSpec(OrderSpecDetails), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductDetailByOrderNo(int OrderNo)
        {
        
            AddSerialBL obj = new AddSerialBL();
            List<OrderDetailsModel> serialModellist = new List<OrderDetailsModel>();

                var result = obj.GetProductDetails(OrderNo);
        

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllMakeData(int id, string Flag)
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("PageNotfound");
            //}
            AddSerialBL obj = new AddSerialBL();

            List<SerialNumberEnity> makemodelentity = obj.GetAllMakeProductData(id, Flag);
          
            return Json(makemodelentity, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCommentsbyOrderno(int Orderno)
        {

            AddSerialBL obj = new AddSerialBL();
            List<UserCommentsModel> serialModellist = new List<UserCommentsModel>();

            var result = obj.GetCommentsbyOrderNo(Orderno);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetNotificationCount()
        {

            AddSerialBL obj = new AddSerialBL();
            List<OrderDetailsModel> Nlist = new List<OrderDetailsModel>();
             var result = obj.GetNotificationCount();


            return Json(result, JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult UpdateNotification(int OrderNo)
        {

            AddSerialBL obj = new AddSerialBL();
          
            var result = obj.UpdateNotification(OrderNo);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddUserComments(List<UserCommentsEntity> UserComments)
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("PageNotfound");
            //}
            UserCommentsEntity ucent = new UserCommentsEntity();
            Session["Order"] = ucent.Order_No;
       
            //ucent.User_name = Session["Username"].ToString();
            //ucent
           AddSerialBL obj = new AddSerialBL();
            return Json(obj.AddUserComments(UserComments), JsonRequestBehavior.AllowGet);
        }
        public ActionResult OrderDetails()
        {
            AddSerialBL obj = new AddSerialBL();
            List<OrderDetailsModel> Olist = new List<OrderDetailsModel>();
            //List<PaintOrderModel> paintModellist = new List<PaintOrderModel>();
            List<OrderEntity> Oent = obj.GetOrderDetail();
            OrderDetailsModel ordobj;
            if (Oent != null)
            {
                foreach (OrderEntity item in Oent)
                {
                    ordobj = new OrderDetailsModel();

                    ordobj.Orderid = item.Orderid;
                    ordobj.Order_qty = item.Order_qty;
                    ordobj.Order_Make = item.Order_Make;
                    ordobj.Order_Model = item.Order_Model;
                    ordobj.Order_Processor_Type= item.Order_Processor_Type;
                    ordobj.Order_Processor_Speed = item.Order_Processor_Speed;
                    ordobj.Order_Ram = item.Order_Ram;
                    ordobj.Order_Hdd = item.Order_Hdd;
                    ordobj.Order_Lcd = item.Order_Lcd;
                    ordobj.PurchasedDate = item.PurchasedDate;
                    Olist.Add(ordobj);
                }
            }
            return View(Olist);
          
        }
        public ActionResult Userlist()
        {
            AddSerialBL obj = new AddSerialBL();
            List<UserCommentsModel> Ulist = new List<UserCommentsModel>();
            //List<PaintOrderModel> paintModellist = new List<PaintOrderModel>();
            List<UserCommentsEntity> Uent = obj.GetUserList();
            UserCommentsModel ordobj;
            if (Uent != null)
            {
                foreach (UserCommentsEntity item in Uent)
                {
                    ordobj = new UserCommentsModel();

                    ordobj.Userid = item.User_id;
                    ordobj.Username= item.User_name;
                 

                    Ulist.Add(ordobj);
                }
            }
            return View(Ulist);

        }
        public ActionResult Logout()
        {
        //    clsDispose_Fin objClass = new clsDispose_Fin();
            try
            {
                Session["Username"] = null;
                Session["Password"] = null;
                Session["UserType"] = null;
                Session["UserId"] = null;
                Session.RemoveAll();
            }
            catch (Exception ex)
            { }
            //finally
            //{
            //    if (objClass != null)
            //        ((IDisposable)objClass).Dispose();
            //}
            return RedirectToAction("LoginPage");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}