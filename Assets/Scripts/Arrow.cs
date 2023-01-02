using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    [SerializeField] float despawn = 10;

    Rigidbody rb;
    float rotacion;
    bool flechaDisparada;

    #region Metodos MonoBehaviour
    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       Destroy(gameObject, despawn);
    }

    private void Update()
    {
        SeguirArco();

        if (rb.velocity.y < 0)
        {
            StartCoroutine(Torque(rotacion));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("piso"))
        {
            //Stop Moving/Translating
            rb.velocity = Vector3.zero;

            //Stop rotating
            rb.angularVelocity = Vector3.zero;

            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    #endregion

    private void SeguirArco()
    {
        if (!flechaDisparada)
        {
            transform.position = transform.parent.position;
        }
    }

    public void Movimiento(float fuerza, float rotacion, Transform transformadaPadre)
    {
        this.rotacion = rotacion;
        flechaDisparada = true;
        rb.isKinematic = false;
        rb.AddForce(transform.parent.forward * fuerza, ForceMode.Impulse);
        transform.SetParent(null);
    }

    IEnumerator Torque(float rotacion)
    {
        rb.AddTorque(transform.right * rotacion, ForceMode.Impulse);
        yield return null;
    }
}
