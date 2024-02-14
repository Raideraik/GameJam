using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{/*
    [SerializeField] private Camera _cameraB;
    [SerializeField] private Camera _cameraA;
    [SerializeField] private Material _cameraMatB;
    [SerializeField] private Material _cameraMatA;
    
    [SerializeField] private Camera _cameraC;
    [SerializeField] private Camera _cameraD;
    [SerializeField] private Material _cameraMatC;
    [SerializeField] private Material _cameraMatD;
    */
    [SerializeField] private Camera[] _cameras;
    [SerializeField] private Material[] _cameraMats;

    private void Start()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            CreateTexture(_cameras[i], _cameraMats[i]);

        }
        /*
        if (_cameraA.targetTexture != null)
        {
            _cameraA.targetTexture.Release();
        }

        _cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatA.mainTexture = _cameraA.targetTexture;
        
        if (_cameraB.targetTexture != null)
        {
            _cameraB.targetTexture.Release();
        }

        _cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatB.mainTexture = _cameraB.targetTexture;
        

        if (_cameraC.targetTexture != null)
        {
            _cameraC.targetTexture.Release();
        }

        _cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatC.mainTexture = _cameraC.targetTexture;
        
        if (_cameraD.targetTexture != null)
        {
            _cameraD.targetTexture.Release();
        }

        _cameraD.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        _cameraMatD.mainTexture = _cameraD.targetTexture;*/
    }

    private void CreateTexture(Camera camera, Material material) 
    {
        if (camera.targetTexture != null)
        {
            camera.targetTexture.Release();
        }

        camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        material.mainTexture = camera.targetTexture;

        
    }
}
