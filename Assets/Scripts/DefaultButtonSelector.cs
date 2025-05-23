using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultButtonSelector : MonoBehaviour
{
    public GameObject defaultButton;

    void OnEnable()
    {
        SelectDefaultButton();
    }

    private void SelectDefaultButton()
    {
        if (defaultButton != null && defaultButton.activeInHierarchy)
        {
            EventSystem.current.SetSelectedGameObject(null); // limpia selecci�n anterior
            EventSystem.current.SetSelectedGameObject(defaultButton); // selecciona el nuevo
        }
    }
}
