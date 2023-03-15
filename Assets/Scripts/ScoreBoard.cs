using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TMP_Text textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
    }

    public void UpdateScoreBoardPlayerHP(float hp)
    {
        textMeshPro.text = $"HP : {hp}%";
    }
}