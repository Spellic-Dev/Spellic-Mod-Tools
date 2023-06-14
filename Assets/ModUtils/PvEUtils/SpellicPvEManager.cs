using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapUtils
{
    public class SpellicPvEManager : MonoBehaviour
    {
        public static SpellicPvEManager instance { get; private set; }

        [Header("Manager Settings")]
        [Tooltip("List of all areas in the map.")]
        [SerializeField] public List<SpellicPvEArea> areas;
        [Tooltip("Reference to the first area.")]
        [SerializeField] public SpellicPvEArea firstArea;
    }
}