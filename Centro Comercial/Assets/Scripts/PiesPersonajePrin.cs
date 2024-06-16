using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesPersonajePrin : MonoBehaviour
{
    public movimiento move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        move.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        move.puedoSaltar=false;
    }
}
