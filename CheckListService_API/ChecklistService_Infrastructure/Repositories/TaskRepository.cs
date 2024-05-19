namespace ChecklistService_Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Interfaces;
    using ChecklistService_Domain.Models;
    using ChecklistService_Helper.Enum;
    using Microsoft.EntityFrameworkCore;

    public class TaskRepository : ITaskRepository
    {
        private readonly ChecklistDbMdfContext _dbMdfContext = new();

        public async Task<Work> Add(Work data)
        {
            await _dbMdfContext.Works.AddAsync(data);
            _dbMdfContext.SaveChanges();

            return _dbMdfContext.Works.Last();
        }

        public async Task<Work> Update(Work data)
        {
            _dbMdfContext.Works.Update(data);
            await _dbMdfContext.SaveChangesAsync();

            return await Get(data.Id);
        }

        public async Task<Work> Get(int workId)
        {
            return await _dbMdfContext.Works.SingleAsync(w => w.Id == workId);
        }

        public async Task<bool> Exists(string desc)
        {
            return await _dbMdfContext.Works.SingleAsync(w => w.Description.ToLower() == desc.ToLower()) 
                                             is not null;
        }

        public async Task<List<Work>> Get(bool done)
        {
            return await _dbMdfContext.Works.Where(w => w.Done == done).ToListAsync();
        }

        public async Task<List<Work>> Order(TasksOrder orderBy)
        {
            List<Work> result;

            switch (orderBy)
            {
                case TasksOrder.Id:
                    result = await _dbMdfContext.Works.OrderBy(w => w.Id).ToListAsync();
                    break;

                case TasksOrder.Description:
                    result = await _dbMdfContext.Works.OrderBy(w => w.Description).ToListAsync();
                    break;

                case TasksOrder.Done:
                    result = await _dbMdfContext.Works.OrderBy(w => w.Done).ToListAsync();
                    result = [.. result.OrderBy(w => w.EndDate)];
                    break;

                case TasksOrder.EndDate:
                    result = await _dbMdfContext.Works.OrderBy(w => w.EndDate).ToListAsync();
                    break;

                default:
                    result = await _dbMdfContext.Works.ToListAsync();
                    break;
            }

            return result;
        }
    }
}
