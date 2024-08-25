using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebApplicationCRUDDemo.Data;

namespace WebApplicationCRUDDemo.Controllers
{
    public class UserController : Controller
    {
        UserDbEntities userDbEntities = new UserDbEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllUsers()
        {
            var result =userDbEntities.UserTables.ToList();
            return View(result);
        }
        [HttpGet]
       
        public ActionResult GetById(int? id)
        {
            var result = userDbEntities.UserTables.FirstOrDefault(u => u.Id == id);
            return View(result);
        }
        [HttpGet]
        public ActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewUser(int txtId,string txtName,string txtEmail,string txtPNum)
        {
            UserTable userTable = new UserTable();
            userTable.Id = txtId;
            userTable.UName = txtName;
            userTable.Email = txtEmail;
            userTable.PNum = txtPNum;

            userDbEntities.UserTables.Add(userTable);
            userDbEntities.SaveChanges();

            return RedirectToAction("GetAllUsers");
        }
        [HttpGet]
        public ActionResult EditRecord(int? id)
        {
            var Record = userDbEntities.UserTables.Find(id);
            return View(Record);
        }
        [HttpPost]
        public ActionResult EditRecord(int txtId,string txtName,string txtEmail,string txtPNum)
        {
            var recordTable = userDbEntities.UserTables.Find(txtId);
            recordTable.Id = txtId;
            recordTable.UName = txtName;
            recordTable.Email = txtEmail;
            recordTable.PNum = txtPNum;

            
            userDbEntities.SaveChanges();

           
             return RedirectToAction("GetAllUsers");

        }
        [HttpGet]
        public ActionResult DeleteRecord(int? id)
        
        {
            var Record = userDbEntities.UserTables.Find(id);
            userDbEntities.UserTables.Remove(Record);
            userDbEntities.SaveChanges();

            return View(Record);

           
        }
        [HttpPost]
        public ActionResult DeleteNewRecord()
        {

           return RedirectToAction("GetAllUsers");
        }

    }
}