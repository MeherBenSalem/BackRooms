using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMats : MonoBehaviour
{
    public Material[] materials;

    void Start() {
        int index = Random.Range(0, materials.Length);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = materials[index];
    }
}
