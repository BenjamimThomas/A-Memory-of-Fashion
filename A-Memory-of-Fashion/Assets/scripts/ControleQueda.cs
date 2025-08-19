using UnityEngine;

public class ControleQueda : MonoBehaviour
{
    public BlocoCai[] blocos; // arraste aqui no inspetor todos os blocos

    public void SoltarTodos()
    {
        foreach (BlocoCai bloco in blocos)
        {
            bloco.Cair();
        }
    }
}