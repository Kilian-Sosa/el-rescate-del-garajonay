using UnityEngine;

public class Dialog : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public GameObject objectToAppearDisappear;
    public float epsilon = 0.5f; // Tolerancia para la comparación de posiciones
    public bool loadMusic = true;

    void Update()
    {
        // Calcula la distancia actual entre pointA y pointB
        float currentDistance = Vector3.Distance(pointA.position, pointB.position);

        // Comprueba si el objeto está lo suficientemente cerca del punto B para aparecer/desaparecer
        if (currentDistance < epsilon)
        {
            objectToAppearDisappear.SetActive(true); // Aparece el objeto
            if (loadMusic) {
                AudioManager.instance.PlaySFX("Whistle3SFX");
                loadMusic = false;
            }
        }
        else
        {
            objectToAppearDisappear.SetActive(false); // Desaparece el objeto
        }
    }

}
