using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class SurferMovement : MonoBehaviour
{
    public float cubeSpeed = 8.0f;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, cubeSpeed) * Time.deltaTime);
        if(Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.DOMoveX(-1.75f, 0.3f);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.DOMoveX(1.75f, 0.3f);
        }
    }
}
