using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    public float distancia = 3f;
    //public Texture2D puntero;
    public GameObject TextDetect;

    private GameObject ultimoReconocido = null;
    private Material materialOriginal = null;
    private bool selected = false;

    private void Start()
    {
        TextDetect.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distancia))
        {
            if (hit.collider.tag == "Door")
            {
                if (ultimoReconocido != hit.transform.gameObject)
                {
                    Deselect(); // Deselect the previous object if it's different
                    SelectedObject(hit.transform);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<SistemaPuertas>().ChangeDoorState();
                }
            }
            else
            {
                Deselect(); // Deselect if the hit object is not a door
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deselect(); // Deselect if nothing is hit
        }
    }

    void SelectedObject(Transform transform)
    {
        ultimoReconocido = transform.gameObject;

        // Guardar el material original solo si no ha sido guardado previamente
        MeshRenderer renderer = transform.GetComponent<MeshRenderer>();
        if (materialOriginal == null && renderer != null)
        {
            materialOriginal = renderer.material;
        }

        // Cambiar el material actual
        if (renderer != null)
        {
            Material newMaterial = new Material(renderer.material);
            newMaterial.color = Color.white;
            renderer.material = newMaterial;
        }

        selected = true;
    }

    void Deselect()
    {
        if (ultimoReconocido != null && materialOriginal != null)
        {
            // Restaurar el material original
            MeshRenderer renderer = ultimoReconocido.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = materialOriginal;
            }
            ultimoReconocido = null;
            selected = false;
            materialOriginal = null;
        }
    }

    void OnGUI()
    {
        //Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        //GUI.DrawTexture(rect, puntero);

        TextDetect.SetActive(ultimoReconocido != null);
    }
}
