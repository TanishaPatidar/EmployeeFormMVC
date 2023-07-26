
using EmployeeFormMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeFormMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public List<Employee> datalist = new List<Employee>();
        public static int count = 0;
    
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Employee employee)
        {

            if (ModelState.IsValid)
            {

                count = count + 1;
                employee.Id = count;

                if (Session["lstEmp"] != null)
                {
                    datalist = (List<Employee>)Session["lstEmp"];

                }
                datalist.Add(employee);
                Session["lstEmp"] = datalist;
                var emplist = (List<Employee>)Session["lstEmp"];
                ViewBag.Mylist = emplist;

                return View(emplist);
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            
            
                if (Session["lstEmp"] != null)
                {
                    List<Employee> datalist = (List<Employee>)Session["lstEmp"];

                    var std = datalist.FirstOrDefault(e => e.Id == id);

                    if (std != null)
                    {
                        ViewBag.photourl = std.emImage;
                        return View(std);
                    }
                
            }
            return RedirectToAction("Submit");
        }
        [HttpPost]
        public ActionResult Edit(Employee em)
        {
            if (ModelState.IsValid)
            {

                if (Session["lstEmp"] != null)
                {
                    datalist = (List<Employee>)Session["lstEmp"];
                    var std = datalist.FirstOrDefault(e => e.Id == em.Id);
                    if (em.emImage == null)
                    {
                        em.emImage = std.emImage;
                    }

                    if (std != null)
                    {
                        datalist.Remove(std);
                        datalist.Add(em);
                        Session["emp"] = datalist;
                        List<Employee> orderedList = datalist.OrderBy(e => e.Id).ToList();
                        datalist = orderedList;
                        ViewBag.MyList = datalist;
                    }

                }
                return View("Submit");
            }
            return View("Index");
            
        }


            public ActionResult Delete(int id)
           {
            // int delid = id;

            if (ModelState.IsValid)
            {

                if (Session["lstEmp"] != null)
                {
                    List<Employee> datalist = (List<Employee>)Session["lstEmp"];

                    var std = datalist.FirstOrDefault(e => e.Id == id);
                    if (std != null)
                    {
                        datalist.Remove(std);
                        Session["lstEmp"] = datalist;
                        List<Employee> orderedList = datalist.OrderBy(e => e.Id).ToList();
                        datalist = orderedList;
                        ViewBag.Mylist = datalist;
                    }
                }
            }
            return View("Submit");
        }
    }
}