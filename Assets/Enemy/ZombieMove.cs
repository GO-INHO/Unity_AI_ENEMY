using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class ZombieMove : MonoBehaviour
{
    public enum ZombieState{
        Idle,
        Berserk,
        Patrol,
        Tracking
    }
    public GameObject Prefab_Zombie;
    public GameObject[] PatrolPoint;
    public float UpdateTime;
    public float fTime;
    private ZombieSIght ZombieFOV;
    public List<GameObject> visibleTargets = new List<GameObject>();
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    //public GameObject Prefab_bullet;
    //float DirR = 180.0f;
    Vector3 Dir;
    float speed = 0.02f;
    public ZombieState eZombieState;
    int nTime = 0;

    public float shortDis;
    public GameObject targeting;
    private AudioSource audio;
    public AudioClip footSound;

    public bool ZombieIdle()
    {
        if (eZombieState == ZombieState.Idle)
        {
            return true;
        }
        return false;
    }

    public bool ZombieBerserk()
    {
        if (eZombieState == ZombieState.Berserk)
        {
            agent.speed = 5.0f;
            return true;
        }
        return false;
    }

    public bool ZombieTracking()
    {
        if (eZombieState == ZombieState.Tracking)
        {
            //Tracking();
            if (target != null)
            {
                if (Vector3.Distance(destination, target.position) > 1.0f)
                {
                    this.destination = target.position;
                    this.agent.destination = destination;
                }
                /* else if (Vector3.Distance(destination, target.position) < 1.0f)
                {
                    Debug.Log("AI 좀비가 사람을 잡음");
                    Vector3 human_location = target.position;
                    Destroy(target);

                    GameObject enemy = GameObject.Instantiate(Prefab_Zombie) as GameObject;
                    enemy.transform.parent = null;
                    enemy.tag = "Zombie";
                    enemy.transform.position = human_location;
                } */
            }
            else if (target == null)
            {
                int nRand = Random.Range(0, 9);
                target = PatrolPoint[nRand].transform;
                eZombieState = ZombieState.Patrol;
            }

            return true;
        }
        return false;
    }
    public bool ZombiePatrol()
    {
        if (eZombieState == ZombieState.Patrol)
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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        eZombieState = ZombieState.Patrol;
        nTime = 0;
        shortDis = 1000.0f;
        UpdateTime = 10.0f;
        ZombieFOV = GetComponent<ZombieSIght>();
        PatrolPoint = new GameObject[10];
        SetPoint();
        int nRand = Random.Range(0,9);
        target = PatrolPoint[nRand].transform;

        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.footSound;
        this.audio.loop = false;

        audio.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        /* if(ZombieFOV.isViewPlayer())
        {
            Debug.Log("사람 발견");
            eZombieState = ZombieState.Tracking;
        }
        else
            //eZombieState = ZombieState.Patrol;
        if(ZombieFOV.isTracePlayer())
        {
            Debug.Log("사람 발견");
            eZombieState = ZombieState.Tracking;
        } */
    }
    public bool IsDead()
    {
        return true;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Human"))
        {
            Debug.Log("사람 발견");
            /* eZombieState = ZombieState.Tracking;
            target = col.transform.gameObject */
            visibleTargets.Add(col.transform.gameObject);
        }
    }

    /*   void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Human"))
        {
            Debug.Log("사람 발견");
             eZombieState = ZombieState.Tracking;
            target = col.transform.gameObject 
            visibleTargets.Add(col.transform.gameObject);
        }
    }  */
 
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
                    eZombieState = ZombieState.Patrol;
                    int nRand = Random.Range(0,9);
                    target = PatrolPoint[nRand].transform;
                    break;
                }
                float distance = Vector3.Distance(transform.position, found.transform.position);
                if (distance < shortDis)
                {
                    targeting = found;
                    shortDis = distance;
                }
            }
            if(targeting != null)
            {
                Debug.Log(targeting.name); //가장 가까운 거리의 게임오브젝트찾음
                target = targeting.transform;
                eZombieState = ZombieState.Tracking;
            }
            if(targeting == null)
            {
                visibleTargets.Clear();
                eZombieState = ZombieState.Patrol;
                int nRand = Random.Range(0,9);
                target = PatrolPoint[nRand].transform;
            }
        }
 
    }
    void SetPoint()
    {
        PatrolPoint[0] = GameObject.Find("ZombiePatrolPoint1");
        PatrolPoint[1] = GameObject.Find("ZombiePatrolPoint2");
        PatrolPoint[2] = GameObject.Find("ZombiePatrolPoint3");
        PatrolPoint[3] = GameObject.Find("ZombiePatrolPoint4");
        PatrolPoint[4] = GameObject.Find("ZombiePatrolPoint5");
        PatrolPoint[5] = GameObject.Find("ZombiePatrolPoint6");
        PatrolPoint[6] = GameObject.Find("ZombiePatrolPoint7");
        PatrolPoint[7] = GameObject.Find("ZombiePatrolPoint8");
        PatrolPoint[8] = GameObject.Find("ZombiePatrolPoint9");
        PatrolPoint[9] = GameObject.Find("ZombiePatrolPoint10");
 
    }
}
