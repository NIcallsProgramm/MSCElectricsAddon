

namespace MSCElectrics
{
    public class Battery
    {
   private readonly List<BatteryCell> cells = new List<BatteryCell>();
   private readonly float iternalResistance; //сопротивление аккумулятора 0.003 Ом
   private List<IConsumers> consumers;//подключенные потребители
   Terminal PositiveTerminal;
   Terminal NegativeTerminal;
   public Battery(int cellCount = 6, float waterVolume = 0.455f,float acidVolume = 0.245f, float iternalResistance = 0.003f)
   {
       this.iternalResistance = iternalResistance;
       for(int i = 0; i < cellCount; i++)
       {
           cells.Add(new BatteryCell(waterVolume, acidVolume));
       }
       consumers = new List<IConsumers>();
       PositiveTerminal = new Terminal(Polarity.Positive, TerminalType.Dad);
       NegativeTerminal = new Terminal(Polarity.Negative, TerminalType.Dad);
   }
   
   public IList<BatteryCell> Cells { get { return cells; } }
   
   public float Voltage // U=E-Ir
   {
       get
       {
           float E = 0;
           float G = 0;
           for(int i = 0; i < cells.Count; i++)
           {
               E += cells[i].Voltage;
           }
           for (int i = 0; i < consumers.Count; i++)
           {    if(consumers[i].IsWorking)
               G+= consumers[i].G;
           }
           float U = E / (1 + iternalResistance*G);
           return U;
       }
   }
   
}
}