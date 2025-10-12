using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje: MonoBehaviour
{
    public CharacterController Controlador;
    public float Velocidad = 15f;
    public float Gravedad = -9.81f;
    public Transform Piso;
    public float DistanciaPiso = 0.5f;
    public LayerMask CapaPiso;
    public float AlturaSalto = 2f;


    Vector3 VelocidadVertical;
    bool EstaEnPiso;
    void Start()
    {

    }

    void Update()
    {
        EstaEnPiso = Physics.CheckSphere(Piso.position, DistanciaPiso, CapaPiso);

        if (EstaEnPiso && VelocidadVertical.y < 0)
        {
            VelocidadVertical.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;
        Controlador.Move(mover * Velocidad * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && EstaEnPiso)
        {
            VelocidadVertical.y = Mathf.Sqrt(AlturaSalto * -2f * Gravedad);
            Debug.Log("Saltando! Velocidad Y: " + VelocidadVertical.y);
        }

        VelocidadVertical.y += Gravedad * Time.deltaTime;
        Controlador.Move(VelocidadVertical * Time.deltaTime);
    }
}
