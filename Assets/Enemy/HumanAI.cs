using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanAI : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqLive = new Sequence();
    private Sequence seqDead = new Sequence();

    private HumanIdle humanIdle = new HumanIdle();
    private HumanRest humanRest = new HumanRest();
    private HumanHide humanHide = new HumanHide();
    private HumanRunning humanRunning = new HumanRunning();
    private HumanPatrol humanPatrol = new HumanPatrol();
    private HumanInfected humanInfected = new HumanInfected();
    
    

    private HumanMove m_Human;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Human = gameObject.GetComponent<HumanMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqLive);

        humanIdle.Human = m_Human;
        humanRest.Human = m_Human;
        humanHide.Human = m_Human;
        humanRunning.Human = m_Human;
        humanPatrol.Human = m_Human;
        humanInfected.Human = m_Human;

        seqLive.AddChild(humanIdle);
        seqLive.AddChild(humanRest);
        seqLive.AddChild(humanPatrol);
        seqLive.AddChild(humanHide);
        seqLive.AddChild(humanRunning);

        seqLive.AddChild(humanInfected); 

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
