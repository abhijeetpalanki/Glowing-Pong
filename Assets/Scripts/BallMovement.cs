using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{   
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

	private int hitCounter = 0;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
	}

    private void RestartBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        if (player1Start)
        {   
            MoveBall(new Vector2(-1, 0));
        } else 
        {
			MoveBall(new Vector2(1, 0));
		}
    }

    public void MoveBall(Vector2 direction) {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
