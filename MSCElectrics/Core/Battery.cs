

namespace MSCElectrics
{
    public enum Polarity{Positive, Negative, None}
    public class Battery
    {
   private readonly List<BatteryCell> cells = new List<BatteryCell>();
   private readonly float iternalResistance; //сопротивление аккумулятора 0.003 Ом
   private List<IConsumers> consumers = new List<IConsumers>();
   
   public Battery(int cellCount = 6, float waterVolume = 0.455f,float acidVolume = 0.245f, float iternalResistance = 0.003f)
   {
       this.iternalResistance = iternalResistance;
       for(int i = 0; i < cellCount; i++)
       {
           cells.Add(new BatteryCell(waterVolume, acidVolume));
       }
   }
   
   public IList<BatteryCell> Cells { get { return cells; } }
   
   public float Voltage
   {
       get
       {
           float total = 0;
           for(int i = 0; i< cells.Count(); i++)
           {
               total += cells[i].Voltage;
           }
           return total;
       }
   }
   
   
    }
}