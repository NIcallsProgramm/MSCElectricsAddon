using System;

namespace MSCElectrics;

class Program
{
    static void Main(string[] args)
    {
        
        var Battery1 = new Battery();
        Console.Write("    " + Battery1.Voltage);
        Battery1.Cells[2].IsShorted = false;
        Console.Write("    " + Battery1.Voltage);
        Console.WriteLine("   " + Battery1.GetTerminalVoltage(150f));
    }
}