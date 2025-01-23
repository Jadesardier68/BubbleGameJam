using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BubbleTypeSwitch : MonoBehaviour
{
    public List<GameObject> bubbleTypes;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < bubbleTypes.Count; i++)
        {
            bubbleTypes[i].SetActive(i == currentIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Mouse ScrollWheel")) > 0f)
        {
            ChangeBubbleTypeUp();
        }
    }

    public void ChangeBubbleTypeUp()
    {
        // Désactive le type actuel
        bubbleTypes[currentIndex].SetActive(false);

        // Incrémente l'index et retourne au début si on est à la fin de la liste
        currentIndex = (currentIndex + 1) % bubbleTypes.Count;

        // Active le nouveau type de bulle
        bubbleTypes[currentIndex].SetActive(true);
    }
}

