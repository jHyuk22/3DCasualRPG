using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 5f;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(moveX, 0, moveZ) * playerMoveSpeed * Time.deltaTime;
        transform.Translate(moveVec, Space.World);
    }
}
