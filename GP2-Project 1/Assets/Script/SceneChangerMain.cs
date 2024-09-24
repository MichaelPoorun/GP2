using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scene Management Library

public class SceneChangerMain : MonoBehaviour
{
    void Start()
    {

    }

    private void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Controls");  //Load Sample Scene
    }
}
