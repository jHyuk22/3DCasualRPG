using UnityEngine;

public class PlayerFSM : CharacterFSM
{
    private string PLAYER_MOVE = "IsRunning";
    private string PLAYER_IDLE = "Idle";
    private string PLAYER_ATTACK = "IsAttacking";

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
