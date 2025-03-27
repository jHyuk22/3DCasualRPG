using UnityEngine;

public class PlayerFSM : CharacterFSM
{
    private Animator animator;

    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public override void EnterState(CharacterState nextState)
    {
        base.EnterState(nextState);
    }

    public override void ExitState(CharacterState currentState)
    {
        base.ExitState(currentState);
    }
}
