
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


public class GameRestartSignal
{
    
}

public class EnemyDeadSignal
{
    public IEnemy Enemy { get; private set; }

    public EnemyDeadSignal(IEnemy enemy)
    {
        Enemy = enemy;
    }
}

public class TrophyPickedSignal
{
    public int TrophyID { get; private set; }

    public TrophyPickedSignal(int trophyID)
    {
        TrophyID = trophyID;
    }
}