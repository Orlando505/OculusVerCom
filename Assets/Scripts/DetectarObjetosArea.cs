using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectarObjetosArea : MonoBehaviour
{
    public BoxCollider countingZone; // El collider del cubo
    public TextMeshProUGUI uiText; // El texto donde se mostrará la información
    private List<GameObject> objectsInside = new List<GameObject>(); // Lista para guardar objetos dentro del cubo

    void Start() //Inicio
    {
        if (countingZone == null)
        {
            Debug.LogError("Por favor, asigna un BoxCollider en la escena.");
        }

        if (uiText == null)
        {
            Debug.LogError("Por favor, asigna un objeto TextMeshPro en la escena.");
        }
    }

    void Update() 
    {
        // Actualizamos el texto en cada frame
        UpdateUIText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Cuando un objeto entra al cubo, lo añadimos a la lista si es pickeable
        if (other.GetComponent<PickableObject>() != null && !objectsInside.Contains(other.gameObject))
        {
            objectsInside.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cuando un objeto sale del cubo, lo removemos de la lista
        if (objectsInside.Contains(other.gameObject))
        {
            objectsInside.Remove(other.gameObject);
        }
    }

    void UpdateUIText()
    {
        // Limpiamos el texto y contamos los objetos dentro del cubo
        uiText.text = "Objetos en el cubo: " + objectsInside.Count + "\n";

        foreach (GameObject obj in objectsInside)
        {
            // Agregamos el nombre de cada objeto al texto
            uiText.text += obj.name + "\n";
        }

        /*//Aqui se prueba si hay cambios en el text
        if (Input.GetButtonDown("Fire1")){
            uiText.text += 1;
        }*/
    }
}
