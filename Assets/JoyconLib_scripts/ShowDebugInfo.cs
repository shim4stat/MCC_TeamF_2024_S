using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ShowDebugInfo : MonoBehaviour
{
    private static readonly Joycon.Button[] m_buttons =
        Enum.GetValues(typeof(Joycon.Button)) as Joycon.Button[];

    private List<Joycon> m_joycons;
    //private Joycon m_joyconL;
    //private Joycon m_joyconR;
    [SerializeField] private TMP_Text TMPText;

    private void Start()
    {
        m_joycons = JoyconManager.Instance.j;

        if (m_joycons == null || m_joycons.Count <= 0) return;

        //m_joyconL = m_joycons.Find(c => c.isLeft);
        //m_joyconR = m_joycons.Find(c => !c.isLeft);
        TMPText.SetText("Test");
    }

    private void Update()
    {
        string info = "";
        if (m_joycons == null || m_joycons.Count <= 0)
            {
                info += "Joy-Con Not Connected\n";
            }

            if (!m_joycons.Any(c => c.isLeft))
            {
            info += "Joy-Con Left Not Connected\n";
            }

            if (!m_joycons.Any(c => !c.isLeft))
            {
                info += "Joy-Con Right Not Connected\n";
            }

            foreach (var joycon in m_joycons)
            {
                var isLeft = joycon.isLeft;
                var name = isLeft ? "Joy-Con(L)" : "Joy-Con(R)";
                var gyro = joycon.GetGyro();
                var accel = joycon.GetAccel();
                var orientation = joycon.GetVector();

            info += name + '\n';
                info += "Gyro:" + gyro + '\n';
                info += "Accel(x10):" + accel * 10 + '\n';
                info += "Orientation:" + orientation + '\n';
            }
        if (info == "")
            info = "No Info";
        TMPText.SetText(info);
    }
}