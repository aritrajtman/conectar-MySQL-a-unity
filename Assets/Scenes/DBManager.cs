using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string usuario;
    public static int score;
    public static bool LoggedIn {get { return usuario != null; } }

    public static void LogOut()
    {
        usuario = null;
    }

}
