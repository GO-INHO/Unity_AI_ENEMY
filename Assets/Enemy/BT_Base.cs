using UnityEngine;
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




public class HumanIdle : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanIdle();
        
    }
}


public class HumanRest : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanRest();
        
    }
}

public class HumanHide : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanHide();
        
    }
}

public class HumanRunning : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanRunning();
        
    }
}

public class HumanPatrol : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanPatrol();
        
    }
}

public class HumanInfected : Node
{
    public HumanMove Human
    {
        set { _Human = value; }
    }
    private HumanMove _Human;
    public override bool Invoke()
    {
        return _Human.HumanInfected();
        
    }
}
// ----------------------------------------- 이하 좀비 ---------
public class ZombiePatrol : Node
{
    public ZombieMove Zombie
    {
        set { _Zombie = value; }
    }
    private ZombieMove _Zombie;
    public override bool Invoke()
    {
        return _Zombie.ZombiePatrol();

    }
}
public class ZombieTracking : Node
{
    public ZombieMove Zombie
    {
        set { _Zombie = value; }
    }
    private ZombieMove _Zombie;
    public override bool Invoke()
    {
        return _Zombie.ZombieTracking();

    }
}

public class ZombieIdle : Node
{
    public ZombieMove Zombie
    {
        set { _Zombie = value; }
    }
    private ZombieMove _Zombie;
    public override bool Invoke()
    {
        return _Zombie.ZombieIdle();

    }
}

public class ZombieBerserk : Node
{
    public ZombieMove Zombie
    {
        set { _Zombie = value; }
    }
    private ZombieMove _Zombie;
    public override bool Invoke()
    {
        return _Zombie.ZombieBerserk();

    }
}

public class IsDead : Node
{
    public ZombieMove Zombie
    {
        set { _Zombie = value; }
    }
    private ZombieMove _Zombie;
    public override bool Invoke()
    {
        return _Zombie.IsDead();
    }
}