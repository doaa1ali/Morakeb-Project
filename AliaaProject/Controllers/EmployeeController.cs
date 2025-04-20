using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AliaaProject.Models;

namespace AliaaProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MISMorakebContext _context;

        public EmployeeController(MISMorakebContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var mISMorakebContext = _context.Employees.Include(e => e.College).Include(e => e.Governorate).Include(e => e.Grade).Include(e => e.JobGroup).Include(e => e.MaritalStatus).Include(e => e.Qualification).Include(e => e.QualificationLevel).Include(e => e.QualitativeGroup).Include(e => e.University);
            return View(await mISMorakebContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.College)
                .Include(e => e.Governorate)
                .Include(e => e.Grade)
                .Include(e => e.JobGroup)
                .Include(e => e.MaritalStatus)
                .Include(e => e.Qualification)
                .Include(e => e.QualificationLevel)
                .Include(e => e.QualitativeGroup)
                .Include(e => e.University)
                .FirstOrDefaultAsync(m => m.NationalId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Id");
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id");
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Id");
            ViewData["JobGroupId"] = new SelectList(_context.JobGroups, "Id", "Id");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Id");
            ViewData["QualificationId"] = new SelectList(_context.Qualifications, "Id", "Id");
            ViewData["QualificationLevelId"] = new SelectList(_context.QualificationLevels, "Id", "Id");
            ViewData["QualitativeGroupId"] = new SelectList(_context.QualitativeGroups, "Id", "Id");
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NationalId,Name,UniversityId,CollegeId,PhoneNumber,GovernorateId,QualificationLevelId,QualificationId,HireDate,JobGroupId,QualitativeGroupId,GradeId,JobStyle,Cadre,Specialization,MonitoringCount,LastMonitoringPeriod,IsActive,MaritalStatusId,IsObserving")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Id", employee.CollegeId);
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id", employee.GovernorateId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Id", employee.GradeId);
            ViewData["JobGroupId"] = new SelectList(_context.JobGroups, "Id", "Id", employee.JobGroupId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Id", employee.MaritalStatusId);
            ViewData["QualificationId"] = new SelectList(_context.Qualifications, "Id", "Id", employee.QualificationId);
            ViewData["QualificationLevelId"] = new SelectList(_context.QualificationLevels, "Id", "Id", employee.QualificationLevelId);
            ViewData["QualitativeGroupId"] = new SelectList(_context.QualitativeGroups, "Id", "Id", employee.QualitativeGroupId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", employee.UniversityId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Id", employee.CollegeId);
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id", employee.GovernorateId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Id", employee.GradeId);
            ViewData["JobGroupId"] = new SelectList(_context.JobGroups, "Id", "Id", employee.JobGroupId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Id", employee.MaritalStatusId);
            ViewData["QualificationId"] = new SelectList(_context.Qualifications, "Id", "Id", employee.QualificationId);
            ViewData["QualificationLevelId"] = new SelectList(_context.QualificationLevels, "Id", "Id", employee.QualificationLevelId);
            ViewData["QualitativeGroupId"] = new SelectList(_context.QualitativeGroups, "Id", "Id", employee.QualitativeGroupId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", employee.UniversityId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NationalId,Name,UniversityId,CollegeId,PhoneNumber,GovernorateId,QualificationLevelId,QualificationId,HireDate,JobGroupId,QualitativeGroupId,GradeId,JobStyle,Cadre,Specialization,MonitoringCount,LastMonitoringPeriod,IsActive,MaritalStatusId,IsObserving")] Employee employee)
        {
            if (id != employee.NationalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.NationalId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "Id", "Id", employee.CollegeId);
            ViewData["GovernorateId"] = new SelectList(_context.Governorates, "Id", "Id", employee.GovernorateId);
            ViewData["GradeId"] = new SelectList(_context.Grades, "Id", "Id", employee.GradeId);
            ViewData["JobGroupId"] = new SelectList(_context.JobGroups, "Id", "Id", employee.JobGroupId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Id", employee.MaritalStatusId);
            ViewData["QualificationId"] = new SelectList(_context.Qualifications, "Id", "Id", employee.QualificationId);
            ViewData["QualificationLevelId"] = new SelectList(_context.QualificationLevels, "Id", "Id", employee.QualificationLevelId);
            ViewData["QualitativeGroupId"] = new SelectList(_context.QualitativeGroups, "Id", "Id", employee.QualitativeGroupId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Id", employee.UniversityId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.College)
                .Include(e => e.Governorate)
                .Include(e => e.Grade)
                .Include(e => e.JobGroup)
                .Include(e => e.MaritalStatus)
                .Include(e => e.Qualification)
                .Include(e => e.QualificationLevel)
                .Include(e => e.QualitativeGroup)
                .Include(e => e.University)
                .FirstOrDefaultAsync(m => m.NationalId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.NationalId == id);
        }
    }
}
