using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale; //Se gualda la escala inicial
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = initialScale; //Se establece la escala incial en cada frame
    }
}
