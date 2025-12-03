using System.Globalization;
using Discord;
using Library.BotCore.Interfaces;
using Library.Clases_principales;
using Library.Clases_tipos;
using Library.Fachadas;

namespace Library.BotCore.Comandos;

public class ListadoDisminucionVentaUsuarioConsignaC : IBotCommand
{
    public string Nombre { get; }
    public string Descripcion { get; }

    private BotCore _bot;
    private FachadaRegistro _fachada;
    //el constructor
    public ListadoDisminucionVentaUsuarioConsignaC(BotCore bot, FachadaRegistro fachada)
    {
        bot = _bot;
        fachada = _fachada;
    }

    public bool Ejecutar(IMessageContext contexto)
    {
        if (!_bot.Sesion.EstaLogeado || _bot.Sesion.Rol != "Usuario")
        {
            contexto.EnviarMensaje("❌ Solo un usuario puede listar disminucion de venta.");
            return false;
        }

        if (_bot.Sesion.UsuarioActual is Usuario usuario)
        {
            contexto.EnviarMensaje("vendedores");
            int Ventatotalmesa = 0;
            int Ventatotalmesb = 0;
            int contador = 2;
            while (contador != 0)
            {
                foreach (var v in _fachada.Vendedores)
                {
                    contexto.EnviarMensaje($"Vendedor: {v.Nombre}, Id: {v.Id}");
                
                    // DateTime mes_a = DateTime.Today;
                    // DateTime mes_b = DateTime.Today;
                
                    //Tendria que filtrar las ventas que suma por fecha pero no pude encontrar una manera de usar datetime y restarle 2 y 1 mes o de determinar expecificamente entre que fechas filtrar, basandose en la fecha actual.
                    //mi idea era hacer un while que permitiera recorer la lista 2 veces pero cambiando la fecha de 2 meses atras a 1, y luego sacar la diferencia.
                    foreach (var c in usuario.Clientes)
                    {
                        foreach (var venta in c.Ventas.ListaVentas)
                        {
                            Ventatotalmesa+=venta.Precio;
                        }
                    }
                }
                contador -= 1;
            }
            
            contexto.EnviarMensaje($"En el primer mes se gano: {Ventatotalmesa}");
            return true;
        }

        contexto.EnviarMensaje("Error inesperado.");
        return false;
    }
}