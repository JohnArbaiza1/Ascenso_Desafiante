using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPuertaAutomatica : MonoBehaviour
{
    
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        animator.Play("AbrirPuertas");
    }

    private void OnTriggerExit(Collider other)
    {
        animator.Play("CerrarPuertas");
    }
}
