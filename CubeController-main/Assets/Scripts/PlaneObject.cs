using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneObject : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlaneMovement());
    }

    IEnumerator PlaneMovement()
    {
        transform.DOLocalMoveX(-0.8f, 1);
        yield return new WaitForSeconds(1);
        transform.DOLocalMoveX(4.5f, 1);
        yield return new WaitForSeconds(1);
        StartCoroutine(PlaneMovement());
    }

}
