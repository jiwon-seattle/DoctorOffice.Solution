using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorOfficeContext _db;

    public DoctorsController(DoctorOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Doctors.ToList());
    }

    public ActionResult Details(int id)
    {
      Doctor thisDoctor = _db.Doctors
              .Include(doctor => doctor.Patients)
              .ThenInclude(join => join.Patient)
              .FirstOrDefault(doctor => doctor.DoctorId == id);
      return View(thisDoctor);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost]
    public ActionResult Edit(Doctor doctor)
    {
      _db.Entry(doctor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      return View(thisDoctor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisDoctor = _db.Doctors.FirstOrDefault(doctors => doctors.DoctorId == id);
      _db.Doctors.Remove(thisDoctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Search()
    {
      List<Doctor> allDoctors = _db.Doctors.ToList();
      List<string> specialties = new List<string>{};
      foreach (Doctor doctor in allDoctors)
      {
        specialties.Add(doctor.Specialty);
      }
      List<string> removedDuplicates = specialties.Distinct().ToList();
      ViewBag.Specialties = removedDuplicates;
      return View();
    }

    [HttpPost]
    public ActionResult Search(Doctor searchDoctor)
    {
      List<Doctor> foundDoctors = _db.Doctors.ToList();

      if (searchDoctor.LastName != null)
      {
        string nameSearch = searchDoctor.LastName.ToLower();
        foundDoctors = foundDoctors.FindAll(doctors => doctors.LastName.ToLower().Equals(nameSearch) == true);
      }
      if (searchDoctor.Specialty != null)
      {
        foundDoctors = foundDoctors.FindAll(doctors => doctors.Specialty.Equals(searchDoctor.Specialty) == true);
      }

      // List<Doctor> thisDoctors = _db.Doctors.Where(doctor => doctor.LastName == lastName).ToList();
      return View("SearchResult", foundDoctors);
    }


    
  }
}
