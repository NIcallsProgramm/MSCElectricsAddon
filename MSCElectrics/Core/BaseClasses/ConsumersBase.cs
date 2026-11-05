using System;

namespace MSCElectrics;

public abstract class ConsumersBase : IConsumers
{
    private const float MinResistance = 0.0001f;
    
    public string Name{get;}
    public float Resistance{get;}
    public float NVoltage{get;}
    protected ConsumersBase(string name, float resistance, float nVoltage, int countTerminals)
    {
        Name = name; Resistance = resistance; NVoltage = nVoltage;
    }
    public float SVoltage{get;}
    public float Wear
    {
        get{
            return 
        }
    }
    public float I //сила тока проходящего через потребитель
    {
        get{
            return SVoltage/Resistance;
        }
    }
    public float G //проводимость в См(сименсах), ещк не уверен, буду использовать или нет
    {
        get{
            return 1/Resistance;
        }
    }
    public float P //мощность в watt
    {
        get{
            return SVoltage*I;
        }
    }
    
}