
public class TestGameEvent {}

public class PlayerHitSignal
{
    public int Damage { get; private set; }

    public PlayerHitSignal(int damage)
    {
        Damage = damage;
    }
}

public class PlayerDeadSignal
{
    
}