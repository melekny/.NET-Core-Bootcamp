using HW4.App.Business.Abstracts;
using HW4.App.DataAccess.EntityFramework.Repository.Abstracts;
using HW4.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HW4.App.Business.Concretes
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> repository;
        private readonly IUnitOfWork unitOfWork;
        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public List<Company> GetCompanies()
        {
            return repository.GetAll().ToList();
        }

        public Company GetCompany(Expression<Func<Company, bool>> filter)
        {
           return repository.GetById(filter);
            
        }
        public void InsertCompany(Company company)
        {
            repository.Insert(company);
            unitOfWork.Commit();
        }

        public void UpdateCompany(Company company)
        {
            repository.Update(company);
            unitOfWork.Commit();
        }

        public void DeleteCompany(Company company)
        {
            repository.Delete(company);
            unitOfWork.Commit();
        }

    }
}