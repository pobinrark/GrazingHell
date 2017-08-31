using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    string[] menuOptions;

 
// Default selected menu item (in this case, Tutorial).
 
    int selectedIndex = 0;
    void Start()
    {
        menuOptions = new string[4];

        menuOptions[0] = "Tutorial";
        menuOptions[1] = "Play";
        menuOptions[2] = "High Scores";
        menuOptions[3] = "Exit";
    }
    // Function to scroll through possible menu items array, looping back to start/end depending on direction of movement.

    int menuSelection(string[] menuItems, int selectedItem, string direction)
    {

        if (direction == "up")
        {
            if (selectedItem == 0)
            {
                selectedItem = menuItems.Length - 1;
            }
            else {
                selectedItem -= 1;
            }
        }

        if (direction == "down")
        {
            if (selectedItem == menuItems.Length - 1)
            {
                selectedItem = 0;
            }
            else {
                selectedItem += 1;
            }
        }

        return selectedItem;
    }



    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            selectedIndex = menuSelection(menuOptions, selectedIndex, "down");
        }

        if (Input.GetKeyDown("up"))
        {
            selectedIndex = menuSelection(menuOptions, selectedIndex, "up");
        }

        if (Input.GetKeyDown("space"))
        {
            handleSelection();
        }
    }

    void handleSelection()
    {
        GUI.FocusControl(menuOptions[selectedIndex]);

        switch (selectedIndex)
        {
            case 0:
                Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl() + " / id: " + selectedIndex);
                Application.LoadLevel("NewOpening");
                break;
            case 1:
                Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl() + " / id: " + selectedIndex);
                Application.LoadLevel("Instructions");
                break;
            case 2:
                Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl() + " / id: " + selectedIndex);
                Application.LoadLevel("");
                break;
            case 3:
                Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl() + " / id: " + selectedIndex);
                Application.Quit();
                break;
            default:
                Debug.Log("None of the above selected..");
                break;
        }
    }

    void OnGUI()
    {
        GUI.SetNextControlName("Tutorial");
        if (GUI.Button(new Rect(820, 330, 340, 100), ""))
        {
            selectedIndex = 0;
            handleSelection();
        }

        GUI.SetNextControlName("Play");
        if (GUI.Button(new Rect(675, 460, 635, 100), ""))
        {
            selectedIndex = 1;
            handleSelection();
        }

        GUI.SetNextControlName("High Scores");
        if (GUI.Button(new Rect(740, 584, 495, 100), ""))
        {
            selectedIndex = 2;
            handleSelection();
        }

        GUI.SetNextControlName("Exit");
        if (GUI.Button(new Rect(820, 715, 340, 100), ""))
        {
            selectedIndex = 3;
            handleSelection();
        }

        GUI.FocusControl(menuOptions[selectedIndex]);
    }
}
