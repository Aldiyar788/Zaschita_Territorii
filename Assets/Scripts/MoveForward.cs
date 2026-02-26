using UnityEngine;

public class M : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
