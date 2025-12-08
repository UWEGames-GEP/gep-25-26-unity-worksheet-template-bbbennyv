using TMPro;
using UnityEngine;

public class InventoryUIButton : MonoBehaviour
{
    public TMP_Text text;

    public void SetButton(itemManager item)
    {
        text.text = item.name;
    }
}
