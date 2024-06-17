using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //libreria que nos ayuda con el menu

public class menuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Funcion que nos ayuda a cargar la escena
    public void loadScene()
    {
        //Indicamos la escena que queremos cargar
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("SampleScene");
    }

    //Funcion para salir (Solo funciona cuando el juego ya esta creado en un ejecutable)
    public void salir()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
}
