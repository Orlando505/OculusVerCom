using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionDef : MonoBehaviour
{
    public string nameZone;
    public List<BoxCollider> ItemsList = new List<BoxCollider>();

    void Start() {
        nameZone = gameObject.name;  // Asigna el nombre en el Start()
    }

    void Update() {
        // Detectar si se presiona la tecla 'I'
        if (Input.GetKeyDown(KeyCode.I)) {
            AccionTeclaI();
        }
    }

    void AccionTeclaI() { // Función que se activa cuando se presiona la tecla 'I'
        ImprimirElementos();
    }

    IEnumerator DelayImpri() {        
        // Esperar 10 segundos
        yield return new WaitForSeconds(0.01f);
    }

    void ImprimirElementos(){
        for (int i = 0; i < ItemsList.Count; i++) {
            //Debug.Log("Elemento " + (i+1) + ": " + ItemsList[i].gameObject.name + " Proviene: " + nameZone + "\n");
            Debug.Log(ItemsList[i].gameObject.name + " - " + nameZone + "\n");
            StartCoroutine(DelayImpri());
        }
    }

    void OnTriggerEnter(Collider coll) {
        // Asegúrate de que el objeto tenga un BoxCollider y que el tag sea "item"
        BoxCollider boxCollider = coll as BoxCollider;
        if (boxCollider != null && coll.gameObject.tag == "item") {
            ItemsList.Add(boxCollider);
            Debug.Log("Tiene " + (ItemsList.Count + 1) + " items:");
        }   
    }

    void OnTriggerExit(Collider coll) {
        // Asegúrate de que el objeto tenga un BoxCollider y que el tag sea "item"
        BoxCollider boxCollider = coll as BoxCollider;
        if (boxCollider != null && coll.gameObject.tag == "item") {
            ItemsList.Remove(boxCollider);
            Debug.Log("Tiene " + (ItemsList.Count + 1)+ " items:");
            
        }
    }
}


/*public class DeteccionDef : MonoBehaviour
{
    public List<BoxCollider> ItemsList = new List<BoxCollider>();

    void OnTriggerEnter(Collider coll) {
        // Asegúrate de que el objeto tenga un BoxCollider y que el tag sea "item"
        BoxCollider boxCollider = coll as BoxCollider;
        if (boxCollider != null && coll.gameObject.tag == "item") {
            ItemsList.Add(boxCollider);
            Debug.Log("Tiene " + (ItemsList.Count + 1) + " items;");
            if (ItemsList.Count != null){
                // Imprimir el nombre de cada objeto en la lista
                for (int i = 0; i < ItemsList.Count; i++) {
                    Debug.Log("Elemento " + i + ": " + ItemsList[i].gameObject.name);
                }
            }
        }
    }

    void OnTriggerExit(Collider coll) {
        // Asegúrate de que el objeto tenga un BoxCollider y que el tag sea "item"
        BoxCollider boxCollider = coll as BoxCollider;
        if (boxCollider != null && coll.gameObject.tag == "item") {
            ItemsList.Remove(boxCollider);
            Debug.Log("Tiene " + (ItemsList.Count + 1) + " items;");
            Debug.Log(ItemsList.gameObject.name);
            if (ItemsList.Count != null){
                for (int i = 0; i < ItemsList.Count; i++) {
                    Debug.Log("Elemento " + i + ": " + ItemsList[i].gameObject.name);
                }
            }
        }
    }
}*/

/*public class DeteccionDef : MonoBehaviour
{
    public List<BoxCollider> ItemsList = new List<BoxCollider>();

    void OnTriggerEnter(BoxCollider coll){
        if(coll.gameObject.tag == "item"){
            ItemsList.Add (coll);
            Debug.Log("Tiene " + ItemsList.Count + " items");
        }
    }

    void OnTriggerExit(BoxCollider coll){
        if(coll.gameObject.tag == "item"){
            ItemsList.Remove (coll);
            Debug.Log("Tiene " + ItemsList.Count + " items");
        }
    }
}
*/