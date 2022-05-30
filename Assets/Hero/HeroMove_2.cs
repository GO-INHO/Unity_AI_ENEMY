using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove_2 : MonoBehaviour
{
    public static int HeroHp = 100;
    public static int EnemyHp = 100;
    public static Vector3 HeroPos;
    public GameObject Prefab_bullet;
    float DirR = 0;
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
            gameObject.transform.position += Dir * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.position -= Dir * speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            DirR -= 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            DirR += 0.5f;
        }

        gameObject.transform.rotation = Quaternion.Euler(0, DirR, 0);
        HeroPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = GameObject.Instantiate(Prefab_bullet) 
                as GameObject;
            bullet.GetComponent<BulletMove_2>().Dir = Dir;
            bullet.transform.parent = null;
            bullet.gameObject.layer = LayerMask.NameToLayer("Hero");
            bullet.transform.position = transform.position;
        }
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
