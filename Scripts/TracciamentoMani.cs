using System.IO;
using UnityEngine;

public class TracciamentoMani : MonoBehaviour
{
    public GameObject left_hand_parent;
    public GameObject right_hand_parent;
    [SerializeField] private Material colorSpehere;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*GameObject redSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        redSphere.transform.position = left_hand_parent.transform.position;
        redSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        redSphere.GetComponent<Renderer>().material.color = Color.yellow;
        redSphere.transform.parent = left_hand_parent.transform;*/
        
        //version 2:

        foreach (Transform child in left_hand_parent.GetComponentsInChildren<Transform>())
        {
            GameObject redSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            redSphere.transform.position = child.position;
            redSphere.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            redSphere.GetComponent<Renderer>().material = colorSpehere;
            redSphere.transform.parent = child;
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        string path = Path.Combine(Application.persistentDataPath, "hand_positions.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            foreach (Transform child in left_hand_parent.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.GetComponent<Renderer>() == null)
                {
                    writer.WriteLine($"{child.position}: {child.position}");
                }
            }
            
            foreach (Transform child in right_hand_parent.GetComponentsInChildren<Transform>())
            {
                if (child.gameObject.GetComponent<Renderer>() == null)
                {
                    writer.WriteLine($"{child.position}: {child.position}");
                }
            }
        }
    }
}
