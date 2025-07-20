using UnityEngine;

public class hand_track : MonoBehaviour
{
    public GameObject left_hand_parent;
    public GameObject right_hand_parent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject redSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        redSphere.transform.position = left_hand_parent.transform.position;
        redSphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        redSphere.GetComponent<Renderer>().material.color = Color.red;
        redSphere.transform.parent = left_hand_parent.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
