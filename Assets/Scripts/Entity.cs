using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int lane;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, lane);

        switch(transform.position.y)
        {
            case -1:
                lane = 3;
                break;
            case -2:
                lane = 2;
                break;
            case -3:
                lane = 1;
                break;
        }
    }
}
