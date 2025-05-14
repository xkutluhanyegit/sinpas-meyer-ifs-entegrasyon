using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Utilities.Results.Implementations;
using Domain.Utilities.Results.Interfaces;
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

        public async Task<IDataResult<IEnumerable<CompanyPerson>>> GetAllCompanyPerson()
        {
            var entity = await _companyPersonRepository.GetAllAsync();
            if (entity == null)
            {
                return new ErrorDataResult<IEnumerable<CompanyPerson>>("ErrorResult: Veri bulunamadı!");
            }
            return new SuccessDataResult<IEnumerable<CompanyPerson>>(entity, "SuccessResult: Veri başarıyla getirildi!");
        }

        /*
        public async Task<List<CompanyPerson>> GetAllCompanyPerson()
        {
            var entity = await _companyPersonRepository.GetAllAsync();
            
            return entity.ToList();
        }
        */


    }
}