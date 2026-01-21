using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class SurferMovement : MonoBehaviour
{
    public float cubeSpeed = 8.0f;
    bool L, M, R, Jumped;
    public bool Alive;
    public int score = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        L = false;
        R = false;
        M = true;
        Jumped = false;
        Alive = true;
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, cubeSpeed) * Time.deltaTime);

        if (Alive == true && cubeSpeed > 3)
        {

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
        } else
        {
            finish();
        }
    }

    IEnumerator Delay()
    {
        transform.DOMoveY(2, 0.2f);
        yield return new WaitForSeconds(0.2f);
        transform.DOMoveY(0, 0.2f);
        yield return new WaitForSeconds(0.2f);
        Jumped = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            finish();
        }
        if (other.CompareTag("SlowDown"))
        {
            cubeSpeed -= 0.5f;
            if (score > 0)
            {
                score--;
            }
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedUp"))
        {
            cubeSpeed += 0.5f;
            score++;
            Destroy(other.gameObject);
        }
    }

    void finish()
    {
        cubeSpeed = 0;
        Alive = false;
        print("Game Over! Your score is: " + score);
    }
}