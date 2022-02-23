using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Trophy1Controller : MonoBehaviour
{
    public TrophyTypes Type;
    
    
    [Inject]
    public void Construct(InitSettings stg)
    {
        Type = (TrophyTypes) Random.Range(1, 4);
        transform.GetComponent<MeshRenderer>().material.color = Helper.TrophyTypeToColor(Type);
        transform.position = stg.InitPosition;
    }


    // Update is called once per frame
    void Update()
    {
        RotateModel();
    }

    private void RotateModel()
    {
        transform.Rotate(Vector3.back, 1.0f);
    }
    
    public class Factory : PlaceholderFactory<InitSettings, Trophy1Controller>
    {
        
    }

    public class InitSettings
    {
        public Vector3 InitPosition { get; private set;}

        public InitSettings(Vector3 initPosition)
        {
            InitPosition = initPosition;
        }
    } 
}
