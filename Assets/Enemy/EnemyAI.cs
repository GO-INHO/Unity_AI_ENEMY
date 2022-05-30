using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   /*  private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();

    private MoveFollowTarget moveForTarget = new MoveFollowTarget();
    private MoveBackFollowTarget moveBackForTarget = new MoveBackFollowTarget();
    private OnAttack m_OnAttack = new OnAttack();
    private IsDead m_IsDead = new IsDead();

    private EnemyMove m_Enemy;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Enemy = gameObject.GetComponent<EnemyMove>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveForTarget.Enemy = m_Enemy;
        moveBackForTarget.Enemy = m_Enemy;
        m_OnAttack.Enemy = m_Enemy;
        m_IsDead.Enemy = m_Enemy;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(m_OnAttack);
        seqMovingAttack.AddChild(moveBackForTarget);

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
        
    } */
}
