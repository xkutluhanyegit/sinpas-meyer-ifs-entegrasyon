using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Oracle.ManagedDataAccess.Client;

namespace Infrastracture.Repositories.CompanyPersonImgRepository
{
    public class CompanyPersonImgRepository : ICompanyPersonImgRepository
    {
        private readonly string _connectionString;

        public CompanyPersonImgRepository()
        {
            _connectionString = "User Id=IFSAPP;Password=timetravel;Data Source=//192.168.48.20:1521/PROD";
        }
        public Task AddAsync(CompanyPersonImg entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyPersonImg>> GetAllAsync()
        {
            var sql = $"SELECT BLOB_ID,DATA FROM binary_object_data_block_tab";
            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CompanyPersonImg>(sql);
            }
        }

        public Task<CompanyPersonImg> GetByIdAsync( int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyPersonImg entity)
        {
            throw new NotImplementedException();
        }
    }
}