
using EventBookingSystem.Contexts;
using EventBookingSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EventBookingSystem.Repository
{
    public class EventRepository(DataContext dataContext)
    {
        private DataContext _context = dataContext;


        //create
        public async Task<bool> AddAsync(EventEntity entity)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(entity);
 
                await _context.Events.AddAsync(entity);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return default;
            }
            return false;
        }
        //read  
        public async Task<EventEntity?> GetAsync(Expression<Func<EventEntity, bool>> expression)
        {
            var entity = await _context.Events.FirstOrDefaultAsync(expression);
            return entity;
        }
        public async Task<IEnumerable<EventEntity>> GetAllAsync()
        {
            var entities = await _context.Events.ToListAsync();
            return entities;
        }

    }
    //update    
    //delete
}