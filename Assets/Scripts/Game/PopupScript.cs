using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(0,0,-5), 2).SetAutoKill(true);
        GetComponent<TextMeshPro>().DOFade(0, 2).OnComplete(KillYourself);
    }

    void KillYourself()
    {
        Destroy(gameObject);
    }
}
