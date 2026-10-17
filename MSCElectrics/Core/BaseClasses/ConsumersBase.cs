using System;

namespace MSCElectrics;

public abstract class ConsumersBase : IConsumers
{
    float Resistance{get;}
    float NVoltage{get;}
    protected ConsumersBase(float resistance, float nVoltage)
    {
        Resistance=resistance; NVoltage=nVoltage;
    }
    float I //сила тока проходящего через прибор
    {
        get{
            return NVoltage/Resistance;
        }
    }
    float G //проводимость в См(сименсах), ещк не уверен, буду использовать или нет
    {
        get{
            return 1/Resistance;
        }
    }
    float P //мощность в watt
    {
        get{
            return NVoltage*I;
        }
    }
    
}