using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DebugRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataBaseManager.Instance.Skibidi();

        DataBaseManager.Instance.AddPlayer();

        DataBaseManager.Instance.UpdatePlayer(1, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
