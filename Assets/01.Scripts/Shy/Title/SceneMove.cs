using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public void SceneChangeToInt(int num)
    {
        Debug.Log(num + "�� �� �۵�");
        //SceneManager.LoadScene(num);
    }

    public void SceneChangeToString(string name)
    {
        Debug.Log(name + "�� �۵�");
        //SceneManager.LoadScene(name);
    }
}
