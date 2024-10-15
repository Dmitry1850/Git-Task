using OpenCover.Framework.Model;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    private Text start_Text;

    [SerializeField]
    private GameObject zero;

    [SerializeField]
    private GameObject dagger;

    private ThisPlayer active_element = (byte)ThisPlayer.Zero;

    [SerializeField]
    private float[] pos_x;
    [SerializeField]
    private byte pos_y;
    [SerializeField]
    private float[] pos_z;

    private int[,] win_situations_array;

    private void IfPlayerClickButtoon(GameObject button, float pos_x, byte pos_y, float pos_z)
    {
        switch (active_element)
        {
            case ThisPlayer.Zero:
                Instantiate(zero, new Vector3(pos_x, pos_y, pos_z), Quaternion.Euler(0, 0, 0));
                zero.transform.localScale = new Vector3(1, 1, 1); 
                break;
            case ThisPlayer.Dagger:
                Instantiate(dagger, new Vector3(pos_x, pos_y, pos_z), Quaternion.Euler(0, 0, 0));
                dagger.transform.localScale = new Vector3(1, 1, 1);
                break;
        }

        if (active_element == ThisPlayer.Zero)
        {
            active_element = ThisPlayer.Dagger;
            active_Player.text = "Очередь игрока, играющего ноликами";
        }
        else
        {
            active_element = (byte)ThisPlayer.Zero;
            active_Player.text = "Очередь игрока, играющего крестиками";
        }

        if (start_Text.enabled) 
            start_Text.enabled = false;

        button.SetActive(false);
    }

    public void OnClickButton_1_1()
    {
        IfPlayerClickButtoon(buttons_array[0], pos_x[0], pos_y, pos_z[0]);
    }
    public void OnClickButton_1_2()
    {
        IfPlayerClickButtoon(buttons_array[1], pos_x[1], pos_y, pos_z[0]);
    }
    public void OnClickButton_1_3()
    {
        IfPlayerClickButtoon(buttons_array[2], pos_x[2], pos_y, pos_z[0]);
    }

    public void OnClickButton_2_1()
    {
        IfPlayerClickButtoon(buttons_array[3], pos_x[0], pos_y, pos_z[1]);
    }
    public void OnClickButton_2_2()
    {
        IfPlayerClickButtoon(buttons_array[4], pos_x[1], pos_y, pos_z[1]);
    }   
    public void OnClickButton_2_3()
    {
        IfPlayerClickButtoon(buttons_array[5], pos_x[2], pos_y, pos_z[1]);
    }

    public void OnClickButton_3_1()
    {
        IfPlayerClickButtoon(buttons_array[6], pos_x[0], pos_y, pos_z[2]);
    }
    public void OnClickButton_3_2()
    {
        IfPlayerClickButtoon(buttons_array[7], pos_x[1], pos_y, pos_z[2]);
    }
    public void OnClickButton_3_3()
    {
        IfPlayerClickButtoon(buttons_array[8], pos_x[2], pos_y, pos_z[2]);
    }
}
