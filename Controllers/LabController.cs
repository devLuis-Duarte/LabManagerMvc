using Microsoft.AspNetCore.Mvc;
using LabManagerMvc.Models;

namespace LabManagerMvc.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Labs);
    }

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }
    public IActionResult Edit(int id){
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }
    public IActionResult Update([FromForm] Lab lab){
        if (!ModelState.IsValid)
        {
            return View(lab);
        }

        Lab? labFound = _context.Labs.Find(lab.Id);

        if(labFound == null)
        {
            return NotFound();
        }
        
        labFound.Id = lab.Id;
        labFound._Name = lab._Name;
        labFound._Number = lab._Number;
        labFound._Block = lab._Block;

        _context.Labs.Update(labFound);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Save([FromForm] Lab lab)
    {
        _context.Labs.Add(lab);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }
         _context.Labs.Remove(lab);
        _context.SaveChanges();

        return View();
        
    }
}