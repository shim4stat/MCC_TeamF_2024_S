using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStomp : MonoBehaviour
{
    [SerializeField] private double Threthold;
    private List<Joycon> m_joycons;
    private Joycon m_joyconL;
    private Joycon m_joyconR;
    bool on_cooldown;
    double cooldown;
    // Start is called before the first frame update
    void Start()
    {
        m_joycons = JoyconManager.Instance.j;
    }

    // Update is called once per frame
    void Update()
    {
        if (on_cooldown)
        {
            cooldown += Time.deltaTime;
            if(cooldown > Threthold)
            {
                cooldown = 0;
                on_cooldown = false;
            }
        }
        if(!on_cooldown)
            foreach(var joycon in m_joycons)
            {
                var accel = joycon.GetAccel();
                if (accel[0] > 4.0)
                {
                    Debug.Log("Stomp");
                    on_cooldown = true;
                }
            }
    }
}
