using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleQueda : MonoBehaviour
{
    public BlocoCai[] blocos;


    public void SoltarTodos()
    {
        foreach (BlocoCai bloco in blocos)
        {
            bloco.Cair();
        }
    }
}
