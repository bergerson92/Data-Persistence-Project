using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvasaccess : MonoBehaviour
{

    public TextMeshProUGUI Test2;
    private void Start()
    {
        // Assuming you have a reference to your Canvas game object
        GameObject canvasObject = GameObject.Find("CanvasMain");

        // Assuming you have a reference to the first child object within the Canvas
        GameObject firstChildObject = canvasObject.transform.Find("Test").gameObject;

        // Assuming you have a reference to the nested child object within the first child object
        //GameObject nestedChildObject = firstChildObject.transform.GetChild(0).gameObject;

        // Get the last child object of the nested child object
        //int lastChildIndex = nestedChildObject.transform.childCount - 1;
        //GameObject lastChildObject = nestedChildObject.transform.GetChild(lastChildIndex).gameObject;

        // You now have a reference to the last child object
        // Do whatever you want with it
        //Debug.Log("Last child object name: " + lastChildObject.name);
        //Debug.Log("object name is" + firstChildObject.name);

        Test2 = firstChildObject.GetComponent<TextMeshProUGUI>();

    }
}

