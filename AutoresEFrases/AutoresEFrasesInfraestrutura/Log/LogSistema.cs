using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using System.Text;

namespace AplicacaoWeb01Infraestrutura.Log;

public class LogSistema : ILogSistema
{
    public void EscreverLog(string log)
    {
        using (StreamWriter writer = new StreamWriter("C:\\Users\\compu\\Downloads\\Exception.txt", true, Encoding.UTF8))
        {
            writer.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} : {log}");
            writer.WriteLine($"-------------------------------------------------------------");
        }
    }
}
