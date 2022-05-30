using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    public static int HeroHp = 100;
    public static int EnemyHp = 100;
    public static Vector3 HeroPos;
    public GameObject Prefab_bullet;
    float DirR = 0;

    public static bool isMoving = false;
    public static float HidingTime = 0.0f;
    public static bool isHiding = false; 

    // Start is called before the first frame update
    void Start()
    {
        HeroPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Dir = new Vector3(Mathf.Sin(DirR / 180.0f * 3.14f), 
            0, Mathf.Cos(DirR / 180.0f * 3.14f));
        float speed = 0.05f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            isMoving = true;
            gameObject.transform.position += Dir * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            isMoving = true;
            gameObject.transform.position -= Dir * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;
            DirR -= 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isMoving = true;
            DirR += 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) isMoving = false;
        if (Input.GetKeyUp(KeyCode.DownArrow)) isMoving = false;
        if (Input.GetKeyUp(KeyCode.LeftArrow)) isMoving = false;
        if (Input.GetKeyUp(KeyCode.RightArrow)) isMoving = false;

        if( isMoving == false) 
        {
            HidingTime += Time.deltaTime;
        }
        else 
            HidingTime = 0.0f;

        if( HidingTime >= 5.0f )
        {
            isHiding = true;
        }


        gameObject.transform.rotation = Quaternion.Euler(0, DirR, 0);
        HeroPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GameObject.Instantiate(Prefab_bullet) 
                as GameObject;
            bullet.GetComponent<BulletMove>().Dir = Dir;
            bullet.transform.parent = null;
            bullet.gameObject.layer = LayerMask.NameToLayer("HeroBullet");//수정된 부분
            bullet.transform.position = transform.position;
        }
    }

    void InputKey()
    {
        
    }
    void OnGUI()
    {
        GUIStyle style;
        Rect rect;
        int w = Screen.width, h = Screen.height;
        rect = new Rect(0, 0, w, h * 4 / 100);
        style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = Color.black;

        string text = "Hero HP: " + HeroHp + "% \nEnemy HP: " + EnemyHp + "%";
        GUI.Label(rect, text, style);
    }
}
