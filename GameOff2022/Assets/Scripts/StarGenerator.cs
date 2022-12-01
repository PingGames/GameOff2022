using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject StarGOyellow;//this is our StarGOyellow prefab
    public GameObject StarGOpink;//this is our StarGOpink prefab
    public GameObject StarGOblue;//this is our StarGOblue prefab
    public int MaxStars;//the maximum numbers of stars

    //Array of colours
    Color[] starColors = {
        new Color (0.75f, 0.75f, 0.75f)//blue
    };

    // Start is called before the first frame update
    void Start()
    {
        //this is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

        //Loop to create the stars
        for (int i = 0; i < MaxStars; ++ i)
        {
            GameObject star = (GameObject)Instantiate(StarGOyellow);
            //set the star color
            star.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            //set the position of the star (random x and random y)
            star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //set a random speed and make the size of the star dependending on the speed of it
            float randomValue = Random.value;
            float scale = randomValue / 2f * 0.1f;

            // Set the speed
            star.GetComponent<Star>().speed = -(1f * randomValue + 0.5f);
            // Set the size
            star.transform.localScale = new Vector3(scale, scale, scale);

            //make the star a child of the StarGeneratorGO
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
