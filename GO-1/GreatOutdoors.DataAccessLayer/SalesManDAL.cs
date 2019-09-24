using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreatOutdoors.Contracts.DALContracts;
using GreatOutdoors.Entities;
using GreatOutdoors.Exceptions;
using GreatOutdoors.Helpers;

namespace GreatOutdoors.DataAccessLayer
{
    /// <summary>
    /// Contains data access layer methods for inserting, updating, deleting salesmans from SalesMans collection.
    /// </summary>
    public class SalesManDAL : SalesManDALBase, IDisposable
    {
        /// <summary>
        /// Adds new salesman to SalesMans collection.
        /// </summary>
        /// <param name="newSalesMan">Contains the salesman details to be added.</param>
        /// <returns>Determines whether the new salesman is added.</returns>
        public override bool AddSalesManDAL(SalesMan newSalesMan)
        {
            bool salesmanAdded = false;
            try
            {
                newSalesMan.SalesManID = Guid.NewGuid();
                newSalesMan.CreationDateTime = DateTime.Now;
                newSalesMan.LastModifiedDateTime = DateTime.Now;
                salesmanList.Add(newSalesMan);
                salesmanAdded = true;
            }
            catch (Exception)
            {
                throw;
            }
            return salesmanAdded;
        }

        /// <summary>
        /// Gets all salesmans from the collection.
        /// </summary>
        /// <returns>Returns list of all salesmans.</returns>
        public override List<SalesMan> GetAllSalesMansDAL()
        {
            return salesmanList;
        }

        /// <summary>
        /// Gets salesman based on SalesManID.
        /// </summary>
        /// <param name="searchSalesManID">Represents SalesManID to search.</param>
        /// <returns>Returns SalesMan object.</returns>
        public override SalesMan GetSalesManBySalesManIDDAL(Guid searchSalesManID)
        {
            SalesMan matchingSalesMan = null;
            try
            {
                //Find SalesMan based on searchSalesManID
                matchingSalesMan = salesmanList.Find(
                    (item) => { return item.SalesManID == searchSalesManID; }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSalesMan;
        }

        /// <summary>
        /// Gets salesman based on SalesManName.
        /// </summary>
        /// <param name="salesmanName">Represents SalesManName to search.</param>
        /// <returns>Returns SalesMan object.</returns>
        public override List<SalesMan> GetSalesMansByNameDAL(string salesmanName)
        {
            List<SalesMan> matchingSalesMans = new List<SalesMan>();
            try
            {
                //Find All SalesMans based on salesmanName
                matchingSalesMans = salesmanList.FindAll(
                    (item) => { return item.SalesManName.Equals(salesmanName, StringComparison.OrdinalIgnoreCase); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSalesMans;
        }

        /// <summary>
        /// Gets salesman based on email.
        /// </summary>
        /// <param name="email">Represents SalesMan's Email Address.</param>
        /// <returns>Returns SalesMan object.</returns>
        public override SalesMan GetSalesManByEmailDAL(string email)
        {
            SalesMan matchingSalesMan = null;
            try
            {
                //Find SalesMan based on Email and Password
                matchingSalesMan = salesmanList.Find(
                    (item) => { return item.Email.Equals(email); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSalesMan;
        }

        /// <summary>
        /// Gets salesman based on Email and Password.
        /// </summary>
        /// <param name="email">Represents SalesMan's Email Address.</param>
        /// <param name="password">Represents SalesMan's Password.</param>
        /// <returns>Returns SalesMan object.</returns>
        public override SalesMan GetSalesManByEmailAndPasswordDAL(string email, string password)
        {
            SalesMan matchingSalesMan = null;
            try
            {
                //Find SalesMan based on Email and Password
                matchingSalesMan = salesmanList.Find(
                    (item) => { return item.Email.Equals(email) && item.Password.Equals(password); }
                );
            }
            catch (Exception)
            {
                throw;
            }
            return matchingSalesMan;
        }

        /// <summary>
        /// Updates salesman based on SalesManID.
        /// </summary>
        /// <param name="updateSalesMan">Represents SalesMan details including SalesManID, SalesManName etc.</param>
        /// <returns>Determines whether the existing salesman is updated.</returns>
        public override bool UpdateSalesManDAL(SalesMan updateSalesMan)
        {
            bool salesmanUpdated = false;
            try
            {
                //Find SalesMan based on SalesManID
                SalesMan matchingSalesMan = GetSalesManBySalesManIDDAL(updateSalesMan.SalesManID);

                if (matchingSalesMan != null)
                {
                    //Update salesman details
                    ReflectionHelpers.CopyProperties(updateSalesMan, matchingSalesMan, new List<string>() { "SalesManName", "SalesManMobile", "Email" });
                    matchingSalesMan.LastModifiedDateTime = DateTime.Now;

                    salesmanUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return salesmanUpdated;
        }

        /// <summary>
        /// Deletes salesman based on SalesManID.
        /// </summary>
        /// <param name="deleteSalesManID">Represents SalesManID to delete.</param>
        /// <returns>Determines whether the existing salesman is updated.</returns>
        public override bool DeleteSalesManDAL(Guid deleteSalesManID)
        {
            bool salesmanDeleted = false;
            try
            {
                //Find SalesMan based on searchSalesManID
                SalesMan matchingSalesMan = salesmanList.Find(
                    (item) => { return item.SalesManID == deleteSalesManID; }
                );

                if (matchingSalesMan != null)
                {
                    //Delete SalesMan from the collection
                    salesmanList.Remove(matchingSalesMan);
                    salesmanDeleted = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return salesmanDeleted;
        }

        /// <summary>
        /// Updates salesman's password based on SalesManID.
        /// </summary>
        /// <param name="updateSalesMan">Represents SalesMan details including SalesManID, Password.</param>
        /// <returns>Determines whether the existing salesman's password is updated.</returns>
        public override bool UpdateSalesManPasswordDAL(SalesMan updateSalesMan)
        {
            bool passwordUpdated = false;
            try
            {
                //Find SalesMan based on SalesManID
                SalesMan matchingSalesMan = GetSalesManBySalesManIDDAL(updateSalesMan.SalesManID);

                if (matchingSalesMan != null)
                {
                    //Update salesman details
                    ReflectionHelpers.CopyProperties(updateSalesMan, matchingSalesMan, new List<string>() { "Password" });
                    matchingSalesMan.LastModifiedDateTime = DateTime.Now;

                    passwordUpdated = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return passwordUpdated;
        }

        /// <summary>
        /// Clears unmanaged resources such as db connections or file streams.
        /// </summary>
        public void Dispose()
        {
            //No unmanaged resources currently
        }
    }
}



