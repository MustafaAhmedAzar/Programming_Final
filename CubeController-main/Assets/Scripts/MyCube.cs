using UnityEngine;
using UnityEngine.InputSystem;

public class MyCube : MonoBehaviour
{
    public float cubeSpeed = 5, leftRightSpeed = 5;
    public float leftBorder = -3.0f, rightBorder = 3.0f;
    public int score = 0;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, cubeSpeed) * Time.deltaTime);

        if (Keyboard.current.aKey.isPressed && transform.position.x > leftBorder)
        {
            transform.position += new Vector3(-leftRightSpeed, 0, 0) * Time.deltaTime;
        }
        if (Keyboard.current.dKey.isPressed && transform.position.x < rightBorder)
        {
            transform.position += new Vector3(leftRightSpeed, 0, 0) * Time.deltaTime;
        }
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            leftRightSpeed = 0;
            cubeSpeed = 0;
            print("Game Over! Your score is: " + score);
        }
        if (other.CompareTag("SlowDown"))
        {
            leftRightSpeed -= 0.01f;
            cubeSpeed -= 0.01f;
            score--;
            Destroy(other.gameObject);//destroy the object that you hit!
        }
        if (other.CompareTag("SpeedUp"))
        {
            leftRightSpeed += 0.01f;
            cubeSpeed += 0.01f;
            score++;
            Destroy(other.gameObject);//destroy the object that you hit!
        }
    }
}
