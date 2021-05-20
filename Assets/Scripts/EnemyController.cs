using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<WaypointScript> waypoints = new List<WaypointScript>();
    public float speed = 1.0f;
    public int destinationWaypoint = 1;
    public Transform player;
    public Transform respawnPoint;
    public GameObject Panel;

    private Vector3 destination;
    private bool forwards = true;

    // Start is called before the first frame update
    void Start()
    {
        this.destination = this.waypoints[destinationWaypoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo());
    }

    IEnumerator MoveTo()
    {
        while ((transform.position - this.destination).sqrMagnitude > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                this.destination, this.speed * Time.deltaTime);
            yield return null;
        }

        if ((transform.position - this.destination).sqrMagnitude <= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (this.waypoints[destinationWaypoint].isEndPoint)
        {
            if (this.forwards)
                this.forwards = false;
            else
                this.forwards = true;
        }

        if (this.forwards)
            ++destinationWaypoint;
        else
            --destinationWaypoint;

        this.destination = this.waypoints[destinationWaypoint].transform.position;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = respawnPoint.position;

            if (Panel != null)
            {
                bool isActive = Panel.activeSelf;
                Panel.SetActive(!isActive);
            }
        }
    }
}
