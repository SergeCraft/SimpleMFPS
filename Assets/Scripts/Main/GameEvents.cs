
using UnityEngine;

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
    public MonoBehaviour Enemy { get; private set; }

    public EnemyDeadSignal(MonoBehaviour enemy)
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