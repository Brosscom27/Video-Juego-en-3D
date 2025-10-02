using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiradaCamara : MonoBehaviour
{
    public float Velocidad = 10.0f;
    float RotacionX = 0.0f;
    public Transform Jugador;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Si no está asignado en el inspector, intenta usar el padre de la cámara
        if (Jugador == null)
        {
            Jugador = transform.parent;
        }
    }

    void Update()
    {
        float MauseX = Input.GetAxis("Mouse X") * Velocidad * Time.deltaTime;
        float MauseY = Input.GetAxis("Mouse Y") * Velocidad * Time.deltaTime;

        RotacionX -= MauseY;
        RotacionX = Mathf.Clamp(RotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(RotacionX, 0, 0);

        if (Jugador != null) // seguridad extra
        {
            Jugador.Rotate(Vector3.up * MauseX);
        }
    }
}
