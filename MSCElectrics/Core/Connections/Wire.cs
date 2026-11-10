namespace MSCElectrics;

public class Wire
{
    private const float RCopper = 0.00175f; // Удельное сопротивление материала.

    private readonly Terminal aJoint;
    private readonly Terminal bJoint;

    public float Length { get; }
    private float d { get; }
    private float Wear { get; }

    public bool IsWhole => Wear > 0f;

    public Wire(Terminal a, Terminal b, float length, float d)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        if (length < 0f)
            throw new ArgumentOutOfRangeException(nameof(length));
        if (d <= 0f)
            throw new ArgumentOutOfRangeException(nameof(d));

        Length = length;
        this.d = d;
        aJoint = a;
        bJoint = b;
        Wear = 1f;

        // Регистрируем провод на обеих клеммах, чтобы обход графа
        // мог перейти с одной стороны провода на другую.
        a.Attach(this);
        b.Attach(this);
    }

    public Terminal? GetOtherTerminal(Terminal terminal)
    {
        if (terminal == aJoint)
            return bJoint;

        if (terminal == bJoint)
            return aJoint;

        return null;
    }

    public float Resistance
    {
        get
        {
            float area = MathF.PI * d * d / 4f;
            return RCopper * (Length / area) * Wear;
        }
    }
}
