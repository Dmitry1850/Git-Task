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
    private GameObject Won_Panel;

    [SerializeField]
    private GameObject Zero_Won;

    [SerializeField]
    private GameObject Dagger_Won;

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

    private byte[,] win_situations_array = new byte[3, 3] { { 3, 4, 5}, { 6, 7, 8}, { 9, 10, 11} };

    private void CheckWinSituations(byte[,] win_situations_array, ThisPlayer active_element)
    {
        if ((win_situations_array[0, 0] == win_situations_array[0, 1] && win_situations_array[0, 1] == win_situations_array[0, 2]) ||
            (win_situations_array[1, 0] == win_situations_array[1, 1] && win_situations_array[1, 1] == win_situations_array[1, 2]) ||
            (win_situations_array[2, 0] == win_situations_array[2, 1] && win_situations_array[2, 1] == win_situations_array[2, 2]) ||

            (win_situations_array[0, 0] == win_situations_array[1, 0] && win_situations_array[1, 0] == win_situations_array[2, 0]) ||
            (win_situations_array[0, 1] == win_situations_array[1, 1] && win_situations_array[1, 1] == win_situations_array[2, 1]) ||
            (win_situations_array[0, 2] == win_situations_array[1, 2] && win_situations_array[1, 2] == win_situations_array[2, 2]) ||

            (win_situations_array[0, 0] == win_situations_array[1, 1] && win_situations_array[1, 1] == win_situations_array[2, 2]) ||
            (win_situations_array[0, 2] == win_situations_array[1, 1] && win_situations_array[1, 1] == win_situations_array[2, 0]))

        {
            Won_Panel.SetActive(true);

            if (active_element == ThisPlayer.Zero)
                Zero_Won.SetActive(true);
            else if (active_element == ThisPlayer.Dagger)
                Dagger_Won.SetActive(true);
        }
    }
    private void IfPlayerClickButtoon(GameObject button, float pos_x, byte pos_y, float pos_z, byte situations_x, byte situations_y)
    {
        switch (active_element)
        {
            case ThisPlayer.Zero:
                win_situations_array[situations_x, situations_y] = (byte)ThisPlayer.Zero;
                CheckWinSituations(win_situations_array, active_element);
                Instantiate(zero, new Vector3(pos_x, pos_y, pos_z), Quaternion.Euler(0, 0, 0));
                zero.transform.localScale = new Vector3(1, 1, 1);
                break;
            case ThisPlayer.Dagger:
                win_situations_array[situations_x, situations_y] = (byte)ThisPlayer.Dagger;
                CheckWinSituations(win_situations_array, active_element);
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
        IfPlayerClickButtoon(buttons_array[0], pos_x[0], pos_y, pos_z[0], 0, 0);
    }
    public void OnClickButton_1_2()
    {
        IfPlayerClickButtoon(buttons_array[1], pos_x[1], pos_y, pos_z[0], 0, 1);
    }
    public void OnClickButton_1_3()
    {
        IfPlayerClickButtoon(buttons_array[2], pos_x[2], pos_y, pos_z[0], 0, 2);
    }

    public void OnClickButton_2_1()
    {
        IfPlayerClickButtoon(buttons_array[3], pos_x[0], pos_y, pos_z[1], 1, 0);
    }
    public void OnClickButton_2_2()
    {
        IfPlayerClickButtoon(buttons_array[4], pos_x[1], pos_y, pos_z[1], 1, 1);
    }   
    public void OnClickButton_2_3()
    {
        IfPlayerClickButtoon(buttons_array[5], pos_x[2], pos_y, pos_z[1], 1, 2);
    }

    public void OnClickButton_3_1()
    {
        IfPlayerClickButtoon(buttons_array[6], pos_x[0], pos_y, pos_z[2], 2, 0);
    }
    public void OnClickButton_3_2()
    {
        IfPlayerClickButtoon(buttons_array[7], pos_x[1], pos_y, pos_z[2], 2, 1);
    }
    public void OnClickButton_3_3()
    {
        IfPlayerClickButtoon(buttons_array[8], pos_x[2], pos_y, pos_z[2], 2, 2);
    }
}
