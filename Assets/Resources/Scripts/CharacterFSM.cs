using UnityEngine;

public class CharacterFSM : MonoBehaviour
{
    public enum CharacterState
    {
        IDLE,
        MOVE,
        ATTACK,
        TALK,
        BLOCK,
    }

    public CharacterState currentState;

    public virtual void TranslateState(CharacterState currentState, CharacterState nextState)
    {
        ExitState(currentState);
        EnterState(nextState);
        StateProcess(this.currentState);
    }

    public virtual void EnterState(CharacterState nextState)
    {

    }

    public virtual void StateProcess(CharacterState currentState)
    {

    }

    public virtual void ExitState(CharacterState currentState)
    {

    }
}
