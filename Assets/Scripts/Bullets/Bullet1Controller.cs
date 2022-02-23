using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet1Controller : MonoBehaviour
{
    private SignalBus _signalBus;
    private Vector3 _direction;
    private float _speed = 6.0f;
    public Color Color;
    

    [Inject]
    public void Construct(InitSettings stg, SignalBus signalBus)
    {
        _signalBus = signalBus;
        _direction = stg.Direction;
        Color = stg.Color;
        
        transform.position = stg.InitPosition;
        transform.rotation = Quaternion.Euler(_direction);
        
        transform.GetComponent<MeshRenderer>().material.color = Color;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckOutOfLevel();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    private void CheckOutOfLevel()
    {
        if ((transform.position - Vector3.zero).magnitude > 30.0f)
        {
            if (_signalBus != null) _signalBus.Fire(new BulletDestroySignal(this));
        };
    }

    public class Factory : PlaceholderFactory<InitSettings, Bullet1Controller>
    {
        
    }

    public class InitSettings
    {
        public Color Color { get; private set; }
        public Vector3 Direction { get; private set; }
        
        public Vector3 InitPosition { get; private set; }

        public InitSettings(Color color, Vector3 direction, Vector3 initPosition)
        {
            Color = color;
            Direction = direction;
            InitPosition = initPosition;
        }
    }
}
