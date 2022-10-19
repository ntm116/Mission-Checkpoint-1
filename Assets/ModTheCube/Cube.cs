using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    [SerializeField]
    private float range = 4f;

    [SerializeField]
    private float rotateSpeed = 10f;

    [SerializeField]
    private float opacity = 0.4f;

    private float colorR = 0f;
    private float colorG = 0f;
    private float colorB = 0f;
    private int sign = -1;

    void Start()
    {
        float randomX = Random.Range(-range, range);
        float randomY = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        float randomScale = Random.Range(0.1f, range);

        transform.position = new Vector3(randomX, randomY, randomZ);
        transform.localScale = Vector3.one * randomScale;
    }
    
    void Update()
    {
        // Rotate cube over time
        transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f);

        // Change color of cube over time
        Material material = Renderer.material;


        if (colorR > 1f)
            if (colorG > 1f)
                if (colorB > 1f)
                {
                    colorR = 0;
                    colorG = 0;
                    colorB = 0;
                    sign = -sign;
                } 
                else
                {
                    colorB += Time.deltaTime;
                }
            else
            {
                colorG += Time.deltaTime;
            }
        else
        {
            colorR += Time.deltaTime;
        }

        if (sign > 0)
            material.color = new Color(1 - colorR, 1 - colorG, 1 - colorB, opacity);
        else
        {
            material.color = new Color(colorR, colorG, colorB, opacity);
        }
    }
}
