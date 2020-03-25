using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using DoctorOffice.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DoctorOffice.Controllers
{
  [Authorize]
  public class PatientsController : Controller
  {
    private readonly DoctorOfficeContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatientsController(UserManager<ApplicationUser> userManager, DoctorOfficeContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userPatients = _db.Patients.Where(entry => entry.User.Id == currentUser.Id);
      return View(userPatients);
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
    public async Task<ActionResult> Create(Patient patient, int DoctorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      patient.User = currentUser;
      _db.Patients.Add(patient);
      if (DoctorId != 0)
      {
        _db.DoctorPatients.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
      }
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
    public ActionResult Edit(Patient patient)
    {
      _db.Entry(patient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public async Task<ActionResult> AddDoctor(int id)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var thisPatient = _db.Patients.FirstOrDefault(patients => patients.PatientId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors.Where(doctors => doctors.AcceptNewPatients == true && doctors.User.Id == currentUser.Id), "DoctorId", "LastName");
      return View(thisPatient);
    }

    [HttpPost]
    public ActionResult AddDoctor(Patient patient, int DoctorId)
    {
      try
      {
        _db.DoctorPatients.Add(new DoctorPatient() { DoctorId = DoctorId, PatientId = patient.PatientId });
        _db.SaveChanges();
      }
      catch (DbUpdateException ex)
      {
        TempData["ErrorMessage"] = "This patient is already seeing the selected doctor.";
        Console.WriteLine("Database Update Exception Error in AddDoctor(): " + ex);
      }
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

    public ActionResult Search()
    {
      List<Patient> allPatients = _db.Patients.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Search(Patient searchPatient)
    {
      List<Patient> foundPatients = _db.Patients.ToList();
      if(searchPatient.LastName != null)
      {
        string nameSearch = searchPatient.LastName.ToLower();
        foundPatients = foundPatients.FindAll(patients => patients.LastName.ToLower().Equals(nameSearch) == true);
        // Console.WriteLine("Name Search: " + nameSearch);
        // Console.WriteLine("Found Patients: " + foundPatients);
      }
      if(searchPatient.DOB != null)
      {
        foundPatients = foundPatients.FindAll(patients => patients.DOB.Equals(searchPatient.DOB) == true);
        // Console.WriteLine("DOB Search: " + searchPatient.DOB);
        // Console.WriteLine("Found Patients: " + foundPatients);
      }
      return View("SearchResult", foundPatients);
    }

  }
}