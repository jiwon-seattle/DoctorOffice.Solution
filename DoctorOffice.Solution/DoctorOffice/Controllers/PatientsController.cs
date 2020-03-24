using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DoctorOffice.Controllers
{
  public class PatientsController : Controller
  {
    private readonly DoctorOfficeContext _db;

    public PatientsController(DoctorOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }

    public ActionResult Details(int id)
    {
      var thisPatient = _db.Patients
        .Include(patient => patient.Doctors)
        .ThenInclude(join => join.Doctor)
        .FirstOrDefault(patient => patient.PatientId == id);
      return View(thisPatient);
    }

    public ActionResult Create()
    {
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "LastName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient)
    {
      _db.Patients.Add(patient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "LastName");
      return View(thisPatient);
    }

    [HttpPost]
    public ActionResult Edit(Patient patient, int doctorId)
    {
      if (doctorId != 0)
      {
        // _db.DoctorPatients.RemoveRange(_db.DoctorPatients);
        _db.DoctorPatients.Add(new DoctorPatient() { DoctorId = doctorId, PatientId = patient.PatientId});
      }
      _db.Entry(patient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDoctor(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "LastName");
      return View(thisPatient);
    }

    [HttpPost]
    public ActionResult AddDoctor(Patient patient, int DoctorId)
    {

      if (DoctorId != 0)
      {
        // _db.DoctorPatients.RemoveRange(_db.DoctorPatients.Where( doctorId => DoctorId == DoctorId));
        _db.DoctorPatients.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      return View(thisPatient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      _db.Patients.Remove(thisPatient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteDoctor(int joinId)
    {
      var joinEntry = _db.DoctorPatients.FirstOrDefault(entry => entry.DoctorPatientId == joinId);
      _db.DoctorPatients.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


    // public ActionResult AddCategory(int id)
    // {
    //   var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
    //   ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //   return View(thisItem);
    // }

    // [HttpPost]
    // public ActionResult AddCategory(Item item, int CategoryId)
    // {
    //   if (CategoryId != 0)
    //   {
    //     _db.CategoryItem.Add(new CategoryItem() { CategoryId = CategoryId, ItemId = item.ItemId });
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

  }
}