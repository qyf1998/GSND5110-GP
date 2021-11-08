using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestroy : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            //放置失败
            PlaceObjectManager.isRed = !PlaceObjectManager.isRed;
            Debug.Log("放不了");
            Destroy(this.gameObject);
        }
    }

}
