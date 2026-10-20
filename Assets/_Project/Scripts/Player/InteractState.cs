using UnityEngine;

public class InteractState : IState
{
    readonly Player _context;

    public InteractState(Player context)
    {
        _context = context;
    }

    public void Enter() { }

    public void Tick(float dt)
    {
        
    }
    
    public void Exit() { }
}
