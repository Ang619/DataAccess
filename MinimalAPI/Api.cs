using System.Runtime.CompilerServices;

namespace MinimalAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
       
        //All of my API enpoint mapping
        app.MapGet("/api/users", GetUsers);
        app.MapGet("/Users/{id}", GetUser);
        app.MapPost("/Users", InsertUser);
        app.MapPut("/Users", UpdateUser);
        app.MapDelete("/Users/{id}", DeleteUser);


    }
        




    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            //Http Code 200
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);

        }
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var results = await data.GetUser(id);
            if (results is not null)
            {
                return Results.Ok(results);
            }
            else
            {
                return Results.NotFound();
            }
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

