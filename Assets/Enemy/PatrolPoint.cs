using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    public float UpdateTime;
    public float fTime;
    public float PosX;
    public float PosZ;

    // Start is called before the first frame update
    void Start()
    {
        PosX = Random.Range(-150.0f, 150.0f);
        PosZ = Random.Range(-150.0f, 150.0f);
            
        transform.position = new Vector3(PosX, 0, PosZ);
        UpdateTime = 10.0f;
        fTime=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        fTime += Time.deltaTime;
        if(fTime >= UpdateTime)
        {
            PosX = Random.Range(-150.0f, 150.0f);
            PosZ = Random.Range(-150.0f, 150.0f);
            
            transform.position = new Vector3(PosX, 0, PosZ);
            fTime = 0.0f;
        }
    }
}
