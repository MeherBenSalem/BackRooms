using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public void EndMe()
    {
        Destroy(this.gameObject);
    }

}
