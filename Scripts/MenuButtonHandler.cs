using UnityEngine;
using UnityEngine.UI; // Necessario per il componente Button

public class MenuButtonHandler : MonoBehaviour
{
    // Questo è il riferimento al GameObject del tuo MenuPopUp.
    // Lo assegnerai dall'Editor di Unity.
    [SerializeField] private GameObject menuPopUp;
    [SerializeField] private Vector3 menuSpawnPosition;

    // Assicurati che questo script sia attaccato al tuo GameObject MenuIcon (quello con il componente Button).
    // Questo metodo verrà chiamato quando si clicca il bottone.
    public void CreateMenuPopUp()
    {
        Instantiate(menuPopUp, menuSpawnPosition, Quaternion.identity);
    }

    public void DestroyMenuPopUp()
    {
        Destroy(menuPopUp);
    }
}
