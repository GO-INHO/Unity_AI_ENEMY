using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 Dir;
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Dir * 0.5f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Enemy") 
            && gameObject.layer == LayerMask.NameToLayer("HeroBullet"))
        {
            HeroMove.EnemyHp -= 5;
            Destroy(gameObject, 0.0f);
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Hero") 
            && gameObject.layer == LayerMask.NameToLayer("EnemyBullet"))
        {
            HeroMove.HeroHp -= 5;
            Destroy(gameObject, 0.0f);
        }
    }

}
