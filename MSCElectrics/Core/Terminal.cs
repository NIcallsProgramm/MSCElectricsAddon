using System;

namespace MSCElectrics;

public class Terminal
{
    private readonly List<Wire> wires = new List<Wire>();
    string Name;
    Polarity Polarity;
    public Terminal(string name, Polarity polarity)
    {
        Name = name; Polarity = polarity;
    }
    
}