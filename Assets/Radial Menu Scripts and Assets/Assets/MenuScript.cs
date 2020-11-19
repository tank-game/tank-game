using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public Vector2 normalisedMousePosition;
    public float currentAngle;
    public int selection;
    private int previousSelection;
    public Transform radialMenu;

    public GameObject[] menuItems;
    public RectTransform RectTransform;
    public bool Selected;

    private MenuItemScript menuItemSc;
    private MenuItemScript previousMenuItemSc;

    // Start is called before the first frame update

    void Start()
    {
        radialMenu.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Selected = true;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey("z"))
        {
            radialMenu.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            MenuOpen();
            Selected = false;
        }
        else
        {
            radialMenu.gameObject.SetActive(false);
            //BackgroundPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Selected = true;
        }
    }

    void MenuOpen()
    {
        
   

        normalisedMousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
        currentAngle = Mathf.Atan2(normalisedMousePosition.y, normalisedMousePosition.x) * Mathf.Rad2Deg;
        //dividing the screen into 8ths

        currentAngle = (currentAngle + 360) % 360;

        selection = (int)currentAngle / 45;

        if (selection != previousSelection)
        {
            previousMenuItemSc = menuItems[previousSelection].GetComponent<MenuItemScript>();
            previousMenuItemSc.Deselect();
            previousSelection = selection;

            menuItemSc = menuItems[selection].GetComponent<MenuItemScript>();
            menuItemSc.Select();
        }

    }

}
