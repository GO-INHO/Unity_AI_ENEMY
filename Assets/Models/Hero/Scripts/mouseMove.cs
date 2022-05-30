using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class mouseMove : MonoBehaviour
{
    public string input;
    IH_HeroMngCam CM;
    string tmp;
    bool Check;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Check = false;
        transform.Translate(0, -30, 0);
        CM = GameObject.Find("MainCamera").GetComponent<IH_HeroMngCam>();
        tmp = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonUp("F") && (CM.tmp == input || CM.tmp == ""))
        {
            if (Check == false)
            {
                Check = true;
                transform.position = new Vector3(0, 0.5f, 0);
            }
            else
            {
                Check = false;
                transform.position = new Vector3(0, 0.5f, 0);
            }
        }

        if (Check == true)
        {
            Cursor.visible = false;
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Make_Explosion());
            }
            transform.position += new Vector3(Input.GetAxis("Mouse X") * 1.0f, 0, Input.GetAxis("Mouse Y") * 1.0f);
        }
    }

    IEnumerator Make_Explosion()
    {
        GameObject tmp = Instantiate(obj, transform.localPosition, Quaternion.identity);
        yield return new WaitForSeconds(1.5f);
        Destroy(tmp);
    }
}
