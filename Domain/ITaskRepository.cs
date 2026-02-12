using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<WorkTask>> GetAllAsync();
        Task<WorkTask?> GetByIdAsync(Guid id);
        Task AddAsync(WorkTask task);
        Task UpdateAsync(WorkTask task);
        Task DeleteAsync(Guid id);
    }
}