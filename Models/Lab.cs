namespace LabManagerMvc.Models;

public class Lab 
{
    public int Id { get; set; } 
    public int _Number { get; set; } 
    public string _Name { get; set; }
    public string _Block { get; set; }


    public Lab(int id, int _number, string _name, string _block)
    {
        Id = id;
        _Number = _number;
        _Name = _name;
        _Block = _block;
    }

    public Lab(){ }
}