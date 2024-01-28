using Domain.Entities;
using Domain.Repository;
using Domain.Request;
using Domain.Response;
using Domain.Utils;
using ServiceAbstraction.Abstractions;

namespace Services.Services
{
    internal class TasksService : ITasksService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TasksService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ApiResponse> GetAllAsync()
        {
            var tasks = await _repositoryManager.TasksRepository.GetAllAsync();
            var response = tasks.Select(t => new TaskResponse(t));
            return ApiResponses.Success("", response);
        }

        public async Task<ApiResponse> GetByIdAsync(long id)
        {
            var task = await _repositoryManager.TasksRepository.GetByIdAsync(id);

            if (task is null)
                return ApiResponses.ResourceDoesNotExist(Convert.ToString(id));

            var response = new TaskResponse(task);

            return ApiResponses.Success("", response);
        }

        public async Task<ApiResponse> GetAllByUserIdASync(long id)
        {
            var tasks = await _repositoryManager.TasksRepository.GetAllByUserIdAsync(id);

            var response = tasks.Select(t => new TaskResponse(t));

            return ApiResponses.Success("", response);
        }

        public async Task<ApiResponse> AddAsync(TaskRequest request)
        {
            var task = new TaskItem
            {
                Description = request.Description,
                DueDate = request.DueDate,
                Id = request.Id,
                Priority = request.Priority,
                Status = request.Status,
                Title = request.Title,
                UserId = request.UserId,
            };

            await _repositoryManager.TasksRepository.AddAsync(task);
            var success = await _repositoryManager.TasksRepository.SaveChangesAsync();

            if (!success)
                return ApiResponses.InternalServerError();

            request.Id = task.Id;
            return ApiResponses.Success("", request);
        }

        public async Task<ApiResponse> UpdateAsync(TaskRequest request)
        {
            var task = await _repositoryManager.TasksRepository.GetByIdAsync(request.Id);

            if (task is null)
                return ApiResponses.ResourceDoesNotExist(request.Title);

            task.Title = request.Title;
            task.UserId = request.UserId;
            task.Status = request.Status;
            task.DueDate = request.DueDate;
            task.Priority = request.Priority;

            await _repositoryManager.TasksRepository.UpdateAsync(task);
            var success = await _repositoryManager.TasksRepository.SaveChangesAsync();

            if (!success)
                return ApiResponses.InternalServerError();

            request.Id = task.Id;
            return ApiResponses.Success("", request);
        }

        public async Task<ApiResponse> DeleteAsync(TaskRequest request)
        {
            var task = await _repositoryManager.TasksRepository.GetByIdAsync(request.Id);

            if (task is null)
                return ApiResponses.ResourceDoesNotExist(request.Title);

            _repositoryManager.TasksRepository.Delete(task);

            return ApiResponses.Success("", request);
        }
    }
}
