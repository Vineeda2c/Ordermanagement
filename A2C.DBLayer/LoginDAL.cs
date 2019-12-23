using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using System.Configuration;

namespace A2C.DBLayer
{
   public class LoginDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["A2CConnectionString"].ToString();

        public int UserLoginCheck(LoginEntity entity)
        {
            //int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUserLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", entity.UserName);
                cmd.Parameters.AddWithValue("@Password", entity.Password);

                return (int)cmd.ExecuteScalar();
            }
        }
        public LoginEntity GetUserDetails(LoginEntity entity)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                LoginEntity userLogin = new LoginEntity();
                //LoginEntity userDetail = new LoginEntity();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetUserRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", entity.UserName);
                //    cmd.Parameters.AddWithValue("@User_Type", UserType);
                bool isnull = true;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        isnull = false;
                        userLogin.UserName= dr["UserName"].ToString();
                        userLogin.UserType = dr["RolName"].ToString();
                        userLogin.Password = dr["Password"].ToString();
                        userLogin.Userpage = dr["Page_Name"].ToString();
                        userLogin.ActionName = dr["ActionName"].ToString();

                    }
                    if (isnull) return null;
                    else return userLogin;
                }
            }
        }
        public LoginEntity GetUserType(LoginEntity entity)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {

                LoginEntity userLogin = new LoginEntity();
                //LoginEntity userDetail = new LoginEntity();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetUserTYpe", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", entity.UserName);
                cmd.Parameters.AddWithValue("@Password", entity.Password);

                bool isnull = true;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        isnull = false;
                        //userLogin = 

                        userLogin.UserId = Convert.ToInt32(dr["UserName"]);
                        userLogin.UserType = dr["RollName"].ToString();
                        userLogin.Password = dr["Password"].ToString();
                        userLogin.Userpage= dr["Page_Name"].ToString();
                        userLogin.ActionName = dr["ActionName"].ToString();
                       // userLogin.Menu_Name = dr["MenuLink"].ToString();
                    }
                    if (isnull) return null;
                    else return userLogin;
                }
            }
        }
        public LoginEntity GetTopMenu(string Username)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                LoginEntity userLogin = new LoginEntity();
                //LoginEntity userDetail = new LoginEntity();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetTopPage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", Username);
            //    cmd.Parameters.AddWithValue("@User_Type", UserType);
                bool isnull = true;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        isnull = false;
                        userLogin.Userpage = dr["Page_name"].ToString();
                        userLogin.ActionName= dr["ActionName"].ToString();

                    }
                    if (isnull) return null;
                    else return userLogin;
                }
            }
        }
        public int UpdateUserDetail(LoginEntity entity)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateUserDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", entity.UserId);
                cmd.Parameters.AddWithValue("@UserName", entity.UserName);
                cmd.Parameters.AddWithValue("@NewPassword", entity.NewPassword);
                cmd.Parameters.AddWithValue("@Password", entity.Password);


                i = cmd.ExecuteNonQuery();
            }
            return i;
        }

        public List <Roles_Model> GetUser_Roles(string usename,string User_type)
        {
            List<Roles_Model> objget = new List<Roles_Model>();
            using (SqlConnection con = new SqlConnection(cs))
            {

                Roles_Model Obj;
                //LoginEntity userDetail = new LoginEntity();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetPageByRoles", con);        
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", usename);
                cmd.Parameters.AddWithValue("@User_Type", User_type);

                bool isnull = true;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Obj = new Roles_Model();
                        isnull = false;
                        //userLogin = 

                        Obj.User_type= dr["RolName"].ToString();
                        Obj.Page_name = dr["Page_Name"].ToString();
                        Obj.ActionName = dr["ActionName"].ToString();
                        Obj.MenuLink = dr["Menu_Link"].ToString();
                        //     Obj.
                        objget.Add(Obj);
                    }
                    if (isnull) return null;
                    else return objget;
                }

            }
            }


        public List<Roles_Model> GetAllPages(string usename)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Roles_Model> Grol = new List<Roles_Model>();
                Roles_Model Obj = new Roles_Model(); ;
                //LoginEntity userDetail = new LoginEntity();
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetUserByRole", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", usename);
                bool isnull = true;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        isnull = false;
                        Obj = new Roles_Model();
                        Obj.User_id = Convert.ToInt32(dr["EmpId"]);
                        Obj.User_type = dr["UserType"].ToString();
                    
                        Grol.Add(Obj);
                    }
                    if (isnull) return null;
                    else return Grol;
                }




            }
        }
        public List < Roles_Model> GetUserbyRoles(string usename)
    {
          using (SqlConnection con = new SqlConnection(cs))
        {
            List<Roles_Model> Grol= new List<Roles_Model>();
            Roles_Model Obj = new Roles_Model(); ;
            //LoginEntity userDetail = new LoginEntity();
            con.Open();
            SqlCommand cmd = new SqlCommand("spGetUserByRole", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserName", usename);
            bool isnull = true;
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                   isnull = false;
                   Obj = new Roles_Model();
                   Obj.User_id = Convert.ToInt32(dr["EmpId"]);
                   Obj.User_type = dr["UserType"].ToString();
                   Obj.Password = dr["Password"].ToString();
                   Grol.Add(Obj);
                }
                if (isnull) return null;
                else return Grol;
            }


             

            }
    }



    } 
}
