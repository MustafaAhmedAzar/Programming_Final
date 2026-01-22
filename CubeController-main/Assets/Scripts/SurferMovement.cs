using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SurferMovement : MonoBehaviour
{
    public float cubeSpeed = 8.0f;
    bool L, M, R, Jumped;
    bool Alive;
    public int score = 0;
    public AudioSource hitSound;
    public AudioSource coinSound;
    public ParticleSystem hitEffect;
    public GameObject endScreen;
    public Text scoreDisplay;

    void Start()
    {
        Application.targetFrameRate = 60;
        L = false;
        R = false;
        M = true;
        Jumped = false;
        Alive = true;
        endScreen.SetActive(false);
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, cubeSpeed) * Time.deltaTime);

        if (Alive == true && cubeSpeed > 5)
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
        transform.DOMoveY(2, 0.3f);
        yield return new WaitForSeconds(0.3f);
        transform.DOMoveY(0, 0.4f);
        yield return new WaitForSeconds(0.3f);
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
            hitSound.Play();
            hitEffect.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedUp"))
        {
            if (cubeSpeed < 14)
            {
                cubeSpeed += 0.5f;
            }
            score++;
            coinSound.Play();
            Destroy(other.gameObject);
        }
    }

    void finish()
    {
        cubeSpeed = 0;
        Alive = false;
        endScreen.SetActive(true);
        scoreDisplay.text = "Game Over! \n Your score is: " + score.ToString();
    }
}