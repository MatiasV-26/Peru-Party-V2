using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour
{
    public GameObject ScrollBar;
    float Position = 0;
    float[] Pos;
    int posAux = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pos = new float[transform.childCount];
        float distance = 1f / (Pos.Length -1f);
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            Position = ScrollBar.GetComponent<Scrollbar>().value;
        }
        else {
            for (int i = 0; i < Pos.Length; i++) {
                if (Position < Pos[i] + (distance / 2) && Position > Pos[i] - (distance / 2)) {
                    ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, Pos[i], 0.15f);
                    posAux = i;
                }
            }
        }
    }
    public void next(){
        if (posAux < Pos.Length - 1) {
            posAux += 1;
            Position = Pos[posAux];
            Debug.Log("Estas en la posición: " + Position);
        }
    }
    public void previous()
    {
        if (posAux > 0)
        {
            posAux -= 1;
            Position = Pos[posAux];
            Debug.Log("Estas en la posición: " + Position);
        }
    }
}
