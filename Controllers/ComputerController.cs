using Microsoft.AspNetCore.Mvc;
using LabManagerMvc.Models;

namespace LabManagerMvc.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Computers);
    }

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }
    public IActionResult Edit(int id){
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }
    public IActionResult Update([FromForm] Computer computer){
        if (!ModelState.IsValid)
        {
            return View(computer);
        }

    Computer? computerFound = _context.Computers.Find(computer.Id);

        if(computerFound == null)
        {
            return NotFound();
        }
        
        computerFound.Id = computer.Id;
        computerFound.Processor = computer.Processor;
        computerFound.Ram = computer.Ram;

        _context.Computers.Update(computerFound);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }
    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Save([FromForm] Computer computer)
    {
        if (!ModelState.IsValid)
        {
            return View(computer);

        }

        _context.Computers.Add(computer);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }
         _context.Computers.Remove(computer);
        _context.SaveChanges();

        return View();
        
    }
}