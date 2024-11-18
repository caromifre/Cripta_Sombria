using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    private Enemy enemy; // Referencia al componente Enemy
    private TMP_Text healthText; // Referencia al componente TextMeshProUGUI
    private Camera mainCamera; // Referencia a la c�mara principal
    private Canvas canvas; // Referencia al Canvas
    private void Awake()
    {
        // Busca al Enemy en el objeto padre
        enemy = GetComponentInParent<Enemy>();

        // Busca el TextMeshProUGUI en el Canvas hijo
        healthText = GetComponentInChildren<TextMeshProUGUI>();

        // Obt�n la c�mara principal
        mainCamera = Camera.main;

        // Obt�n el Canvas del objeto actual
        canvas = GetComponent<Canvas>();

        // Asegura que el Canvas utilice la c�mara principal
        if (canvas.renderMode == RenderMode.WorldSpace && mainCamera != null)
        {
            canvas.worldCamera = mainCamera;
        }
    }

    private void Update()
    {
        // Verifica que el enemigo y el texto no sean nulos
        if (enemy != null && healthText != null)
        {
            // Actualiza el texto con la vida del enemigo
            healthText.text = $"{Mathf.Max(0, Mathf.FloorToInt(enemy.health))}";
        }

        // Orienta el Canvas hacia la c�mara principal
        if (mainCamera != null)
        {
            // Hace que el Canvas mire hacia la c�mara
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                             mainCamera.transform.rotation * Vector3.up);
        }
    }
}
