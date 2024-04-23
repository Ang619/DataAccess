using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
public class UserData : IUserData
{
    //We inject the ISqlDataAccess interface to be able to use the methods from the interface
    private readonly ISqlDataAccess _db;
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    
    public Task<IEnumerable<UserModel>> GetUsers()
    {
        return _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
    }
        

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetUser", new { Id = id });

        //In case we dont find the user, we return null
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user)
    {
        return _db.SaveData(storedProcedure: "dbo.spUser_InsertUser", new { user.FirstName, user.LastName, user.CardID});
    }

    public Task UpdateUser(UserModel user)
    {
        return _db.SaveData(storedProcedure: "dbo.spUser_UpdateUser", user);
    }

    public Task DeleteUser(int id)
    {
        return _db.SaveData(storedProcedure: "dbo.spUser_DeleteUser", new { Id = id });
    }



}
