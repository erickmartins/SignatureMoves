using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour {
    public Text helptext;
    public Dropdown myDropdown;
    public Button thebutton;
    private static GUIStyle ToggleButtonStyleNormal = null;
    private static GUIStyle ToggleButtonStyleToggled = null;
    // Use this for initialization
    void Start () {
       

        if (ToggleButtonStyleNormal == null)
        {
            ToggleButtonStyleNormal = "Button";
            ToggleButtonStyleToggled = new GUIStyle(ToggleButtonStyleNormal);
            ToggleButtonStyleToggled.normal.background = ToggleButtonStyleToggled.active.background;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        
        //Time.timeScale = 1.0f- Time.timeScale;
        if (helptext.text != "")
        {
            switch (myDropdown.value)
            {
                case 0:
                    helptext.text = @" The Lorenz Attractor is a set of three 
                                differential equations that have chaotic solutions 
                                for some values of the three parameters. It was 
                                studied by Edward Lorenz, and it's known for its
                                distinctive butterfly-like shape. 

                                The initial set of parameters (10, 28, 2.66) should 
                                yield chaotic solutions. Try (10, 50, 9) and see
                                how different the solution looks!";
                    break;
            }
        }else
        {
            helptext.text = "";
        }
        

        //helptext.text = "this is a help text";
        //Debug.Log(Time.timeScale);
    }
}
