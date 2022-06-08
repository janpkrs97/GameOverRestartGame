using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateSize(int id)
    {
        if (id == 1)
        {
            this.gameObject.transform.localScale = new Vector3(2.5f, 1f, 3f);
        }
        else if (id == 2)
        {
            this.gameObject.transform.localScale = new Vector3(3.5f, 1f, 4f);
        }
        else
        {
            this.gameObject.transform.localScale = new Vector3(4.5f, 1f, 5f);
        }
    }
}
