using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    [RoutePrefix("NewRoute")]
    public class NewController : ApiController
    {
        //public class GetAll
        //{
        //    public string FirstName { get; set; }
        //    public string SecondName { get; set; }
        //    public SecondGet SecondGet;
        //}
        //public class SecondGet
        //{
        //    public string Mobile { get; set; }
        //    public string EmailId { get; set; }
        //}
        public class GetAll
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Date { get; set; }
        }

        [Route("firstCall")]
        [HttpPost]
        public string firstCall(HttpRequestMessage request, [FromBody] GetAll getAll)
        {
            return "Data Reached";
        }

        [Route("getDataForAngularGrid")]
        [HttpGet]
        public List<GetAll> getDataForAngularGrid(HttpRequestMessage request)
       {
            DataTable dt = new DataTable();
            List<GetAll> list = new List<GetAll>();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=D2ProjectCost;Integrated Security=True");
                con.Open();
                var query = "select EmployeeID as customerid,EmployeeName as name,'testadr' as address,email,'123456789' as phno,getdate() as date from TS_Employee";
                SqlCommand com = new SqlCommand(query, con); //creating SqlCommand object  
                com.CommandType = CommandType.Text;
                com.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter adptr = new SqlDataAdapter(com);
                adptr.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetAll GetAll = new GetAll();
                    GetAll.CustomerId = Convert.ToInt32(dt.Rows[i]["customerid"]);
                    GetAll.Name = dt.Rows[i]["name"].ToString();
                    GetAll.Address = dt.Rows[i]["address"].ToString();
                    GetAll.Email = dt.Rows[i]["email"].ToString();
                    GetAll.PhoneNumber = dt.Rows[i]["phno"].ToString();
                    GetAll.Date = dt.Rows[i]["date"].ToString();
                    list.Add(GetAll);
                }
            }
            catch (Exception e)
            {
            }
            return list;
        }
    }
}