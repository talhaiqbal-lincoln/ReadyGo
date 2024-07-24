using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Persistence;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReadyGo.Service.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext _dbContext;
        private DbSet<T> table;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor accessor;

        public GenericRepository(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
             IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
            this.accessor = accessor;
        }

        public T Get(Guid id)
        {
            try
            {
                return table.Find(id);
            }
            catch 
            {
                RollBack();
                //LogException(LogActions.Get.ToString(), ex.Message);
                return null;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return table.AsQueryable();
            }
            catch 
            {
                RollBack();
                //LogException(LogActions.Get.ToString(), ex.Message);
                return null;
            }
        }
      
        public bool Insert(T entity)
        {
            try
            {
                table.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                RollBack();
                return false;
                //LogException(LogActions.Delete.ToString(), ex.Message);           
            }
        }

        public void InsertRange(List<T> entities)
        {
            try
            {
                table.AddRange(entities);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                //LogException(LogActions.Delete.ToString(), ex.Message);              
            }
        }

        public bool Update(T entity)
        {
            try
            {
                table.Update(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                RollBack();
                return false;
                //LogException(LogActions.Delete.ToString(), ex.Message);              
            }
        }
        public void UpdateRange(List<T> entities)
        {
            try
            {
                table.UpdateRange(entities);
                _dbContext.SaveChanges();
            }
            catch
            {
                RollBack();
                //LogException(LogActions.Delete.ToString(), ex.Message);              
            }
        }

        public void Delete(T entity)
        {
            try
            {
                table.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch 
            {
                RollBack();
                //LogException(LogActions.Delete.ToString(), ex.Message);
            }
        }

        public void DeleteRange(List<T> entities)
        {
            try
            {
                table.RemoveRange(entities);
                _dbContext.SaveChanges();
            }
            catch
            {
                RollBack();
                //LogException(LogActions.Delete.ToString(), ex.Message);              
            }
        }
        public T FindBy(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).FirstOrDefault();
        }
        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate).AsQueryable();
        }

        public void RollBack()
        {
            var changedEntries = _dbContext.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
