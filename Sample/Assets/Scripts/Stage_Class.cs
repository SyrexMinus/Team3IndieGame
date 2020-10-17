using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Class : MonoBehaviour
{
    public class Stage
    {
        public float delay;
        public int duration;
        public int id_current;
        public int id_next;

        // Class for stages ( delay between monster spawns, duration of level, ID of current level, ID of next level)
        public Stage (float del, int dur, int id_c, int id_n)
            {
                delay = del;
                duration = dur;
                id_current = id_c;
                id_next = id_n;
            }

    }

}
