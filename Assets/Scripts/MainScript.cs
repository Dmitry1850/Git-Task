using UnityEngine;
using UnityEngine.UI;

public enum ThisPlayer 
{ 
    Zero,
    Dagger
}
public class MainScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] buttons_array;

    [SerializeField]
    private Text active_Player;

    [SerializeField]
    private GameObject zero;

    [SerializeField]
    private GameObject dagger;

    private byte active_element = (byte)ThisPlayer.Zero;

    void Start()
    {

    }

    void FixedUpdate()
    {
        
    }

    private void IfPlayerClickButtoon(GameObject button)
    {
        if (active_element == (byte)ThisPlayer.Zero)
        {
            active_element = (byte)ThisPlayer.Dagger;
            active_Player.text = "Очередь игрока, играющего ноликами";
        }
        else
        {
            active_element = (byte)ThisPlayer.Zero;
            active_Player.text = "Очередь игрока, играющего крестиками";
        }

        button.SetActive(false);
    }

    public void OnClickButton_1_1()
    {

        IfPlayerClickButtoon(buttons_array[0]);

        
    }
    public void OnClickButton_1_2()
    {
        IfPlayerClickButtoon(buttons_array[1]);
    }
    public void OnClickButton_1_3()
    {
        IfPlayerClickButtoon(buttons_array[2]);
    }

    public void OnClickButton_2_1()
    {
        IfPlayerClickButtoon(buttons_array[3]);
    }
    public void OnClickButton_2_2()
    {
        IfPlayerClickButtoon(buttons_array[4]);
    }
    public void OnClickButton_2_3()
    {
        IfPlayerClickButtoon(buttons_array[5]);
    }

    public void OnClickButton_3_1()
    {
        IfPlayerClickButtoon(buttons_array[6]);
    }
    public void OnClickButton_3_2()
    {
        IfPlayerClickButtoon(buttons_array[7]);
    }
    public void OnClickButton_3_3()
    {
        IfPlayerClickButtoon(buttons_array[8]);
    }
}
