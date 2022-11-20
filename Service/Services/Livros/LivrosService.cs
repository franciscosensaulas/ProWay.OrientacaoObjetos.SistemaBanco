using AutoMapper;
using Repository.Entities;
using Repository.Repositories.Livros;
using Service.Exceptions;
using Service.ViewModels.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Livros
{
    public class LivrosService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public LivrosService(
            ILivroRepository livroRepository,
            IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public LivroIndexViewModel Cadastrar(LivroCadastrarViewModel viewModel)
        {
            var livro = _mapper.Map<Livro>(viewModel);

            _livroRepository.Add(livro);

            return _mapper.Map<LivroIndexViewModel>(livro);
        }

        public List<LivroIndexViewModel> ObterTodos()
        {
            var livros = _livroRepository.GetAll();

            return livros
                .Select(x => new LivroIndexViewModel
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Preco = x.Preco,
                    Categoria = x.Categoria.Nome
                })
                .ToList();
        }


        public void Apagar(int id)
        {
            var livro = _livroRepository.GetById(id);

            if(livro == null)
            {
                throw new NotFoundException(nameof(Livro), id);
            }

            _livroRepository.Remove(livro);
        }

        public LivroEditarViewModel ObterPorId(int id)
        {
            var livro = _livroRepository.GetById(id);

            if (livro == null)
            {
                throw new NotFoundException(nameof(Livro), id);
            }

            return _mapper.Map<LivroEditarViewModel>(livro);
        }

        public void Editar(LivroEditarViewModel viewModel)
        {
            var livro = _livroRepository.GetById(viewModel.Id);

            if (livro == null)
            {
                throw new NotFoundException(nameof(Livro), viewModel.Id);
            }

            livro.Titulo = viewModel.Titulo;
            livro.Preco = viewModel.Preco.GetValueOrDefault();
            livro.QuantidadePaginas = viewModel.QuantidadePaginas.GetValueOrDefault();
            livro.CategoriaId = viewModel.CategoriaId.GetValueOrDefault();

            _livroRepository.Update(livro);
        }
    }
}
