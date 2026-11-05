

namespace MSCElectrics
{
    public class TerminalGroup
    {
        private int Count { get; }
        public TerminalType TerminalTypeOfTG { get; }
        public Terminal[] Terminals { get; }
        public HashSet<TerminalGroup> Partners{get;}
        public TerminalGroup(int count, TerminalType terminalType)
        {
            Count = count;
            TerminalTypeOfTG = terminalType;
            Terminals = new Terminal[count];
            Partners = new HashSet<TerminalGroup>();
        }
        public void Pinned(int pos, Terminal terminal)
        {
            if (TerminalTypeOfTG == terminal.TerminalTypeOfT)
                Terminals[pos] = terminal;
        }
        public void Connect(TerminalGroup TG)
        {
            if(this.TerminalTypeOfTG != TG.TerminalTypeOfTG && this.Partners.Add(TG))
            TG.Partners.Add(this);
        }
        public void Disconnect(TerminalGroup TG)
        {
            this.Partners.Remove(TG);
            TG.Partners.Remove(this);
        }
    }
}