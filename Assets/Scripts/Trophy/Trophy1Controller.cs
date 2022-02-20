using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Trophy1Controller : MonoBehaviour
{
    public int ID;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateModel();
    }

    private void RotateModel()
    {
        transform.Rotate(Vector3.up, 1.0f);
    }
}
