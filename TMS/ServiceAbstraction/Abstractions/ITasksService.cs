using Domain.Repository;
using Domain.Request;
using Domain.Response;

namespace ServiceAbstraction.Abstractions
{
    public interface ITasksService
    {
        Task<ApiResponse> GetAllAsync();
        Task<ApiResponse> GetByIdAsync(long id);
        Task<ApiResponse> GetAllByUserIdASync(long id);
        Task<ApiResponse> AddAsync(TaskRequest request);
        Task<ApiResponse> UpdateAsync(TaskRequest request);
        Task<ApiResponse> DeleteAsync(TaskRequest request);
    }
}
