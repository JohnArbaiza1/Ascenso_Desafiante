using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerias a usar
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project
{

    public class SPLASHSCREEN : MonoBehaviour
    {
        //Variables a emplear
        private Image _miLogo;
        private bool _loadFinish; //Para cuando termina la carga
        private bool _endLogo; //Para cuando termina la animacion

        //definimos una funcion que inicializa algunas variables y configura el cursor del mouse.
        private void config()
        {
            //Bloqueamos el mouse
            Cursor.lockState = CursorLockMode.Locked;
            _miLogo = GetComponent<Image>();
            _loadFinish = false;
            _endLogo = false;
            //Establecemos la transparencia del logo a 0.
            _miLogo.color = new Color(_miLogo.color.r, _miLogo.color.g, _miLogo.color.b, 0f);

        }

        // Start is called before the first frame update
        void Start()
        {
            //Si estamos en el editor de Unity  elimina todas las preferencias del jugador
            #if UNITY_EDITOR
                PlayerPrefs.DeleteAll();
            #endif

            _loadFinish=true;


        }

        // Update is called once per frame
        void Update()
        {
            //Si _loadFinish y _endLogo son true, cargaMOS la escena llamada “Menu”.
            if (_loadFinish && _endLogo)
            {
                SceneManager.LoadSceneAsync("Menu");
            }

        }

        //indicamos que la animación del logo ha terminado.
        public void endAnimation()
        {
            _endLogo=true;
        }
    }
}
