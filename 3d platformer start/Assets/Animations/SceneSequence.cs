using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{

    public GameObject Cam1;

    void Start()
    {
        StartCoroutine (TheSequence());
    }

    IEnumerator TheSequence ()
    {
        yield return new WaitForSeconds(4);
        Cam1.SetActive(false);
        
    }

}
