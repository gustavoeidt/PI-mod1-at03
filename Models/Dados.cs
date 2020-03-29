/****
Classes estáticas não precisam ser instanciadas.
No ASP.NET Core MVC, classes estáticas vivem do início 
ao fim da execução do programa.
Por isso, Dados deve ser usado para manipular as informações
dos pedidos.
Exemplos de uso:
Dados.PedidoAtual.PropriedadeDePedido = "Algum Valor";
Dados.PedidoAtual.MetodoDePedido();
*****/

using System.Collections.Generic;

namespace at03.Models
{
    public static class Dados{
        public static List<Edital> editais {get; set;}
        public static List<Noticia> noticias {get; set;}
        static Dados()
        { 
            editais = new List<Edital>();
            noticias = new List<Noticia>();
        }

        public static void incluirEdital(Edital edital)
        {
            editais.Add(edital);
        }

        public static List<Edital> listarEditais()
        {
            return editais;
        }

        public static void incluirNoticia(Noticia noticia)
        {
            noticias.Add(noticia);
        }

        public static List<Noticia> listarNoticias()
        {
            return noticias;
        }
    }
}