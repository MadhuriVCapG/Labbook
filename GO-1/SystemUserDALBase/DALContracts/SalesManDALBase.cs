using System;
using System.Collections.Generic;
using System.IO;
using GreatOutdoors.Entities;
using Newtonsoft.Json;

namespace GreatOutdoors.Contracts.DALContracts
{
    /// <summary>
    /// This abstract class acts as a base for SalesManDAL class
    /// </summary>
    public abstract class SalesManDALBase
    {
        //Collection of SalesMans
        protected static List<SalesMan> salesmanList = new List<SalesMan>();
        private static string fileName = "salesmen.json";

        //Methods for CRUD operations
        public abstract bool AddSalesManDAL(SalesMan newSalesMan);
        public abstract List<SalesMan> GetAllSalesMansDAL();
        public abstract SalesMan GetSalesManBySalesManIDDAL(Guid searchSalesManID);
        public abstract List<SalesMan> GetSalesMansByNameDAL(string salesmanName);
        public abstract SalesMan GetSalesManByEmailDAL(string email);
        public abstract SalesMan GetSalesManByEmailAndPasswordDAL(string email, string password);
        public abstract bool UpdateSalesManDAL(SalesMan updateSalesMan);
        public abstract bool UpdateSalesManPasswordDAL(SalesMan updateSalesMan);
        public abstract bool DeleteSalesManDAL(Guid deleteSalesManID);
        public abstract bool AddSalesDAL(Guid saleOrderID, Guid salesManID);
        public abstract List<int> GetSalesDAL(Guid salesManID);
        public abstract int SearchSalesDAL(Guid searchSalesID, Guid salesManID);





        /// <summary>
        /// Writes collection to the file in JSON format.
        /// </summary>
        public static void Serialize()
        {
            string serializedJson = JsonConvert.SerializeObject(salesmanList);
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                streamWriter.Write(serializedJson);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Reads collection from the file in JSON format.
        /// </summary>
        public static void Deserialize()
        {
            string fileContent = string.Empty;
            if (!File.Exists(fileName))
                File.Create(fileName).Close();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                fileContent = streamReader.ReadToEnd();
                streamReader.Close();
                var systemUserListFromFile = JsonConvert.DeserializeObject<List<SalesMan>>(fileContent);
                if (systemUserListFromFile != null)
                {
                    salesmanList = systemUserListFromFile;
                }
            }
        }

        /// <summary>
        /// Static Constructor.
        /// </summary>
        static SalesManDALBase()
        {
            Deserialize();
        }
    }
}

