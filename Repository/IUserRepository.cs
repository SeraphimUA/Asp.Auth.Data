using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Data.Repository
{
    public interface IUserRepository
    {
        User Get(string username, string password);
        void Add(User user);
    }
}
