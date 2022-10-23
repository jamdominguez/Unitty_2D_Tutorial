using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject Camera;
    public float parallaxEffect;

    private float xLenght, startXPosition;

    void Start()
    {
        // Get start position and sprite length in x axis
        startXPosition = transform.position.x;
        xLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = Camera.transform.position.x * (1 - parallaxEffect);

        // Set object position for create parallax effect
        float distance = Camera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startXPosition + distance, transform.position.y, transform.position.z);

        // Move the object to have inifinnite backgrounds
        if (temp > startXPosition + xLenght) startXPosition += xLenght; // Move right
        else if (temp < startXPosition - xLenght) startXPosition -= xLenght; // Move left
    }
}
