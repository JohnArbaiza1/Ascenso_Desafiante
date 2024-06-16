using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator animator;
    public float x, y;
    private bool rotado = false;
    private bool agachado = false;

    public Rigidbody rb;
    public float fuerzaSalto = 8.0f;
    public bool puedoSaltar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        puedoSaltar = false;
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S) && !rotado)
        {
            transform.Rotate(0, 180, 0);
            rotado = true;
        }

        // Volver a la rotación original al presionar "W"
        if (Input.GetKeyDown(KeyCode.W) && rotado)
        {
            transform.Rotate(0, -180, 0);
            rotado = false;
        }

        // Movimiento del personaje
        Vector3 movimiento = new Vector3(0, 0, y * Time.deltaTime * velocidadMovimiento);
        if (rotado)
        {
            // Si está rotado, invertir el movimiento en Z para ir hacia atrás
            movimiento = new Vector3(0, 0, -y * Time.deltaTime * velocidadMovimiento);
        }
        transform.Translate(movimiento);

        // Rotación del personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        


        // Actualizar animaciones
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);


        if(puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                animator.SetBool("Salto", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                if (!agachado)
                {
                    animator.SetBool("Agachado", true);
                    agachado = true;
                }
                else
                {
                    animator.SetBool("Agachado", false);
                    agachado = false;
                }
                    
            }
            if(rb.position.y == 0)
            {
                animator.SetBool("ApuntoDeCaer", true);
            }
            animator.SetBool("Suelo", true);
        }
        else
        {
            Cayendo();
        }
    }

    public void Cayendo() {
        animator.SetBool("Suelo", false);
        animator.SetBool("Salto", false);
    }
}