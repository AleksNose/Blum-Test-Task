using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private Text lifeText;

    public void UpdateMoney(int money)
    {
        moneyText.text = "x" + money.ToString();
    }

    public void UpdateLife(int life)
    {
        lifeText.text = "x" + life.ToString();
    }
}
