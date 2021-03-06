using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy1Controller : MonoBehaviour
{
    private bool _isGrounded;
    private Vector3 _prevPosition;
    private Vector3 _actualSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 _speedLimit = new Vector3(1.0f, 3.0f, 1.0f);
    private float _movespeed = 0.5f;
    private SignalBus _signalBus;
    private bool _isAttacking = false;
    private float _lastAttakBeginTime = 0.0f;
    private float _attackTime = 1.0f;
    private int _attackDamage = 5;
    private Animator _animator;

    public int HP;

    [Inject]
    public void Construct(Vector3 initPosition, SignalBus signalBus)
    {
        transform.position = initPosition;
        _signalBus = signalBus;
        _animator = transform.GetComponent<Animator>();
        _animator.Play("Walk");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _isGrounded = false;
        _prevPosition = transform.position;
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpeed();
        ApplyGravity();
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {
        Transform player = GameObject.Find("Player").transform.GetChild(0);
        Vector3 targetDirection = new Vector3(
            player.position.x - transform.position.x,
            0.0f,
            player.position.z - transform.position.z
        );
            
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward,
            targetDirection,
            0.5f, 0.0f));
    
        if (Vector3.Distance(transform.position, player.position) > 2.0f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(player.position.x,transform.position.y, player.position.z),
                _movespeed*Time.deltaTime);
        };

        if (Vector3.Distance(transform.position, player.position) < 3.0f)
        {
            Attack();
        }
        else
        {
            InterruptAttack();
        }


    }

    private void InterruptAttack()
    {
        _isAttacking = false;
        _lastAttakBeginTime = 0.0f;
    }

    private void Attack()
    {
        if (_isAttacking)
        {
            if (Time.time - _lastAttakBeginTime > _attackTime)
            {
                _signalBus.Fire(new PlayerHitSignal(_attackDamage));
                InterruptAttack();
            }
                
        }
        else
        {
            _isAttacking = true;
            _lastAttakBeginTime = Time.time;
            _animator.Play("Attack");
        };
    }

    private void CalculateSpeed()
    {
        _actualSpeed = (transform.position - _prevPosition) / Time.deltaTime;
    }

    private void ApplyGravity()
    {
        if (!_isGrounded)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(transform.position.x, 0.0f,transform.position.z),
                3.0f*Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{name} hit {other.gameObject.name}");
        switch (other.gameObject.tag)
        {
            case "Level":
                _isGrounded = true;
                _actualSpeed.y = 0.0f;
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z);
                break;
            case "Bullet":
                TakeDamage(50);
                break;            
        }

        ;

    }

    private void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0) _signalBus.Fire(new EnemyDeadSignal(this));
    }


    public void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Level":
                _isGrounded = false;
                break;
        }
    }

    #region Factories

    public class Factory : PlaceholderFactory<Vector3, Enemy1Controller>
    {
        
    }

    #endregion
}
