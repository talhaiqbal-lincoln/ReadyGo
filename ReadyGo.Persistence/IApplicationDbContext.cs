using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities;
using System.Threading.Tasks;

namespace ReadyGo.Persistence
{
    public interface IApplicationDbContext
    {
        public DbSet<EmailSettings> MailSettings { get; set; }
        Task<int> SaveChangesAsync();
    }
}
