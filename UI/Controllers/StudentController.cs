using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel;
using BLL;

using DAL;
using Newtonsoft.Json;
using System.IO;

namespace UI.Controllers     
{
    public class StudentController : Controller
    {
        StudentVMRepository repo = new StudentVMRepository();
        SoadEntities db = new SoadEntities();

        // GET: Student
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult VaildTime(TimeSpan start1 , TimeSpan end1 , TimeSpan start2 , TimeSpan end2 , string day1 , string day2)
        {
            if(day1 == day2 && ((start1>=start2&&start1<=end2)||(start2>=start1&&start2<=end1))/* ((start2 <= start1 && end2 >= end1) || (end2 >= end1 && start2 <= end1))*/)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult LogOut()
        {
            Session["UserData"] = null;
            Session.Abandon();
            return RedirectToAction("Profile");
        }
        public ActionResult Profile( )
        {
           
            return View();
        }
        public JsonResult LoadAllSubjects(int id)
        {
            var sub = repo.getAllSubjects();
            List<SubjectVM> arr = new List<SubjectVM>();
            List<SubjectVM> arr2 = new List<SubjectVM>();
            var Subject2 = db.StudentSubjects.Where(x => x.student_Id == id && x.status == 4).FirstOrDefault();
            if (Subject2 == null)
            {
                arr = repo.filterSubjects(id);
                return Json(arr, JsonRequestBehavior.AllowGet);
            }
            else
            {
                arr = repo.filterSubjects(id);
                foreach (var item in arr)
                {
                    var Subject3 = db.StudentSubjects.Where(x => x.student_Id == id && x.subject_Id == item.subjectId && x.status == 4).FirstOrDefault();
                    if(Subject3 == null)
                    {
                        arr2.Add(item);
                    }
                }
                return Json(arr2, JsonRequestBehavior.AllowGet);
            }
            
        }
        public JsonResult LoadAllSubjects2(int id)
        {

            var sub = repo.getAllSubjects();
            List<SubjectVM> arr = new List<SubjectVM>();
            foreach (var item in sub)
            {
                var Subject = db.StudentSubjects.Where(x => x.student_Id == id && x.subject_Id == item.subjectId && x.status == 4).FirstOrDefault();
                if (Subject != null)
                {
                    arr.Add(item);
                }
            }
            return Json(arr, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(decimal National,string Password)
        {
            bool check = repo.sign(National, Password);
            int  id = db.Student.Where(x => x.nationalId == National && x.password == Password).Select(x => x.studentId).FirstOrDefault();
            if (check == true)
            {
                Session["UserData"] = id;
            }
   
            return Json(check, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAllGenders()
        {
            var gen = repo.getAllGenders();
            return Json(gen,JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAllDepartments()
        {
            var dept = repo.getAllDepartments();
            return Json(dept, JsonRequestBehavior.AllowGet);
        }
        public JsonResult LoadAllLevels()
        {
            var levels = repo.getAllLevels();
            return Json(levels, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddStudent(StudentVM stud)
        {
            Student obj = new Student();
            if (!db.Student.Select(x=>x.nationalId).Contains(stud.nationalId))
            {
                repo.Add(stud);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Save(int[] subArray, int ID)
        {
            StudentSubjects obj = new StudentSubjects();
            foreach (var item in subArray)
            {
                obj.student_Id = ID;
                obj.subject_Id = item;
                obj.status =(int)StudentStatus.regist;
                //obj.isPassed = true;
                db.StudentSubjects.Add(obj);
                db.SaveChanges();
            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult SaveProfileImage(int id)
        {
            
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["HelpSectionImages"];
                HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                var fileName = Path.GetFileName(filebase.FileName);
                var fileUrl = Server.MapPath("~/ProfilesImg/");
                string extension = Path.GetExtension(filebase.FileName);
                string newFileName = Guid.NewGuid() + extension;
                var path = Path.Combine(fileUrl, newFileName);
                filebase.SaveAs(path);
                var stu = db.Student.FirstOrDefault(x => x.studentId == id);
                stu.image = newFileName;
                db.SaveChanges();
                return Json("File Saved Successfully.");
            }
            else { return Json("No File Saved."); }
        }

    }
}