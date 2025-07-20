using UnityEngine;

public class HeadLockedUI : MonoBehaviour
{
    public Transform headTransform;
    public Vector3 localOffset = new Vector3(-0.3f, 0, 1f); // Regola la posizione rispetto alla testa
    public Vector3 rotationOffset = new Vector3(-0.3f, 0, 1f);

    void Update()
    {
        if (headTransform != null)
        {
            // Imposta la posizione relativa alla testa
            transform.position = headTransform.position + headTransform.TransformDirection(localOffset);
            transform.rotation = headTransform.rotation * Quaternion.Euler(rotationOffset);
            // Mantiene la UI sempre dritta
            /*Vector3 lookDirection = transform.position - headTransform.position;
            lookDirection.y = 0; // Rimuove la componente verticale per evitare inclinazioni
            transform.rotation = Quaternion.LookRotation(lookDirection);*/
        }
    }
}