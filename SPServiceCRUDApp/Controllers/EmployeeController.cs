using System.Data;
using System.Linq;
using System.Web.Mvc;
using SPServiceCRUDApp.Models;
using SPServiceCRUDApp.DALSPService;
using System;

namespace SPServiceCRUDApp.Controllers
{
    public class EmployeeController : Controller
    {
        //private CRUDAppContext db = new CRUDAppContext();
        private SPService spService = new SPService() ;
        public EmployeeController() {}

        // GET: Employee
        public ActionResult Index()
        {
            var data = spService.GetDataWithoutParameter("USP_GET_ALLEMPLOYEE").Tables[0].AsEnumerable().Select(x => new Employee
            {
                Id=x.Field<int>("Id"),
                Name=x.Field<string>("Name"),
                FatherName = x.Field<string>("FatherName"),
                EmployeeCode = x.Field<string>("EmployeeCode"),
                Address = x.Field<string>("Address")
            }).ToList();
            ViewBag.Employee = data;
            return View();
        }
        // GET: Employee
        [HttpGet]
        public JsonResult GetAllEmployee(int Id)
        {
            try
            {
                var data = spService.GetDataWithParameter(new { id = Id }, "USP_GET_ALLEMPLOYEEBYID").Tables[0].AsEnumerable().Select(x => new Employee
                {
                    Id = x.Field<int>("Id"),
                    Name = x.Field<string>("Name"),
                    FatherName = x.Field<string>("FatherName"),
                    EmployeeCode = x.Field<string>("EmployeeCode"),
                    Address = x.Field<string>("Address")
                }).FirstOrDefault();
                return Json(new { Status = true, Result = data }, JsonRequestBehavior.AllowGet);
            }catch(Exception Ex)
            {
                return Json(new { Status = true, Result = Ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,FatherName,EmployeeCode,Address")] Employee employee)
        {
            try { 
                var param = new {EmpCode=employee.EmployeeCode,EmpName=employee.Name,EmpFatherName=employee.FatherName,Address=employee.Address ,Id=employee.Id};
                var data = spService.GetDataWithParameter(param, "USP_INSERT_EMPLOYEE_BASIC").Tables[0].AsEnumerable().Select(x => new
                {
                    Message = x.Field<string>("message")
                }).FirstOrDefault();

                return Json(new {Status=true,Result=data}, JsonRequestBehavior.AllowGet);
            }catch(Exception Ex)
            {
                return Json(new { Status = false, Result = Ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete([Bind(Exclude = "Name,FatherName,EmployeeCode,Address")] Employee employee)
        {
            try
            {
                var param = new { Id = employee.Id };
                var data = spService.GetDataWithParameter(param, "USP_DELETE_EMPLOYEE_BASIC").Tables[0].AsEnumerable().Select(x => new
                {
                    Message = x.Field<string>("message")
                }).FirstOrDefault();
                return Json(new { Status = true, Result = data }, JsonRequestBehavior.AllowGet);
            }catch(Exception Ex)
            {
                return Json(new { Status = false, Result = Ex.InnerException.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
