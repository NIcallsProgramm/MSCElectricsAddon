
namespace MSCElectrics
{
public class BatteryCell
{
    public const float VoltageOffset = 0.84f; // Имперический коэффициент
    public const float MinDensity = 1.10f; // Плотность полнстью севшей банки
    public const float MaxDensity = 1.28f; // плотность заряженной банки
    
    private float _density; // плотность электролита г/см³
    private float _distilledWaterVolume; // объем дистиллировпнной воды
    private float _sulfuricAcidVolume; // объем серной кислоты
    private float _electrolyteVolume; //объем электролита 0.6-0.7 литра
    private float _plateWear; // сульфатация пластин, от нуля до ста 0.0 - 1.0
    
    public BatteryCell(float distilledWaterVolume, float sulfuricAcidVolume)
    {
        _sulfuricAcidVolume = sulfuricAcidVolume; _distilledWaterVolume = distilledWaterVolume;
    }
    public float Density
    {
        get
        {
            float totalvolume = _distilledWaterVolume + _sulfuricAcidVolume;
            if(totalvolume<= 0) return 1.0f;
           return 1.0f + 0.8f * (_sulfuricAcidVolume/(_distilledWaterVolume+_sulfuricAcidVolume));
        }
    }
    public float ElectrolyteVolume
        {
            get 
            {
               return _sulfuricAcidVolume + _distilledWaterVolume;
            }
        }
        
    public bool IsShorted {get; set;} 
    public float Voltage
    {
        get 
        { 
            if(IsShorted || ElectrolyteVolume == 0) return 0.0f;
            return Density + VoltageOffset;
        }
    }
}
}