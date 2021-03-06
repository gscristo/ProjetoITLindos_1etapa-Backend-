namespace DataAccess.Repositories
{
    using DapperExtensions;
    using Dapper;
    using DataAccess.Context;
    using DataAccess.Interfaces;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Linq;
    using System;

    public class Repository<T> : IRepository<T> where T : class
    {
        private IDataContext _dataContext { get; set; }

        public Repository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public T GetById(Guid id)
        {
            var result = _dataContext.Connection.Get<T>(id);

            _dataContext.Dispose();

            return result;
        }

        public T GetByName(string Name)
        {
            var result = _dataContext.Connection.Get<T>(Name);

            _dataContext.Dispose();

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = _dataContext.Connection.GetList<T>();

            _dataContext.Dispose();

            return result;
        }

        public Guid Insert(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = _dataContext.Connection.Insert(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public void Update(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            _dataContext.Connection.Update(entity, transaction, commandTimeout);

            _dataContext.Dispose();
        }

        public void Delete(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            _dataContext.Connection.Delete(entity, transaction, commandTimeout);

            _dataContext.Dispose();
        }

        public void DeleteByCode(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            _dataContext.Connection.Delete(entity, transaction, commandTimeout);

            _dataContext.Dispose();
        }

        public async Task<T> GetByIdAsync(Guid Id, IDbTransaction transaction = null, int? commandTimeout = null)
        {

            var result = await _dataContext.Connection.GetAsync<T>(Id, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<IEnumerable<T>> GetByNameAsync(string Name, IDbTransaction transaction = null, int? commandTimeout = null)

        {
            string query = $"select * from dbo.Product where Name Like '%{Name}%'";



            var result = await _dataContext.Connection.QueryAsync<T>(query);



            _dataContext.Dispose();

            return result;
        }

        public async Task<IEnumerable<T>> GetProductByCodeAsync(string Code, IDbTransaction transaction = null, int? commandTimeout = null)

        {
            string query = $"select * from dbo.Product where Code Like '%{Code}%'";



            var result = await _dataContext.Connection.QueryAsync<T>(query);



            _dataContext.Dispose();

            return result;
        }

        public async Task<T> GetUnicProductByCodeAsync(string Code, IDbTransaction transaction = null, int? commandTimeout = null)

        {
            string query = $"select * from dbo.Product where Code = {Code}";



            var result = await _dataContext.Connection.QueryAsync<T>(query);



            _dataContext.Dispose();

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetPersonByNameAsync(string Name, IDbTransaction transaction = null, int? commandTimeout = null)

        {
            string query = $"select * from dbo.Person where Name Like '%{Name}%'";



            var result = await _dataContext.Connection.QueryAsync<T>(query);



            _dataContext.Dispose();

            return result;
        }

        public async Task<IEnumerable<T>> GetPersonByCpfAsync(string SocialNumber, IDbTransaction transaction = null, int? commandTimeout = null)

        {
            string query = $"select * from dbo.Person where SocialNumber Like '%{SocialNumber}%'";



            var result = await _dataContext.Connection.QueryAsync<T>(query);



            _dataContext.Dispose();

            return result;
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, IList<ISort> sort = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.GetListAsync<T>(predicate, sort, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task BulkInsertAsync(IEnumerable<T> entities, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            await _dataContext.Connection.InsertAsync(entities, transaction, commandTimeout);

            _dataContext.Dispose();
        }

        public async Task<dynamic> InsertAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.InsertAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<bool> UpdateAsync(T entity, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.UpdateAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<bool> DeleteAsync(T entity, IDbTransaction transaction, int? commandTimeout = null)
        {
            var result = await _dataContext.Connection.DeleteAsync(entity, transaction, commandTimeout);

            _dataContext.Dispose();

            return result;
        }

        public async Task<PaginationResponse<T>> GetAllAsyncPagination(int pageSize, int pageIndex, string sort, string direction, string tableName = "")
        {
            string table = typeof(T).Name;

            if (!string.IsNullOrEmpty(tableName))
                table = tableName;

            string defaultSort = $"{table}Id";
            string defaultDirection = "DESC";

            if (!string.IsNullOrEmpty(sort))
                defaultSort = sort;

            if (!string.IsNullOrEmpty(direction))
                defaultDirection = direction;

            string query = $@"SELECT *, COUNT({table}Id) OVER() Id
                            FROM {table} 
                            ORDER BY {defaultSort} {defaultDirection}
                            OFFSET(@PageIndex - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY";

            using (IDbConnection conn = await _dataContext.CreateConnectionAsync())
            {
                int totalRecords = 0;

                var result = await conn.QueryAsync<T, int, T>(query, (entity, totalCount) =>
                {
                    totalRecords = totalCount;
                    return entity;
                },
                new
                {
                    PageSize = pageSize,
                    PageIndex = pageIndex
                },
                splitOn: "Id");

                return new PaginationResponse<T>()
                {
                    TotalRecords = totalRecords,
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    DataList = result
                };
            }
        }


    }
}
