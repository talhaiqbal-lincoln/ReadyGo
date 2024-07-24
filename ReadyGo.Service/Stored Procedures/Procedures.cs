using ReadyGo.Persistence;
using ReadyGo.Service.Stored_Procedures.Interface;
using System;
using Microsoft.EntityFrameworkCore;

namespace ReadyGo.Service.Stored_Procedures
{
    public class Procedures : IProcedures
    {
        public ApplicationDbContext _dbContext;

        public Procedures(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void UpdateCustomerBalance(Guid id)
        {
            _dbContext.Database.ExecuteSqlRaw("EXEC update_balance @id = {0}", id);
        }
    }
}
