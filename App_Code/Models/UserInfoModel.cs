using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class UserInfoModel
{
    public UserInformation GetUserInfoByUserName(String username)
    {
        ModelDataContext db = new ModelDataContext();
        UserInformation info = (from x in db.UserInformations
                                where x.Username == username
                                select x).FirstOrDefault();

        return info;
    }

    public UserInformation GetUserInfoByEmail(String email)
    {
        ModelDataContext db = new ModelDataContext();
        UserInformation info = (from x in db.UserInformations
                                where x.Email == email
                                select x).FirstOrDefault();

        return info;
    }

    public UserInformation GetUserInfoByGUID(String guID)
    {
        ModelDataContext db = new ModelDataContext();
        UserInformation info = (from x in db.UserInformations
                                where x.GUID == guID
                                select x).FirstOrDefault();

        return info;
    }

    public void InsertUserInformation(UserInformation info)
    {
        ModelDataContext db = new ModelDataContext();
        db.UserInformations.InsertOnSubmit(info);
        db.SubmitChanges();
    }

    public string Verify(String id)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var query = from p in db.UserInformations where p.GUID == id select p;

            foreach (UserInformation p in query)
            {
                /*UserInformation info = new UserInformation();
                info.FirstName = p.FirstName;
                info.LastName = p.LastName;
                info.Address = p.Address;
                info.Phone = p.Phone;
                info.PostalCode = p.PostalCode;
                info.Email = p.Email;
                info.Username = p.Username;
                info.Password=p.Password;*/
                p.IsVerified= true;
            }


            db.SubmitChanges();
            return "verified.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }

    public string ResetPass(String id,String pass)
    {
        try
        {
            ModelDataContext db = new ModelDataContext();
            var query = from p in db.UserInformations where p.GUID == id select p;

            foreach (UserInformation p in query)
            {
                
                p.Password = pass;
            }


            db.SubmitChanges();
            return "Password Changed.";
        }
        catch (Exception e)
        {
            return "Error: " + e;
        }
    }
}