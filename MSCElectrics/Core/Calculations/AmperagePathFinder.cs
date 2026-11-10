namespace MSCElectrics;

/// <summary>
/// Ищет путь по электрическим соединениям между двумя клеммами.
/// </summary>
public static class AmperagePathFinder
{
    /// <summary>
    /// Ищет путь от положительной клеммы аккумулятора до указанной клеммы потребителя.
    /// Возвращает последовательность клемм от начала до конца или null, если пути нет.
    /// </summary>
    public static IReadOnlyList<Terminal>? FindPath(Battery battery, Terminal target)
    {
        ArgumentNullException.ThrowIfNull(battery);
        return FindPath(battery.PositiveTerminal, target);
    }

    /// <summary>
    /// Ищет кратчайший по количеству соединений путь между двумя клеммами.
    /// Учитываются прямые соединения Terminal.Connect и целые провода.
    /// </summary>
    public static IReadOnlyList<Terminal>? FindPath(Terminal start, Terminal target)
    {
        ArgumentNullException.ThrowIfNull(start);
        ArgumentNullException.ThrowIfNull(target);

        var queue = new Queue<Terminal>();
        var previous = new Dictionary<Terminal, Terminal?>();

        queue.Enqueue(start);
        previous.Add(start, null);

        while (queue.Count > 0)
        {
            Terminal current = queue.Dequeue();

            if (current == target)
                return BuildPath(previous, target);

            // Прямые соединения между клеммами.
            foreach (Terminal partner in current.Partners)
            {
                if (previous.ContainsKey(partner))
                    continue;

                previous.Add(partner, current);
                queue.Enqueue(partner);
            }

            // Провода считаются рёбрами графа между двумя их клеммами.
            foreach (Wire wire in current.Wire)
            {
                if (!wire.IsWhole)
                    continue;

                Terminal? next = wire.GetOtherTerminal(current);
                if (next is null || previous.ContainsKey(next))
                    continue;

                previous.Add(next, current);
                queue.Enqueue(next);
            }
        }

        return null;
    }

    private static IReadOnlyList<Terminal> BuildPath(
        Dictionary<Terminal, Terminal?> previous,
        Terminal target)
    {
        var path = new List<Terminal>();

        Terminal? current = target;
        while (current is not null)
        {
            path.Add(current);
            current = previous[current];
        }

        path.Reverse();
        return path;
    }
}
