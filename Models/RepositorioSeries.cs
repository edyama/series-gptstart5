using series_gptstart5.Interfaces;

namespace series_gptstart5.Models
{
    public class RepositorioSeries : IRepositorioSeries<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualizar(int id, Series objeto)
        {
           listaSerie[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Inserir(Series objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornarPorId(int id)
        {
            return listaSerie[id];
        }
    }
}