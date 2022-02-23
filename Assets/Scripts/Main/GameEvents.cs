
using UnityEngine;
using Zenject;

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
    public MonoBehaviour Trophy { get; private set; }

    public TrophyPickedSignal(MonoBehaviour trophy)
    {
        Trophy = trophy;
    }
}

public class BulletDestroySignal
{
    public MonoBehaviour Bullet { get; private set; }
    
    public BulletDestroySignal(MonoBehaviour bulletController)
    {
        Bullet = bulletController;
    }
}

public class PlayerShootSignal
{
    
}