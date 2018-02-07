using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class AdminModel
{
    public AdminTable GetUserInfoByUserName(String username)
    {
        ModelDataContext db = new ModelDataContext();
        AdminTable info = (from x in db.AdminTables
                                where x.Username == username
                                select x).FirstOrDefault();

        return info;
    }

    public AdminTable GetUserInfoByEmail(String email)
    {
        ModelDataContext db = new ModelDataContext();
        AdminTable info = (from x in db.AdminTables
                                where x.Email == email
                                select x).FirstOrDefault();

        return info;
    }

    public AdminTable GetUserInfoByGUID(String guID)
    {
        ModelDataContext db = new ModelDataContext();
        AdminTable info = (from x in db.AdminTables
                                where x.GUID == guID
                                select x).FirstOrDefault();

        return info;
    }

    public void InsertUserInformation(AdminTable info)
    {
        ModelDataContext db = new ModelDataContext();
        db.AdminTables.InsertOnSubmit(info);
        db.SubmitChanges();
    }
}