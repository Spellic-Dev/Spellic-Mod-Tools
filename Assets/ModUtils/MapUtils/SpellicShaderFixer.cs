using UnityEngine;

namespace MapUtils
{
    /// <summary>
    /// Add this to your rootobjects if they arent rendered correctly.
    /// There is a bug in unity that Addressable Bundels won't ship builtin shaders correctly.
    /// </summary>
    public class SpellicShaderFixer : MonoBehaviour  { }
}