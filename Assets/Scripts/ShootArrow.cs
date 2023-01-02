using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] GameObject flechaPrefab;
    [Space(5)]
    [SerializeField] float fuerzaMinima = 5;
    [SerializeField] float torque = 0.09f;

    GameObject flecha;
    float fuerza;

    Vector3 posicion;
    Quaternion rotacion;

    private void Update()
    {
        ControlesDisparoFlecha();
    }

    private void ControlesDisparoFlecha()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fuerza = fuerzaMinima;
            posicion = transform.position;
            rotacion = transform.GetChild(0).transform.rotation;
            flecha = Instantiate(flechaPrefab, posicion, rotacion, transform.GetChild(0).transform);
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log(fuerza);
            fuerza += 0.1f;
            //Fuerza Maxima
        }

        if (Input.GetMouseButtonUp(0))
        {
            flecha.GetComponent<Arrow>().Movimiento(fuerza, torque, transform);
            fuerza = fuerzaMinima;
        }
    }
}
