using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class HumanMove : MonoBehaviour
{
    public enum HumanState{
        Idle,
        Rest,
        Hide,
        Running,
        Patrol,
        Infected
    }
    public GameObject[] PatrolPoint;
    public GameObject[] HidePoint;
    public float UpdateTime;
    public float fTime;
    public GameObject Prefab_Zombie;
    public List<GameObject> visibleTargets = new List<GameObject>();

    public GameObject targeting;
    public GameObject Zombie;
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    //public GameObject Prefab_bullet;
    float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    public HumanState eHumanState;
    public float shortDis;
    int nTime = 0;
    float RestTime;

    public float PosX;
    public float PosZ;

    public float fx;
    public float fz;
    public float InfectedTime;

    public bool inSight;

    

    public bool HumanIdle()
    {
        if (eHumanState == HumanState.Idle)
        {
            return true;
        }
        return false;
    }

    public bool HumanRest()
    {
        if (eHumanState == HumanState.Rest)
        {
            
            return true;
        }
        return false;
    }
    public bool HumanHide()
    {
        if (eHumanState == HumanState.Hide)
        {
            if(Vector3.Distance(destination, target.position) > 1.0f )
            {
                this.destination = target.position;
                this.agent.destination = destination;
            }
            Tracking();
            return true;
        }
        
        return false;
    }
    public bool HumanRunning()
    {
        if (eHumanState == HumanState.Running)
        {
            if(Zombie != null)
            {
                Vector3 direction = (transform.position - Zombie.transform.position).normalized;
                transform.position += direction * 3.5f * Time.deltaTime;
            }
            fTime += Time.deltaTime;
            if (fTime >= UpdateTime-5.0f)
            {
                int nRand = Random.Range(0,9);
                target = HidePoint[nRand].transform;
                fTime = 0.0f;
                eHumanState = HumanState.Hide;
            }
            Tracking();
            return true;
        }
        return false;

    }
    public bool HumanPatrol()
    {
       if (eHumanState == HumanState.Patrol)
        {
            fTime += Time.deltaTime;
            if (fTime >= UpdateTime)
            {
                int nRand = Random.Range(0,9);
                target = PatrolPoint[nRand].transform;
                fTime = 0.0f;
            }
            if(Vector3.Distance(destination, target.position) > 1.0f )
            {
                this.destination = target.position;
                this.agent.destination = destination;
            } 
            Tracking();
            return true;
        }
        return false;

    }

    public bool HumanInfected()
    {
        if (eHumanState == HumanState.Infected)
        {
            //Debug.Log("AI 좀비가 사람을 잡음");
            /* InfectedTime += Time.deltaTime;
            if (InfectedTime >= 1.5f)
            { */
            Debug.Log(Zombie.name + " " + transform.position.x + " " + transform.position.z);
            Vector3 human_location = transform.position;
            //GameObject preZombie = GameObject.Instantiate(Prefab_Zombie) as GameObject;
            //preZombie.transform.parent = null;
            //preZombie.tag = "Zombie";
            
            //preZombie.transform.position = human_location;
            //Debug.Log(Zombie.name + " " + preZombie.transform.position.x + " " + preZombie.transform.position.z);
            //InfectedTime = 0.0f;


            GameObject preZombie = GameObject.Instantiate(Prefab_Zombie) as GameObject;
            preZombie.transform.parent = null;
            preZombie.tag = "Zombie";
            preZombie.transform.position = new Vector3(transform.position.x,0,transform.position.z);

            Destroy(this.gameObject);
            return true;
            //
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        InfectedTime = 0.0f;
        inSight = false;
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        eHumanState = HumanState.Patrol;
        nTime = 0;
        UpdateTime = 10.0f;
        PatrolPoint = new GameObject[10];
        HidePoint = new GameObject[10];
        SetPoint();
        int nRand = Random.Range(0,9);
        target = PatrolPoint[nRand].transform;
        RestTime = 10.0f;
        /* PosX = Random.Range(-150.0f, 150.0f);
        PosZ = Random.Range(-150.0f, 150.0f);
            
        transform.position = new Vector3(PosX, 0, PosZ); */
    }

    // Update is called once per frame
    void Update()
    {
        //nTime++;
        /* if(inSight == true)
            Zombie = GameObject.Find("FPSPlayer"); */
        if (Zombie != null)
        {
            //Debug.Log(Zombie.name + Vector3.Distance(this.transform.position, Zombie.transform.position));
            if (Vector3.Distance(this.transform.position, Zombie.transform.position) < 4.0f)
            {
                Debug.Log(Zombie.name + "에게 감염당함");
                if(eHumanState != HumanState.Infected)
                {
                    eHumanState = HumanState.Infected;
                    fx = Zombie.transform.position.x;
                    fz = Zombie.transform.position.z;
                    Debug.Log("x : " + fx + " z : " + fz);
                }
            }
        }
    }
    public bool IsDead()
    {
        return true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Zombie"))
        {
            //Debug.Log("좀비 발견");

            /* eHumanState = HumanState.Running;

            Zombie = col.transform.gameObject; */

            visibleTargets.Add(col.transform.gameObject);
        }
        /* if (col.CompareTag("PlayerZombie"))
        {
            inSight = true;
        } */
    }
     void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Zombie"))
        {
            //Debug.Log("좀비 발견");
            
            /* eHumanState = HumanState.Running; */
            
            //Zombie = col.transform.gameObject;
            visibleTargets.Add(col.transform.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        Zombie = null;
        visibleTargets.Clear();
    }
    void Tracking()
    {
        if (visibleTargets.Count != 0) //범위 안에 있는 게임오브젝트 리스트 존재 시, 거리 계산 시작
        {
            shortDis = 999.0f;
            //리스트에서 가장 가까운 거리의 게임 오브젝트 찾기
            foreach (GameObject found in visibleTargets)
            {
                if(found == null) 
                {
                    visibleTargets.Clear();
                    eHumanState = HumanState.Patrol;
                    int nRand = Random.Range(0,9);
                    target = PatrolPoint[nRand].transform;
                    break;
                }
                float distance = Vector3.Distance(transform.position, found.transform.position);
                if (distance < shortDis)
                {
                    Zombie = found;
                    shortDis = distance;
                }
            }
            //visibleTargets.Clear();
            if(Zombie != null)
            {
                Debug.Log(Zombie.name); 
                //Zombie = targeting;
                eHumanState = HumanState.Running;
            }
            if(Zombie == null)
            {
                visibleTargets.Clear();
                eHumanState = HumanState.Patrol;
                int nRand = Random.Range(0,9);
                target = PatrolPoint[nRand].transform;
            }
        }
 
    }
    void SetPoint()
    {
        PatrolPoint[0] = GameObject.Find("HumanPatrolPoint1");
        PatrolPoint[1] = GameObject.Find("HumanPatrolPoint2");
        PatrolPoint[2] = GameObject.Find("HumanPatrolPoint3");
        PatrolPoint[3] = GameObject.Find("HumanPatrolPoint4");
        PatrolPoint[4] = GameObject.Find("HumanPatrolPoint5");
        PatrolPoint[5] = GameObject.Find("HumanPatrolPoint6");
        PatrolPoint[6] = GameObject.Find("HumanPatrolPoint7");
        PatrolPoint[7] = GameObject.Find("HumanPatrolPoint8");
        PatrolPoint[8] = GameObject.Find("HumanPatrolPoint9");
        PatrolPoint[9] = GameObject.Find("HumanPatrolPoint10");

        HidePoint[0] = GameObject.Find("HumanHidePoint1");
        HidePoint[1] = GameObject.Find("HumanHidePoint2");
        HidePoint[2] = GameObject.Find("HumanHidePoint3");
        HidePoint[3] = GameObject.Find("HumanHidePoint4");
        HidePoint[4] = GameObject.Find("HumanHidePoint5");
        HidePoint[5] = GameObject.Find("HumanHidePoint6");
        HidePoint[6] = GameObject.Find("HumanHidePoint7");
        HidePoint[7] = GameObject.Find("HumanHidePoint8");
        HidePoint[8] = GameObject.Find("HumanHidePoint9");
        HidePoint[9] = GameObject.Find("HumanHidePoint10");
 
    }

}
