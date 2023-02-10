using MK_API_Proc.DB_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MK_API_Proc.Controllers
{
    public class ManishController : ApiController
    {
        APISTROEntities1 DB = new APISTROEntities1();

        // GET: Manish
        [HttpGet]
        [Route("Api/GetData")]
        public List<GetAllDataa_Result> GetData()
        {
            var ReadData = DB.GetAllDataa().ToList();
            return ReadData;
        }

        [HttpPost]
        [Route("Api/InsertData")]

        public HttpResponseMessage InsertData(GetAllDataa_Result obj)
        {
            DB.InsertValue(obj.AdressCode, obj.Building, obj.ZipCode, obj.Id, obj.Name, obj.Email, obj.MobileNo, obj.DepCode);
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }


        [HttpGet]
        [Route("Api/DeleteValue")]

        public HttpResponseMessage DeleteValue(int Id)
        {
            DB.DeleteData(Id);
            DB.SaveChanges();
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }

        [HttpGet]
        [Route("Api/EditData")]

        public GetDataThrowId_Result EditData(int Id)
        {
            var Data = DB.GetDataThrowId(Id).ToList();
            return Data[0];
        }

        [HttpPost]
        [Route("Api/EditData")]

        public HttpResponseMessage EditData(GetDataThrowId_Result obj)
        {
            var Data = DB.updatedata(obj.Id, obj.Name, obj.Email, obj.MobileNo,obj.AdressCode, obj.Building, obj.ZipCode, obj.DepMId, obj.DepCode, obj.DepName);
            DB.SaveChanges();
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;

        }

        [HttpGet]
        [Route("Api/UserLogin")]
        public userlogien_Result Login(string Email,string Password)
        {
            var res = DB.userlogien(Email,Password).FirstOrDefault();
            return res;
        }

        [HttpPost]
        [Route("Api/Register")]

        public HttpResponseMessage Register(login obj)
        {
            DB.insertloginval(obj.Name, obj.Email,obj.Password);
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }

    }
}

 //  