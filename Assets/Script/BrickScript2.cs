// BrickScript2.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickScript2 : MonoBehaviour
{
    public Sprite[] brickSprites; // Variabel untuk menyimpan gambar-gambar brick
    private SpriteRenderer spriteRenderer;
    private int hitCount = 0; // Menambahkan variabel untuk menghitung jumlah tabrakan

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeBrickImage()
    {
        if (brickSprites.Length > 0)
        {
            // Menentukan indeks gambar berdasarkan hitCount
            int imageIndex = Mathf.Clamp(hitCount - 1, 0, brickSprites.Length - 1);
            spriteRenderer.sprite = brickSprites[imageIndex];
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            HandleBallCollision();
        }
    }

    private void HandleBallCollision()
    {
        hitCount++; // Tambah hit count setiap kali bola bersentuhan dengan brick

        if (hitCount >= 3)
        {
            // Hancurkan objek brick setelah 3 hit
            GameManager2 gameManager = FindObjectOfType<GameManager2>();
            if (gameManager != null)
            {
                gameManager.BrickDestroyed();

                // Tambah skor ketika brick dihancurkan
                SkorUI skorUI = FindObjectOfType<SkorUI>();
                if (skorUI != null)
                {
                    skorUI.TambahSkor(5); // Misalnya, tambah 5 skor setiap kali brick dihancurkan
                }
            }

            // Hapus objek brick
            Destroy(gameObject);
        }
        else
        {
            ChangeBrickImage(); // Ubah gambar brick sesuai dengan hitCount
        }
    }
}
