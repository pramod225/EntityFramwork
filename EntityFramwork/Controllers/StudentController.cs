using EntityFramwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EntityFramwork.Controllers
{
    public class StudentController : Controller
    {
        StudentDbContext db = new StudentDbContext();
        // GET: Student
        public ActionResult Index()
        {

            return View(db.students.ToList());
        }
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentId = db.students.Count() + 1;
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
           

        }
        public ActionResult Edit(int? StudentId)
        {
            Student student = db.students.Where(x => x.StudentId == StudentId).FirstOrDefault();
            if (student!=null)
            {
                return View(student);
            }
            else
            {
                return  RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            Student temp = db.students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            foreach (Student student1 in db.students)
            {
                if (student1.StudentId == student.StudentId)
                {
                    student1.StudentName = student.StudentName;
                    student1.StudentDateOfBirth = student.StudentDateOfBirth;
                    student1.StudentEmailId = student.StudentEmailId;
                    student1.StudentAddress = student.StudentAddress;
                   
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? StudentId)
        {
            Student student = db.students.Where(x => x.StudentId == StudentId).FirstOrDefault();
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            Student student1 = db.students.Where(x => x.StudentId ==student.StudentId).FirstOrDefault();
            db.students.Remove(student1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(Student student)
        {
            Student student1 = db.students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            if (student1 != null)
            {
                return View(student1);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
