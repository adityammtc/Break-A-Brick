using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalBricks; // Jumlah total brick di level

    void Start()
    {
        totalBricks = GameObject.FindGameObjectsWithTag("Brick").Length; // Menghitung total brick di awal permainan
    }

    public void BrickDestroyed()
    {
        totalBricks--;

        if (totalBricks <= 0)
        {
            // Semua brick telah dihancurkan, pindah ke scene "Win"
            SceneManager.LoadScene("Win");
        }
    }
}
