using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneChangeToInt(int num)
    {
        Debug.Log(num + "¹ø ¾À ÀÛµ¿");
        //SceneManager.LoadScene(num);
    }

    public void SceneChangeToString(string name)
    {
        Debug.Log(name + "¾À ÀÛµ¿");
        //SceneManager.LoadScene(name);
    }
}
