using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] GameObject flechaPrefab;
    [Space(5)]
    [SerializeField] float fuerzaMinima = 5;
    [SerializeField] float rotacion = 0.3f;

    GameObject flecha;
    float fuerza;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("clicj");
            flecha = Instantiate(flechaPrefab, transform.position, transform.rotation);       
        }

        if (Input.GetMouseButtonDown(0))
        {
            fuerza += 0.1f;
        }

        if (Input.GetMouseButtonUp(0))
        {
            flecha.GetComponent<Arrow>().Movimiento(fuerza, rotacion, transform);
        }
    }
}
