using UnityEngine;

public class Crystal : MonoBehaviour
{
    private float speed;
    private float lifetime;

    public void Init(float moveSpeed, float lifeTime)
    {
        speed = moveSpeed;
        lifetime = lifeTime;

        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CrystalManager.Instance.AddCrystal();
            Destroy(gameObject);
        }
    }
}