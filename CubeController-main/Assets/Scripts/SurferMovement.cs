using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class SurferMovement : MonoBehaviour
{
    public float cubeSpeed = 8.0f;
    bool L, M, R;

    void Start()
    {
        L = false;
        R = false;
        M = true;
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
            else if (R == true) {
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

        /*if(Keyboard.current.aKey.wasPressedThisFrame && L == false || M == true)
        {
            transform.DOMoveX(-1.75f, 0.3f);
            if (M == true)
            {
                transform.DOMoveX(-1.75f, 0.3f);
                L = true;
                M = false;
            }
            else
            {
                transform.DOMoveX(0.00f, 0.3f);
                M = true;
            }

        }

        if (Keyboard.current.dKey.wasPressedThisFrame && R == false || M == true)
        {
            if (M == true)
            {
                transform.DOMoveX(1.75f, 0.3f);
                L = true;
                M = false;
            }
            else
            {
                transform.DOMoveX(0.00f, 0.3f);
                M = true;
            }
        }*/
    }
}
