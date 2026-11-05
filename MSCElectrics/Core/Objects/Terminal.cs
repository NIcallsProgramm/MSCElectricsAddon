

namespace MSCElectrics;
public enum TerminalType{Dad, Mom, None}
public enum Polarity{Positive, Negative, None}
public class Terminal
{
    private readonly List<Wire> wires = new List<Wire>();
    public HashSet<Terminal> Partners = new HashSet<Terminal>();
    public Polarity PolarityOfWire {get;}
    public TerminalType TerminalTypeOfT {get;}
  //public TerminalGroup ThisGroup {get;}
    public Terminal(Polarity polarity, TerminalType terminalType)
    {
        PolarityOfWire = polarity; TerminalTypeOfT = terminalType;
    }
    public void Attach(Wire w)
    {wires.Add(w);}
    public void Detach(Wire w)
    {wires.Add(w);}
    public IList<Wire> Wire {get {return wires;}}
    public void Connect(Terminal terminal)
    {
        if(this.TerminalTypeOfT != terminal.TerminalTypeOfT && this.Partners.Add(terminal))
        {
            terminal.Partners.Add(this);
        }
    }
    public void Disconnect(Terminal terminal)
    {
        this.Partners.Remove(terminal);
        terminal.Partners.Remove(this);
    }
}