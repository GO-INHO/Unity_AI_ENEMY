/* using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public abstract class Node
{
    public abstract bool Invoke();
}
public class CompositeNode : Node
{
    public override bool Invoke()
    {
        throw new NotImplementedException();
    }

    public void AddChild(Node node)
    {
        childrens.Push(node);
    }

    public Stack<Node> GetChildrens()
    {
        return childrens;
    }
    private Stack<Node> childrens = new Stack<Node>();
}

public class Selector : CompositeNode
{
    public override bool Invoke()
    {
        foreach (var node in GetChildrens())
        {
            if (node.Invoke())
            {

                return true;
            }
        }
        return false;
    }
}

public class Sequence : CompositeNode
{
    public override bool Invoke()
    {
        bool p = false;
        foreach (var node in GetChildrens())
        {
            if (node.Invoke() == false)
            {
                p = true;
            }
        }
        return !p;
    }
}

public class MoveFollowTarget : Node
{
    public EnemyMove_2 Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyMove_2 _Enemy;
    public override bool Invoke()
    {
        return _Enemy.MoveFollowTarget();

    }
}

public class Patrol : Node
{
    public EnemyMove_2 Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyMove_2 _Enemy;
    public override bool Invoke()
    {
        return _Enemy.Patrol();

    }
}

public class Berserk : Node
{
    public EnemyMove_2 Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyMove_2 _Enemy;
    public override bool Invoke()
    {
        return _Enemy.Berserk();

    }
}

public class IsDead : Node
{
    public EnemyMove_2 Enemy
    {
        set { _Enemy = value; }
    }
    private EnemyMove_2 _Enemy;
    public override bool Invoke()
    {
        return _Enemy.IsDead();
    }
}

 */