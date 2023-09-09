using UnityEngine;
using UnityEngine.UI;

public class NyawaUI : MonoBehaviour
{
    private Text nyawaText;
    private int nyawa = 3; // Jumlah nyawa awal

    // Properti Nyawa yang dapat diakses dari luar skrip
    public int Nyawa
    {
        get { return nyawa; }
    }

    void Start()
    {
        nyawaText = GetComponent<Text>();
        UpdateNyawaText();
    }

    public void KehilanganNyawa()
    {
        nyawa--;

        if (nyawa < 0)
        {
            nyawa = 0;
        }

        UpdateNyawaText();
    }

    private void UpdateNyawaText()
    {
        nyawaText.text = "Nyawa: " + nyawa;
    }
}
