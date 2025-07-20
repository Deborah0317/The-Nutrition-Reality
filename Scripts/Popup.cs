using UnityEngine;
public class Popup : MonoBehaviour     //classe per l'implementazione dei metodi di instanziamento e distruzione dei popup
{
    [SerializeField] protected GameObject popUp;
    [SerializeField] protected Vector3 spawnPosition;

    public void show() {
        Instantiate(popUp, spawnPosition, Quaternion.identity);
    }

    public void hide(){
        Destroy(popUp);
    }
}
