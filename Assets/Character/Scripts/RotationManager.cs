using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase que maneja la rotacion de cualquier objeto
public class RotationManager
{
    // Metodo que rota el objeto en base a una direccion
    public void Rotate(ref Transform objectTransform, ref Rigidbody rb, ref Vector3 direction, float smoothTime, ref float currentVelocity)
    {
        // Calcular el angulo objetivo basado en la direccion
        float targetAngle = Mathf.SmoothDampAngle(
            objectTransform.eulerAngles.y, // Angulo actual en el eje Y
            Quaternion.LookRotation(direction).eulerAngles.y, // Angulo deseado basado en la direccion
            ref currentVelocity, // Velocidad de rotacion
            smoothTime // Tiempo de suavizado para la transicion
        );

        // Crear la rotacion objetivo
        Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

        // Si se pasa un Rigidbody, aplica la rotacion suavemente con MoveRotation
        if (rb != null)
        {
            rb.MoveRotation(targetRotation);
        }
        else
        {
            // Si no hay Rigidbody, aplica la rotacion directamente al Transform
            objectTransform.rotation = targetRotation;
        }
    }
}

