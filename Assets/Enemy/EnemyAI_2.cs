/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_2 : MonoBehaviour
{
    private Sequence root = new Sequence();
    private Selector selector = new Selector();
    private Sequence seqMovingAttack = new Sequence();
    private Sequence seqDead = new Sequence();
    private MoveFollowTarget moveForTarget = new MoveFollowTarget();
    private Berserk berserk = new Berserk();
    private Patrol patrol = new Patrol();
    private IsDead m_IsDead = new IsDead();

    private EnemyMove_2 m_Enemy;
    private IEnumerator behaviorProcess;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Tree");
        m_Enemy = gameObject.GetComponent<EnemyMove_2>();
        root.AddChild(selector);
        selector.AddChild(seqDead);
        selector.AddChild(seqMovingAttack);

        moveForTarget.Enemy = m_Enemy;
        berserk.Enemy = m_Enemy;
        patrol.Enemy = m_Enemy;
        m_IsDead.Enemy = m_Enemy;

        seqMovingAttack.AddChild(moveForTarget);
        seqMovingAttack.AddChild(berserk);
        seqMovingAttack.AddChild(patrol);
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
 */