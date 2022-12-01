using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;//the speed of the star

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the current position of the star
        Vector2 position = transform.position;

        //Compute the star's new position
        position = new Vector2 (position.x - speed * Time.deltaTime, position.y);

        //Update the star's position
        transform.position = position;

        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        //if the star goes outside the screen on the bottom, then position the star on the top edge of the screen and randomly between the left and right side of the screen
        if (transform.position.x > max.x)
        {
            transform.position = new Vector2 (min.x, Random.Range (min.y, max.y));
        } 
    }
}
