using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool KeyGot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyGot)
        {
            DestroyDoor();
        }
    }
    public void DestroyDoor()
    {
        Destroy(gameObject);
    }
}
