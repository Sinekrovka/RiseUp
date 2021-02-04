using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOrFail : MonoBehaviour
{
    public Fail fail;

    private void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("game");
    }

    private void FixedUpdate()
    {
        if (fail.Failed)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
