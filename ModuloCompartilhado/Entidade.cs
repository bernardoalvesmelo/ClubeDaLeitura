namespace ClubeDaLeitura.ModuloCompartilhado
{
    public class Entidade
    {
        public int Id { get; protected set; }

        protected void obterId(ref int id)
        {
            id++;
            Id = id;
        }
    }
}
