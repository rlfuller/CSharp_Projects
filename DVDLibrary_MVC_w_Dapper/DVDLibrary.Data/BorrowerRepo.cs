using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DVDLibrary.Data.Config;
using DVDLibrary.Models;

namespace DVDLibrary.Data
{
    public class BorrowerRepo
    {
        public List<DVDBorrowerDetail> GetAllBorrowerDetails(int dvdId)
        {
            var results = new List<DVDBorrowerDetail>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var d = new DynamicParameters();
                d.Add("dvdID", dvdId);
                results = cn.Query<DVDBorrowerDetail>("SELECT * FROM dvdborrowerdetails WHERE dvdId = @dvdId", d).ToList();
            }
            return results;
        }

        public List<Borrower> GetBorrowerById(List<DVDBorrowerDetail> details)
        {
            var resultNames = new List<Borrower>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                foreach (var detail in details)
                {
                    var d = new DynamicParameters();
                    d.Add("borrowerID", detail.BorrowerId);
                    var results =
                        cn.Query<Borrower>("SELECT * FROM borrowers WHERE borrowerID = @borrowerID", d).FirstOrDefault();
                    resultNames.Add(results);
                }
            }
            return resultNames;
        }

    }
}
