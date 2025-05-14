using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domain.Entities;
using Infrastracture.Repositories.GenericRepositoryBase;
using Oracle.ManagedDataAccess.Client;

namespace Infrastracture.Repositories.CompanyPersonRepository
{
    public class CompanyPersonRepository : ICompanyPersonRepository
    {
        private readonly string _connectionString;

        public CompanyPersonRepository()
        {
            _connectionString = "User Id=IFSAPP;Password=timetravel;Data Source=//192.168.48.20:1521/PROD";
        }

        public Task AddAsync(CompanyPerson entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompanyPerson>> GetAllAsync()
        {
            string query = "select cpa.company_id,cpa.emp_no,cpa.fname,cpa.lname,bod.data from company_person_all cpa left join binary_object_data_block_tab bod on cpa.picture_id = bod.blob_id where cpa.company_id IN ('NE','KL','NT','KS','KK','GK')";
            var sql = $"{query}";

            using (var conn = new OracleConnection(_connectionString))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<CompanyPerson>(sql);
            }
        }

        public Task<CompanyPerson> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CompanyPerson entity)
        {
            throw new NotImplementedException();
        }
    }
}