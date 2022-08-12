using ACG_Master.DataBase.Entities;

namespace ACG_Master.DataBase.Access
{
    // Authentication managment service
    public class AuthService : ServiceBase<User>
    {
        public AuthService(ACGContext context) : base(context)
        {
        }
        public override User Get(string id)
        {
            return base.Get(item => item.MoralisId == id);
        }
    }
}
