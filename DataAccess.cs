using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WienerOsiguranje.Models;
using Dapper;
using System.Net;

namespace WienerOsiguranje
{
    public class DataAccess
    {
        private string connectionString;

        public DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DatabaseWienerConnection"].ConnectionString;
        }

        public List<Partner> GetAllPartnersData()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Partner>("SELECT * FROM Partners;").AsList();
            }
        }

        public void CreateNewPolicy(string partnerNumber, decimal amount)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {

                //dohvati PartnerId pomocu PartnerNumber
                string query = "SELECT PartnerId FROM Partners WHERE PartnerNumber = @partnerNumber;";
                int partnerId = db.QueryFirstOrDefault<int>(query, new { partnerNumber});
                query = "INSERT INTO Policies (PartnerId, PolicyAmount)"
                    + "VALUES(@partnerId,@amount);";
                //insertaj u policy dakle partnerid policy id i amount
                db.Query(query, new
                {
                    partnerId,
                    amount,
                });
            }
        }

        public decimal GetPartnerPolicyAmount(string partnerNumber)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT PartnerId FROM Partners WHERE PartnerNumber = @partnerNumber;";
                int partnerId = db.QueryFirstOrDefault<int>(query, new { partnerNumber });
                query = "SELECT COALESCE(SUM(PolicyAmount), 0) \r\nFROM Policies\r\nWHERE PartnerId = @PartnerId;";             
                decimal totalPolicyAmount = db.QueryFirstOrDefault<decimal>(query, new { partnerId });
                return totalPolicyAmount; 
            }
        }
        
        public int GetPartnersNumberOfPolicies(string partnerNumber)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT PartnerId FROM Partners WHERE PartnerNumber = @partnerNumber;";
                int partnerId = db.QueryFirstOrDefault<int>(query, new { partnerNumber });
                query = "SELECT COUNT(*) \r\nFROM Policies\r\nWHERE PartnerId = @PartnerId;";
                int numberOfpolicies = db.QueryFirstOrDefault<int>(query, new { partnerId });
                return numberOfpolicies;
            }
        }

        public void InsertNewPartnerInDatabase(string firstName, string lastName, string address, string partnerNumber, string croatianPIN, int partnerTypeID, string createdByUser, bool isForeign, string externalCode, char gender)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Partners (FirstName, LastName, Address, CroatianPIN, CreateByUser, IsForeign, ExternalCode, Gender,PartnerNumber,PartnerTypeId)" +
                    "\r\nVALUES\r\n    (@firstName, @lastName, @address,@croatianPIN, @createdByUser, @isForeign, @externalCode, @gender,@partnerNumber,@partnerTypeID);";
                db.Query(query, new
                {
                    firstName,
                    lastName,
                    address,
                    croatianPIN,
                    createdByUser,
                    isForeign,
                    externalCode,
                    gender,
                    partnerNumber,
                    partnerTypeID
                });
            }
        }

        public Partner GetDataAboutPartnerWithID(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Partners WHERE PartnerId = @id;";
                return db.QueryFirstOrDefault<Partner>(query, new { id });
            }
        }

        public List<Policy> GetAllPoliciesData()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Policy>("SELECT * FROM Policies").AsList();
            }
        }
    }
}