using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraWait : MonoBehaviour
{
    [SerializeField]private FollowPlayer fp;
    
    private void Start() {
        GameManager.OnCarChoosen += GameManager_OnCarChosen;
    }

    private void GameManager_OnCarChosen(object sender, EventArgs e)
    {
        fp.enabled = true;
    }
}
