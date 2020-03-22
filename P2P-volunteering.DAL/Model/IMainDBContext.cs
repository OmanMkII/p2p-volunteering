using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace P2P_volunteering.DAL.Model
{
    public interface IMainDBContext
    {
        DbSet<Address> Address { get; set; }
        DbSet<Volunteer> Volunteer { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
