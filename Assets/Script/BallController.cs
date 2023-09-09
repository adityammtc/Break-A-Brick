using UnityEngine;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rigid;
    private PapanController papanController;
    private RespawnController respawnController; // Tambahkan ini

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        papanController = FindObjectOfType<PapanController>();
        respawnController = FindObjectOfType<RespawnController>();
        AcakArahBola();
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Bawah")
        {
            respawnController.ResetBallPosition(gameObject);
        }
        else if (coll.gameObject.CompareTag("Papan"))
        {
            HandlePapanCollision(coll);
        }
    }


    private void AcakArahBola()
    {
        float randomX = Random.Range(-1f, 1f);
        Vector2 arah = new Vector2(randomX, -2).normalized;
        rigid.AddForce(arah * force);
    }

    private void HandlePapanCollision(Collision2D coll)
    {
        float offset = transform.position.x - coll.transform.position.x;
        float angle = offset / coll.collider.bounds.size.x;
        Vector2 bounceDirection = new Vector2(angle, 1).normalized;

        rigid.velocity = Vector2.zero;
        rigid.AddForce(bounceDirection * force);
    }
}
