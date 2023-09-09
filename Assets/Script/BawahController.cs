using UnityEngine;
using UnityEngine.SceneManagement;

public class BawahController : MonoBehaviour
{
    private int hits = 0;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // Kurangi nyawa ketika bola menyentuh "Bawah"
            NyawaUI nyawaUI = FindObjectOfType<NyawaUI>();
            if (nyawaUI != null)
            {
                nyawaUI.KehilanganNyawa();
            }

            // Contoh: Pindah ke scene "Lose" jika nyawa habis
            if (nyawaUI != null && nyawaUI.Nyawa <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}