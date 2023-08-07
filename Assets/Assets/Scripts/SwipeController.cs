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
    public float timer = 3;
    public bool timerFinish = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.GetChild(0).GetChild(1).name);

        Pos = new float[transform.childCount];
        float distance = 1f / (Pos.Length - 1f);
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            Position = ScrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < Pos.Length; i++)
            {
                if (Position < Pos[i] + (distance / 2) && Position > Pos[i] - (distance / 2))
                {
                    ScrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(ScrollBar.GetComponent<Scrollbar>().value, Pos[i], 0.15f);
                    posAux = i;
                }
            }
        }
        if (Position <= 0)
        {
            //Debug.Log("Estamos en Warmisitay");
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                //Debug.Log(timer);
            }
            else
            {
                timer = 0;
                timerFinish = true;
                if (timerFinish == true)
                {
                    Debug.Log("JOSE");
                    ChangeVid(1);
                }
            }
        }
        if (Position != 0)
        {
            timer = 3;
            timerFinish = false;
            ChangeVid(0);
        }
    }
    public void next()
    {
        if (posAux < Pos.Length - 1)
        {
            posAux += 1;
            Position = Pos[posAux];
            Debug.Log("Estas en la posición: " + Position);
        }
        else
        {
            Position = Pos[0];
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
        else
        {

            Position = Pos[2];
        }

    }
    public void ChangeVid(int flag) {
        if (flag == 1)
        {
            this.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            this.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            this.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        }
        
    }
}
