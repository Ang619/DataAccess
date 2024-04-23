using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;
public class UserModel
{
    public int Id { get; set; }
    public  string FirstName { get; set; }
    public string LastName { get; set; }

    public string CardID { get; set; }
}
