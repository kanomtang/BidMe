using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionSystem.Models
{
    interface IIUserRepository
    {
        void AddMember(User member);
        User FetchByLoginName(string loginName);
        void SubmitChanges();
    }
}
