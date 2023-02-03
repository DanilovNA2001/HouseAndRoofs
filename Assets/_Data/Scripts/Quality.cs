using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour
{
    private Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = gameObject.GetComponent<Dropdown>();
        dropdown.value = QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    public void CheckDropdown()
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }
}
