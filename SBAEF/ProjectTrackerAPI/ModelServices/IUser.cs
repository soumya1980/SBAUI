using System.Collections.Generic;
using System.Linq;
using EFModel = ProjectTrackerEF.Models;

namespace ProjectTrackerAPI.ModelServices
{
    public interface IUser
    {
        List<EFModel.User> AllUsers();
        EFModel.User GetUser(int id);
        int PatchUser(int id, EFModel.User User);
        int CreateUser(EFModel.User user);
        int DeleteUser(int id);
    }
}
