namespace Repository.Entities
{
    public class Categoria : EntityBase
    {
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
