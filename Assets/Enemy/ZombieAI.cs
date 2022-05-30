using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqLive = new Sequence();
    private Sequence seqDead = new Sequence();

    private IsDead m_IsDead = new IsDead();
    private ZombieIdle zombieIdle = new ZombieIdle();
    private ZombieTracking zombieRunning = new ZombieTracking();
    private ZombiePatrol zombiePatrol = new ZombiePatrol();
    private ZombieBerserk zombieBerserk = new ZombieBerserk();
    
    

    private ZombieMove m_zombie;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_zombie = gameObject.GetComponent<ZombieMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqLive);

        zombieIdle.Zombie = m_zombie;
        zombieRunning.Zombie = m_zombie;
        zombiePatrol.Zombie = m_zombie;
        zombieBerserk.Zombie = m_zombie;
        m_IsDead.Zombie = m_zombie;

        seqLive.AddChild(zombieIdle);
        seqLive.AddChild(zombieRunning);
        seqLive.AddChild(zombiePatrol);
        seqLive.AddChild(zombieBerserk);

        seqDead.AddChild(m_IsDead); 

        behaviorProcess = BehaviorProcess();
        StartCoroutine(behaviorProcess);
    }
    public IEnumerator BehaviorProcess()
    {
        while (root.Invoke())
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject, 0.0f);
        Debug.Log("behavior process exit");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
