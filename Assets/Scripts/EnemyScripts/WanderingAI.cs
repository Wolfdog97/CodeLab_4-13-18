using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {

    public float speed = 3.0f;
    public float obsticalRange = 5.0f;

    private bool _alive;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update () {
        if(_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit)) // Do raycasting with a circumference around the ray
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>()){

                    Debug.Log("hitting player");

                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position =
                            transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                if (hit.distance < obsticalRange)
                {
                    float angle = Random.Range(-110, 110); // Turn a semirandom new direction
                    transform.Rotate(0, angle, 0);
                }
            }
            else if (hit.distance < obsticalRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
	}

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

}
