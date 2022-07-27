using ACG_Master.DataBase.Entities;

namespace ACG_Master.DataBase.Access
{
    public class AuthService : ServiceBase<User>
    {
        public AuthService(ACGContext context) : base(context)
        {
        }
    }
}
