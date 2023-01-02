using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("piso"))
        {
            rb.isKinematic = true;
        }
    }

    public void Movimiento(float fuerza, float rotacion, Transform transformadaPadre)
    {
        rb.AddForce(transformadaPadre.forward * fuerza, ForceMode.Impulse);
        rb.AddTorque(transform.right * rotacion, ForceMode.Force);
    }

}
