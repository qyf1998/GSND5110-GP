using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestroy : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer == 10)
        {
            //����ʧ��
            PlaceObjectManager.isRed = !PlaceObjectManager.isRed;
            Debug.Log("�Ų���");
            Destroy(this.gameObject);
        }
    }

}
