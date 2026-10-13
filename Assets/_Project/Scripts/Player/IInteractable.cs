using UnityEngine;

public interface IInteractable
{
    bool CanInteract(Player p);
    // onFinished se llama cuando la interacción termina (ej. fin del diálogo)
    void BeginInteract(Player p, System.Action onFinished);
    // Se llama si la interacción se corta desde fuera (daño, muerte)
    void CancelInteract(Player p);
}
