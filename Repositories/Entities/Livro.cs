namespace Repository.Entities
{
    public class Livro : EntityBase
    {
        public string Titulo { get; set; }
        public int CategoriaId { get; set; }
        public decimal Preco { get; set; }
        public ushort QuantidadePaginas { get; set; }
        public string Isbn { get; set; }

        public Categoria Categoria { get; set; }
    }
}
