
using System.Drawing;
namespace MSCElectrics;
public class Wire
{
    const float MaxWear = 1f;
    const float MinWear = 0f;
    const float RCopper = 0.00175f; //удельное сопротивление материала
    Terminal aJoint, bJoint; //точка входе и точkа выхода провода
    public float Length{get;} //длина в метрах(м)
    float d{get;}//диаметр
    float Wear {get;} //коофициент износа провода
    public Wire(Terminal a, Terminal b, float length, float d)
    {
        Length = length;
        this.d = d;
        aJoint = a; bJoint = b;
        Wear=1f;
    }
    float R //сопротивление всего провода
    {
        get{
            float A =(MathF.PI * (d*d)) / 4; //площадь поперечного сечения
            return RCopper *(Length / A) * Wear;
    }
    }
    bool IsWhole
    {
        get{
            if(Wear > 0) return true;
            else return false;
        }
    }
    
    
}