using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface ICurrentUserService
    {
        public int UserId { get; }

        bool IsAuthenticated { get; }

        string Email { get; }

        string FullName { get; }

        string RemoteIpAddress { get; }

        bool IsAdmin { get; }

        bool IsSuperAdmin { get; }

        string ProfilePictureUrl { get; }

        IEnumerable<string> Roles { get; }
    }
}
