using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class IH_HeroMngCam : MonoBehaviour
{
    public string tmp;
    float AngleX = 0;
    float AngleY = 0;
    // Start is called before the first frame update
    void Start()
    {
        AngleX = 0.0f;
        AngleY = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        HeroInputKey();
    }

    void CameraMove()
    {
        AngleX = (float)Input.mousePosition.x / (float)Screen.width;
        AngleY = (float)Input.mousePosition.y / (float)Screen.height;
        AngleX -= 0.5f;
        AngleY -= 0.5f;
        AngleX *= 180.0f;
        AngleY *= 180.0f;
    }

    void HeroInputKey()
    {


        Vector3 dir = new Vector3(Mathf.Sin(AngleX / 180.0f * 3.14f), Mathf.Sin(AngleY / 180.0f * 3.14f), Mathf.Cos(AngleX / 180.0f * 3.14f));
        gameObject.transform.LookAt(dir + gameObject.transform.position);


    }
}
