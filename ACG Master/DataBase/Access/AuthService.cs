using ACG_Master.DataBase.Entities;

namespace ACG_Master.DataBase.Access
{
    // Authentication managment service
    public class AuthService : ServiceBase<User>
    {
        public AuthService(ACGContext context) : base(context)
        {
        }

        public User GetUserByAccessTokenId(string accessToken)
        {
            return base.Get(item => item.AccessToken == accessToken);
        }
        public User GetByWalletId(string walledId)
        {
            return base.Get(item => item.WalletId == walledId);
        }
        public  User GetByUserName(string userName)
        {
            return base.Get(item => item.UserName == userName);
        }
        public User GetByEmail(string email)
        {
            return base.Get(item => item.Email == email);
        }
    }
}
