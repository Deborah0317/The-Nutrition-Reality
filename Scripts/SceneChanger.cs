using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Serialization;

namespace Oculus.Interaction
{
    public class SceneChanger : MonoBehaviour
    {
        //Carica scena successiva, semplice incremento
        public void LoadNextScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }

        public void LoadChosenScene(int sceneChoice) // sceneChoice = 2 Mani, sceneChoice = 3 Controller
        {
            SceneManager.LoadScene(sceneChoice);
        }


        //scena iniziale
        public void LoadStartScene()
        {
            SceneManager.LoadScene(0);

        }

        
        
    }
}
