using System;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    [SerializeField] private Camera mainCam = null;
    [SerializeField] private Transform myCube = null;
    [SerializeField] private Color rayColor = Color.red;
    private float distance;
    private List<Ray> rays;

    private void Awake()
    {
        rays = new List<Ray>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRay();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            rays.Clear();
        }
        
    }

    private void ShootRay()
    {
        var viewportPoint = mainCam.ScreenToViewportPoint(Input.mousePosition);
        var ray = mainCam.ViewportPointToRay(viewportPoint);
        rays.Add(ray);
        print($"Number of rays shot: {rays.Count}");
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        
        
        Gizmos.color = rayColor;
        for (var i = 0; i < rays.Count; i++)
        {
            Gizmos.DrawRay(rays[i]);
        }
    }
}
