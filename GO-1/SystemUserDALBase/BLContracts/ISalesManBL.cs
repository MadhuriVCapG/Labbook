using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreatOutdoors.Entities;

namespace GreatOutdoors.Contracts.BLContracts
{
    public interface ISalesManBL : IDisposable
    {
        Task<bool> AddSalesManBL(SalesMan newSalesMan);
        Task<List<SalesMan>> GetAllSalesMansBL();
        Task<SalesMan> GetSalesManBySalesManIDBL(Guid searchSalesManID);
        Task<List<SalesMan>> GetSalesMansByNameBL(string salesManName);
        Task<SalesMan> GetSalesManByEmailBL(string email);
        Task<SalesMan> GetSalesManByEmailAndPasswordBL(string email, string password);
        Task<bool> UpdateSalesManBL(SalesMan updateSalesMan);
        Task<bool> UpdateSalesManPasswordBL(SalesMan updateSalesMan);
        Task<bool> DeleteSalesManBL(Guid deleteSalesManID);

        Task<bool> AddSalesDAL(Guid saleOrderID, Guid salesManID);
        Task<List<int>>  GetSalesDAL(Guid salesManID);
        Task<int> SearchSalesDAL(Guid searchSalesID, Guid salesManID);
    }
}


