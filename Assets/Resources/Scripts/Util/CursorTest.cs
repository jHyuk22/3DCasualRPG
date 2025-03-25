using UnityEngine;

public class CursorTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float lifeTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= 0)
            Destroy(gameObject);
        else
            lifeTime -= Time.deltaTime;
    }
}
