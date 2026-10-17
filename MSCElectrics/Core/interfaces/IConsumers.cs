using System;

namespace MSCElectrics;

public interface IConsumers
{
    string Name{get;} //наименование потребителя
    bool IsOn {get;} //включен ли потребитель
    bool IsWorking {get;} //работает ли потребитель
    float Resistance{get;} //сопротивление потребителя
    float NVoltage {get;} //рабочее напряжение потребителя
    float SVoltage{get;} //приходящее напряжение
    float G{get;} //проводимость
    void ApplyVoltage(float volts); //узнать приходящие напряжение с учетом всех включенных потребителей
}