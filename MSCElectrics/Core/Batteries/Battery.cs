namespace MSCElectrics
{
    public class Battery
    {
        private readonly List<BatteryCell> cells = new List<BatteryCell>();
        private readonly float iternalResistance; // Сопротивление аккумулятора, Ом.
        private readonly List<IConsumers> consumers;

        public Terminal PositiveTerminal { get; }
        public Terminal NegativeTerminal { get; }

        public Battery(int cellCount = 6, float waterVolume = 0.455f, float acidVolume = 0.245f, float iternalResistance = 0.003f)
        {
            this.iternalResistance = iternalResistance;

            for (int i = 0; i < cellCount; i++)
                cells.Add(new BatteryCell(waterVolume, acidVolume));

            consumers = new List<IConsumers>();
            PositiveTerminal = new Terminal(Polarity.Positive, TerminalType.Dad);
            NegativeTerminal = new Terminal(Polarity.Negative, TerminalType.Dad);
        }

        public IList<BatteryCell> Cells => cells;

        public float Voltage // U = E - I * r
        {
            get
            {
                float e = 0f;
                float g = 0f;

                for (int i = 0; i < cells.Count; i++)
                    e += cells[i].Voltage;

                for (int i = 0; i < consumers.Count; i++)
                {
                    if (consumers[i].IsWorking)
                        g += consumers[i].G;
                }

                return e / (1f + iternalResistance * g);
            }
        }
    }
}
