using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleSecureWeb.Data;
using SampleSecureWeb.Models;

namespace SampleSecureWeb.Controllers;

public class StudentController : Controller
{
    private readonly IStudent _studentData;
    public StudentController(IStudent studentData)
    {
        _studentData = studentData;
    }

    public IActionResult index()
    {
        var students = _studentData.GetStudents();
        return View(students);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        try
        {
            _studentData.AddStudent(student);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            ViewBag.Error = ex.Message;
        }
        return View(student);
    }

    public IActionResult Edit()
    {
        return View();
    }
}
