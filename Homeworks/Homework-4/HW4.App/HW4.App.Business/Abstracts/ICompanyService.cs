
using HW4.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HW4.App.Business.Abstracts
{
    public interface ICompanyService
    {
        List<Company> GetCompanies();
        Company GetCompany(Expression<Func<Company, bool>> filter);
        void InsertCompany(Company company); 
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }
}