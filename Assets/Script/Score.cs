using UnityEngine;
using UnityEngine.UI;

public class SkorUI : MonoBehaviour
{
    private Text skorText;
    private int skor = 0;

    void Start()
    {
        skorText = GetComponent<Text>();
        UpdateSkorText();
    }

    public void TambahSkor(int jumlah)
    {
        skor += jumlah;
        UpdateSkorText();
    }

    private void UpdateSkorText()
    {
        skorText.text = "Skor: " + skor;
    }
}
