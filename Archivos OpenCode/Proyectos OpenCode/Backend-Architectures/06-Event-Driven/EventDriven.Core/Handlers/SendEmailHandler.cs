namespace EventDriven.Core.Handlers;

public static class SendEmailHandler
{
    public static void Handle(string customerEmail, int orderId, decimal total)
    {
        Console.WriteLine($"[EMAIL] Enviando correo a {customerEmail}...");
        Console.WriteLine($"[EMAIL] Confirmación de orden #{orderId} por ${total:F2}");
        Console.WriteLine($"[EMAIL] Correo enviado correctamente.");
    }
}
