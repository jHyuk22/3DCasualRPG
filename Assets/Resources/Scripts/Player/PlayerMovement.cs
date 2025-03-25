using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //public float playerMoveSpeed = 5f;

    //void Start()
    //{

    //}

    //private void FixedUpdate()
    //{
    //    MovePlayer();
    //}

    //private void MovePlayer()
    //{
    //    float moveX = Input.GetAxis("Horizontal");
    //    float moveZ = Input.GetAxis("Vertical");

    //    Vector3 moveVec = new Vector3(moveX, 0, moveZ) * playerMoveSpeed * Time.deltaTime;
    //    transform.Translate(moveVec, Space.World);
    //}

    public Camera mainCamera; // 메인 카메라
    public NavMeshAgent agent; // 플레이어의 네비게이션 에이전트
    public GameObject cursorPrefab = null;

    void MovePlayerToClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // 마우스 위치 → 레이 발사
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // 충돌 감지
        {
            if (hit.collider.CompareTag("Ground")) // 땅을 클릭했는지 확인
            {
                GameObject cursor = Instantiate(cursorPrefab);
                cursor.transform.Translate(hit.point);
                agent.SetDestination(hit.point); // 플레이어 이동
            }
        }
    }

    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;

    bool move = false;

    private void Update()
    {
        // 왼쪽 마우스 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // 메인 카메라를 통해 마우스 클릭한 곳의 ray 정보를 가져옴
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray와 닿은 물체가 있는지 검사
            if (Physics.Raycast(ray, out hit, 100f))
            {
                print(hit.transform.name);
                destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                GameObject cursor = Instantiate(cursorPrefab);
                cursor.transform.Translate(destPos);
                dir = destPos - transform.position;
                lookTarget = Quaternion.LookRotation(dir);
                move = true;
            }
        }

        Move();
    }

    void Move()
    {
        if (move)
        {
            // 이동할 방향으로 Time.deltaTime * 2f 의 속도로 움직임.
            transform.position += dir.normalized * Time.deltaTime * 2f;
            // 현재 방향에서 움직여야할 방향으로 부드럽게 회전
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            // 캐릭터의 위치와 목표 위치의 거리가 0.05f 보다 큰 동안만 이동
            move = (transform.position - destPos).magnitude > 0.05f;
        }
    }
}
