using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints; 
    // Start is called before the first frame update
    public void Teleport(int id)
    {
        this.gameObject.transform.position = wayPoints[id].position;
        this.gameObject.transform.Rotate(wayPoints[id].eulerAngles);
    }
}
