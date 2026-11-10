namespace MSCElectrics;

public enum TerminalType { Dad, Mom, None }
public enum Polarity { Positive, Negative, None }

public class Terminal
{
    private readonly List<Wire> wires = new List<Wire>();

    public HashSet<Terminal> Partners { get; } = new HashSet<Terminal>();
    public Polarity PolarityOfWire { get; }
    public TerminalType TerminalTypeOfT { get; }

    public Terminal(Polarity polarity, TerminalType terminalType)
    {
        PolarityOfWire = polarity;
        TerminalTypeOfT = terminalType;
    }

    public void Attach(Wire wire)
    {
        ArgumentNullException.ThrowIfNull(wire);

        if (!wires.Contains(wire))
            wires.Add(wire);
    }

    public void Detach(Wire wire)
    {
        wires.Remove(wire);
    }

    public IList<Wire> Wire => wires;

    public void Connect(Terminal terminal)
    {
        ArgumentNullException.ThrowIfNull(terminal);

        if (TerminalTypeOfT != terminal.TerminalTypeOfT && Partners.Add(terminal))
            terminal.Partners.Add(this);
    }

    public void Disconnect(Terminal terminal)
    {
        ArgumentNullException.ThrowIfNull(terminal);

        Partners.Remove(terminal);
        terminal.Partners.Remove(this);
    }
}
