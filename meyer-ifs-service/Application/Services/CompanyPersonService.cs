using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastracture.Repositories.CompanyPersonRepository;

namespace Application.Services
{
    public class CompanyPersonService : ICompanyPersonService
    {
        private readonly ICompanyPersonRepository _companyPersonRepository;

        public CompanyPersonService(ICompanyPersonRepository companyPersonRepository)
        {
            _companyPersonRepository = companyPersonRepository;
        }

        public async Task<List<CompanyPerson>> GetAllCompanyPerson()
        {
            var entity = await _companyPersonRepository.GetAllAsync();
            
            return entity.ToList();
        }

        
    }
}