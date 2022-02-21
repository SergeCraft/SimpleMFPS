using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    private bool _isGrounded;
    private Vector3 _prevPosition;
    private Vector3 _actualSpeed = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 _speedLimit = new Vector3(2.0f, 3.0f, 2.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        _isGrounded = false;
        _prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpeed();
        ApplyGravity();
    }

    private void CalculateSpeed()
    {
        _actualSpeed = (transform.position - _prevPosition) / Time.deltaTime;
    }

    private void ApplyGravity()
    {
        if (!_isGrounded)
        {
            _actualSpeed.y = Mathf.Abs(_actualSpeed.y) < _speedLimit.y? 
                _actualSpeed.y + Physics.gravity.y / 5 * Time.deltaTime 
                : Mathf.Sign(_actualSpeed.y) *_speedLimit.y;
            
            transform.Translate(_actualSpeed * Time.deltaTime, Space.World);
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
        }

        ;

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
}
