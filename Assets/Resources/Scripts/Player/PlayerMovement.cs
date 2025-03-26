using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera; // ���� ī�޶�
    public UnityEngine.AI.NavMeshAgent agent; // �÷��̾��� �׺���̼� ������Ʈ
    public Animator animator;

    private Vector3 destPos;
    private Vector3 dir;
    private Quaternion lookTarget;

    bool move = false;

    private void Update()
    {
        animator.SetBool("IsRunning", move);

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

