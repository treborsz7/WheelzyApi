
using System;

public class UserBusiness
{
    public User Login(string userName, string passWord)
    {
        if (string.IsNullOrEmpty(userName))
            throw new ArgumentNullException("Username is required");

        if(string.IsNullOrEmpty(passWord)) 
            throw new ArgumentNullException("Password is requided");

        return new Dao().GetUser(userName, passWord);
       
    }
}

