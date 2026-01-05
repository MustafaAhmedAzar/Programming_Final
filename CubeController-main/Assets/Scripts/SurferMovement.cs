using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class SurferMovement : MonoBehaviour
{
    public float cubeSpeed = 8.0f;
    bool L, M, R, Jumped;

    void Start()
    {
        L = false;
        R = false;
        M = true;
        Jumped = false;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, cubeSpeed) * Time.deltaTime);


        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            if (L == false && M == true)
            {
                transform.DOMoveX(-1.75f, 0.3f);
                L = true;
                M = false;
            }
            else if (R == true)
            {
                transform.DOMoveX(0, 0.3f);
                L = false;
                M = true;
                R = false;
            }
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            if (R == false && M == true)
            {
                transform.DOMoveX(1.75f, 0.3f);
                R = true;
                M = false;
            }
            else if (L == true)
            {
                transform.DOMoveX(0, 0.3f);
                R = false;
                M = true;
                L = false;
            }
        }
        if (Keyboard.current.wKey.wasPressedThisFrame && Jumped == false)
        {
            Jumped = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        transform.DOMoveY(2, 0.2f);
        yield return new WaitForSeconds(0.2f);
        transform.DOMoveY(0, 0.18f);
        yield return new WaitForSeconds(0.14f);
        Jumped = false;

    }
}