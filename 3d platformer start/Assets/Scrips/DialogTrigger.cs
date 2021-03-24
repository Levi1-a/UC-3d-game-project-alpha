using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogTrigger : MonoBehaviour
{
    public Flowchart flowchart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flowchart.gameObject.SetActive(true);
            flowchart.enabled = true;
            print("colision");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            flowchart.enabled = false;
            flowchart.Reset(true, true);
            flowchart.gameObject.SetActive(false);
            print("collision exit");
        }
    }

}
