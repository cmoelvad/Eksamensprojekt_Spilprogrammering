using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text uiText;

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Points: " + gc.score + "   :   Shield health: " + gc.shield + "   :   special Ammo: " + gc.specialAmmo;
    }
}
