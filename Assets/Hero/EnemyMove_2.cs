using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_2 : MonoBehaviour
{
    public GameObject Prefab_enemy;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.05f;
    int nTime = 0;
    private GameObject[] myTarget;
    Vector3 pos;
    private bool touch = false;
    public bool Patrol()
    {
        myTarget = GameObject.FindGameObjectsWithTag("Human");
        //Debug.Log("ddd : " + myTarget.Length);
        
        if(myTarget.Length > 0)
        {
            for(int i = 0; i < myTarget.Length; i++)
            {
                if (Vector3.Distance(myTarget[i].transform.position, transform.position) > 8.0f)
                {
                    if (Vector3.Distance(pos, transform.position) < 1.0f)
                    {
                        random_spot();
                    }
                    Dir = pos - gameObject.transform.position;
                    Dir.Normalize();
                    Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                    DirR = Rot.eulerAngles.y;
                    gameObject.transform.localRotation = Rot;
                    gameObject.transform.position += Dir * speed;

                    transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);

                    return true;
                }
            }
            
        }
        return false;
    }
    void random_spot()
    {
        pos = new Vector3(Random.Range(-22, 22), 0, Random.Range(-22, 22));
    }
    public bool MoveFollowTarget()
    {
        myTarget = GameObject.FindGameObjectsWithTag("Human");
        if (myTarget.Length > 0)
        {
            for(int i = 0; i < myTarget.Length; i++)
            {
                if (Vector3.Distance(myTarget[i].transform.position, transform.position) <= 8.0f)
                {
                    Dir = myTarget[i].transform.position - gameObject.transform.position;
                    Dir.Normalize();
                    Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                    DirR = Rot.eulerAngles.y;
                    gameObject.transform.localRotation = Rot;
                    gameObject.transform.position += Dir * speed;
                    //Debug.Log("ddd : " + Dir);
                    return true;
                }
            }    
            
        }
        
        return false;
    }
    void OnTriggerEnter(Collider col)
    {
        myTarget = GameObject.FindGameObjectsWithTag("Human");
        if (col.tag == "Human")
        {
            Vector3 human_location = col.gameObject.transform.position;
            Destroy(col.gameObject, 0.0f);
            GameObject enemy = GameObject.Instantiate(Prefab_enemy) as GameObject;
            //bullet.GetComponent<BulletMove>().Dir = Dir;
            enemy.transform.parent = null;
            enemy.tag = "Zombie";
            //bullet.gameObject.layer = LayerMask.NameToLayer("Enemy");
            enemy.transform.position = human_location;
            
            //myTarget[0].transform.gameObject.tag = "Zombie";
            touch = true;
            Debug.Log("touch");
            nTime = 1;
        }
    }
    public bool Berserk()
    {
        if(touch && nTime % 150 != 0)
        {
            myTarget = GameObject.FindGameObjectsWithTag("Human");
            Debug.Log("asd " + myTarget.Length);
            if (myTarget.Length > 0)
            {
                for (int i = 0; i < myTarget.Length; i++)
                {
                    if (Vector3.Distance(myTarget[i].transform.position, transform.position) > 8.0f)
                    {
                        if (Vector3.Distance(pos, transform.position) < 1.0f)
                        {
                            random_spot();
                        }
                        Dir = pos - gameObject.transform.position;
                        Dir.Normalize();
                        Quaternion Rot = Quaternion.LookRotation(Dir, new Vector3(0, 1, 0));
                        DirR = Rot.eulerAngles.y;
                        gameObject.transform.localRotation = Rot;
                        gameObject.transform.position += Dir * 0.5f;

                        transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);

                        return true;
                    }
                }

            }
        }
        touch = false;
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(Random.Range(-22, 22), 0, Random.Range(-22, 22));
        nTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        nTime++;
    }
    public bool IsDead()
    {
        if (HeroMove_2.EnemyHp <= 0)
        {
            return false;
        }
        return true;
    }

    public bool AddBullet()
    {
        if (HeroMove_2.EnemyHp > 0)
        {
            if (nTime % 100 == 0)
            {
                //GameObject bullet = GameObject.Instantiate(Prefab_bullet) as GameObject;
                //bullet.GetComponent<BulletMove>().Dir = Dir;
                //bullet.transform.parent = null;
                //bullet.gameObject.layer = LayerMask.NameToLayer("Enemy");
                //bullet.transform.position = transform.position;
            }
            return true;
        }
        return false;
    }
}
