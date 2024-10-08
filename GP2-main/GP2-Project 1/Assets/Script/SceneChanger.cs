using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Load Scene Management Library

public class SceneChanger : MonoBehaviour
{
    void Start()
    {

    }

    private void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");  //Load Sample Scene
    }
}