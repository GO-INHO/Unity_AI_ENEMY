using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BK_CameraManager : MonoBehaviour
{
public Camera[] arrCam; //카메라 요소들을 추가한다.
    public string tmp;
    public int nCamCount;
    
    public GameObject mouseposition;
    public int nNowCam;
    // Start is called before the first frame update
    void Start()
    {
        nNowCam = 0;
        nCamCount = 2;
        arrCam[0].enabled = true;
        arrCam[1].enabled = false;
        tmp = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("F") && (tmp=="" || tmp=="F"))
        {
            if (tmp == "")
                tmp = "F";
            else
                tmp = "";
            ++nNowCam;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            if (nNowCam >= nCamCount)
            {
                nNowCam = 0;
                mouseposition.gameObject.transform.position= new Vector3(0, -100, 0);
            }

            for (int i = 0; i < arrCam.Length; ++i)
            {
                arrCam[i].enabled = (i == nNowCam);
            }
        }

        if (Input.GetButtonUp("G") && (tmp == "" || tmp == "G"))
        {
            if (tmp == "")
                tmp = "G";
            else
                tmp = "";
            ++nNowCam;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            if (nNowCam >= nCamCount)
            {
                nNowCam = 0;
            }

            for (int i = 0; i < arrCam.Length; ++i)
            {
                arrCam[i].enabled = (i == nNowCam);
            }
        }
        if (Input.GetButtonUp("V") && (tmp == "" || tmp == "V"))
        {
            if (tmp == "")
                tmp = "V";
            else
                tmp = "";
            ++nNowCam;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;

            if (nNowCam >= nCamCount)
            {
                nNowCam = 0;
            }

            for (int i = 0; i < arrCam.Length; ++i)
            {
                arrCam[i].enabled = (i == nNowCam);
            }
        }

        if (Input.GetButtonUp("B") && (tmp == "" || tmp == "B"))
        {
            if (tmp == "")
                tmp = "B";
            else
                tmp = "";
            ++nNowCam;
            // Mouse Lock

            if (nNowCam >= nCamCount)
            {
                nNowCam = 0;
            }

            for (int i = 0; i < arrCam.Length; ++i)
            {
                arrCam[i].enabled = (i == nNowCam);
            }
        }
    }
}
