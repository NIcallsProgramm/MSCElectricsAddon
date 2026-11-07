using System;

namespace MSCElectrics;

public interface IConsumers
{
   public string Name{get;} //наименование потребителя
   public float Resistance{get;} //сопротивление потребителя(Ом)
   public float NVoltage {get;} //рабочее напряжение потребителя(Вольт)
   public float Wear{get;} //износ потребителя(0%-100%)
   public bool IsWorking {get;} //работает ли потребитель
   public float SVoltage{get;} //приходящее напряжение(Вольт)
   public float I{get;} //Сила тока проходящее черед потребитель(Ампер)
   public float G{get;} //проводимость (Сименс)
   public float P{get;} //мощность прибора (Ватт)
   
    
}