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

    public virtual void TranslateState(CharacterState currentState, CharacterState nextState)
    {
        ExitState(currentState);
        EnterState(nextState);
    }

    public virtual void EnterState(CharacterState nextState)
    {

    }

    public virtual void ExitState(CharacterState currentState)
    {

    }
}
