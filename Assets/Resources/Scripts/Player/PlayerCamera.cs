using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    #region 나중에 이넘으로 뺄것들
    [SerializeField]
    private Vector3 playerCameraOffset = new Vector3(0, 8, -6);
    private float followSpeed = 5f;
    #endregion

    void Awake()
    {
        target = GameObject.FindWithTag("Player");
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.transform.position + playerCameraOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
