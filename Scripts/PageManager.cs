using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class PageManager : MonoBehaviour
{
    private int page = 0;    // Pagina attuale

    [SerializeField] private GameObject arrowGUI; // Il GameObject che contiene entrambe le frecce
    [SerializeField] private GameObject beforeGUI; // La freccia per la pagina precedente
    [SerializeField] private GameObject afterGUI;  // La freccia per la pagina successiva

    // Singleton
    public static PageManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("PageManager: Trovata un'altra istanza. Distruggo questa.");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Debug.Log("PageManager: Singleton istanza impostata.");
    }

    // La gestione delle pagine in una GUI
    public void pageManager(int itemTot, int pageSpace) // Numero di elementi totali (itemTot) e quanti elementi per pagina (pageSpace)
    {
        Debug.Log($"PageManager: pageManager() chiamato. itemTot: {itemTot}, pageSpace: {pageSpace}, current page: {page}.");

        if (itemTot <= pageSpace)
        {
            // Se abbiamo massimo pageSpace item allora non abbiamo bisogno di altre pagine
            page = 0; // Reset della pagina
            arrowGUI.SetActive(false); // Disabilito le freccette
            beforeGUI.SetActive(false);
            afterGUI.SetActive(false);  
        }
        else
        {
            // Ho più di una pagina
            arrowGUI.SetActive(true);

            if (page == 0) // Se sono nella prima pagina
            {
                Debug.Log("PageManager: Sono alla prima pagina. Disattivo freccia 'Precedente'.");
                beforeGUI.SetActive(false);
                afterGUI.SetActive(true);   
            }
            else if (page == (itemTot/pageSpace)) // Se siamo all'ultima pagina
            {
                Debug.Log("PageManager: Sono all'ultima pagina. Disattivo freccia 'Successivo'.");
                beforeGUI.SetActive(true);
                afterGUI.SetActive(false); 
            }
            else
            {   // Quando ho bisogno sia della pagina precedente che della successiva
                Debug.Log("PageManager: Sono in una pagina intermedia. Attivo entrambe le frecce.");
                beforeGUI.SetActive(true);
                afterGUI.SetActive(true);
            }
        }
        Debug.Log($"PageManager: pageManager() completato. Pagina attuale: {page}.");
    }

    public void changePage(int move)
    { // Se move=1 va avanti, se move=0 va indietro
        int oldPage = page;
        if (move == 1)
        {
            page++;
            Debug.Log($"PageManager: Avanti di una pagina. Nuova pagina: {page}.");
        }
        else if (move == 0)
        {
            page--;
            if (page < 0) page = 0; // Impedisci di andare sotto 0
            Debug.Log($"PageManager: Indietro di una pagina. Nuova pagina: {page}.");
        }
        else
        {
            Debug.Log($"PageManager: 'move' non valido in changePage(). Valore: {move}");
        }
    }

    public int getPage()
    {
        return page;
    }
}