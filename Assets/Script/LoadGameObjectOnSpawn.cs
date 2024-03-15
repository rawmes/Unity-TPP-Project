using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameObjectOnSpawn : MonoBehaviour
{

    public GameObject[] gameobjects;
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (GameObject obj in gameobjects)
        {
            obj.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach (GameObject obj in gameobjects)
        {
            obj.SetActive(false);
        }
    }
}
