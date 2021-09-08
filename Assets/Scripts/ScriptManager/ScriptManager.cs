using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoSingleton<ScriptManager>
{
    public static ScriptManager _Instance { get; private set; }

    public ScoreManager scoreManager;
    public CactusPool cactusPool;
    public RestartMenu restartMenu;
}
