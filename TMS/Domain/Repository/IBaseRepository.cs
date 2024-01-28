namespace Domain.Repository
{
    public interface IBaseRepository
    {
        Task AddAsync<T>(T entity) where T : class;
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;
        void Update<T>(T entity) where T : class;
        Task UpdateAsync<T>(T entity) where T : class;
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;
        Task UpdateRangeAsync<T>(IEnumerable<T> entities) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(IEnumerable<T> entities) where T : class;
        Task DetachAsync<T>(T entity) where T : class;
        Task DetachRangeAsync<T>(IEnumerable<T> entities) where T : class;
        Task SaveAsync();
        Task<bool> SaveChangesAsync();
    }
}
