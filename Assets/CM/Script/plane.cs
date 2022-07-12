using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plane : MonoBehaviour
{

    Texture2D[] textures; //;  
    private float i = 0;
    Material m_Material;

    void Start()
    {

    }

    void Update()
    {
        if (i == 1)
        {
            i++; // 
            //m_Material.mainTexture = textures[i];

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            print(gameObject.name);
        }
    }

}
