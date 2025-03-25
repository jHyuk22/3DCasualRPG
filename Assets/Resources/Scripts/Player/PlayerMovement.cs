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

    public Camera mainCamera; // ���� ī�޶�
    public NavMeshAgent agent; // �÷��̾��� �׺���̼� ������Ʈ
    public GameObject cursorPrefab = null;

    void MovePlayerToClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); // ���콺 ��ġ �� ���� �߻�
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) // �浹 ����
        {
            if (hit.collider.CompareTag("Ground")) // ���� Ŭ���ߴ��� Ȯ��
            {
                GameObject cursor = Instantiate(cursorPrefab);
                cursor.transform.Translate(hit.point);
                agent.SetDestination(hit.point); // �÷��̾� �̵�
            }
        }
    }

    Vector3 destPos;
    Vector3 dir;
    Quaternion lookTarget;

    bool move = false;

    private void Update()
    {
        // ���� ���콺 ��ư�� ������ ��
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            // ���� ī�޶� ���� ���콺 Ŭ���� ���� ray ������ ������
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ray�� ���� ��ü�� �ִ��� �˻�
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
            // �̵��� �������� Time.deltaTime * 2f �� �ӵ��� ������.
            transform.position += dir.normalized * Time.deltaTime * 2f;
            // ���� ���⿡�� ���������� �������� �ε巴�� ȸ��
            transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.25f);

            // ĳ������ ��ġ�� ��ǥ ��ġ�� �Ÿ��� 0.05f ���� ū ���ȸ� �̵�
            move = (transform.position - destPos).magnitude > 0.05f;
        }
    }
}
