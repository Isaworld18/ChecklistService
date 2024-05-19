namespace ChecklistService_Domain.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ChecklistService_Domain.Models;
    using ChecklistService_Helper.Enum;

    public interface ITaskRepository
    {
        Task<Work> Add(Work data);

        Task<Work> Update(Work data);

        Task<bool> Exists(string desc);

        Task<Work> Get(int workId);

        Task<List<Work>> Get(bool done);

        Task<List<Work>> Order(TasksOrder orderBy);
    }
}
