namespace series_gptstart5.Interfaces
{
    public interface IRepositorioSeries<T>
    {
        List<T> Lista();
        T RetornarPorId(int id);
        void Inserir(T objeto);
        void Excluir(int id);
        void Atualizar(int id, T objeto);
        int ProximoId();
    }
}