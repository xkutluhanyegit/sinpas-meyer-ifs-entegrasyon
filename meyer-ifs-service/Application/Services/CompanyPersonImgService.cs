using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastracture.Repositories.CompanyPersonImgRepository;

namespace Application.Services
{
    public class CompanyPersonImgService : ICompanyPersonImgService
    {
        private readonly ICompanyPersonImgRepository _companyPersonImgRepository;
        public CompanyPersonImgService(ICompanyPersonImgRepository companyPersonImgRepository)
        {
            _companyPersonImgRepository = companyPersonImgRepository;
        }
        public async Task<List<CompanyPersonImg>> GetAllCompanyPersonImg()
        {
            var entity = await _companyPersonImgRepository.GetAllAsync();
            List<CompanyPersonImg> companyPersonImgList = new List<CompanyPersonImg>();

            foreach (var item in entity)
            {
                companyPersonImgList.Add(new CompanyPersonImg
                {
                    BLOB_ID = item.BLOB_ID,
                    DATA = item.DATA
                });
            }
            return entity.ToList();

        }
    }
}