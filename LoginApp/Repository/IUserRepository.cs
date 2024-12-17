using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Repository
{
    public interface IUserRepository
    {
        Task<User> Login(string email, string password);
    }
}
