using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScrollingScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(2, 2);
    public Vector2 direction = new Vector2(-1, 0);
    public bool linkedToCamera = false;
    public bool isLooping = false;

    private List<SpriteRenderer> backgroundParts;

    private void Start()
    {
        if (isLooping)
        {
            backgroundParts = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer renderer = child.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    backgroundParts.Add(renderer);
                }
            }
            backgroundParts = backgroundParts.OrderBy(
              t => t.transform.position.x
            ).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x * Time.deltaTime, speed.y * direction.y * Time.deltaTime, 0);
        transform.Translate(movement);
        if (linkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }

        if (isLooping)
        {
            SpriteRenderer firstChild = backgroundParts.FirstOrDefault();
            if (firstChild != null)
            {
                if (firstChild.transform.position.x < Camera.main.transform.position.x && firstChild.isVisibleFrom(Camera.main) == false)
                {
                    SpriteRenderer lastChild = backgroundParts.LastOrDefault();
                    Vector3 lastChildPosition = lastChild.transform.position;
                    Vector3 lastChildSize = lastChild.bounds.max - lastChild.bounds.min;
                    firstChild.transform.position = new Vector3(lastChildPosition.x + lastChildSize.x, firstChild.transform.position.y, firstChild.transform.position.z);
                    backgroundParts.Remove(firstChild);
                    backgroundParts.Add(firstChild);

                }
            }
        }
    }
}
