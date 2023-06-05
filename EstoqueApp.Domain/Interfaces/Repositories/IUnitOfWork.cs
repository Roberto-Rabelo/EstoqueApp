using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApp.Domain.Interfaces.Repositories
{
    public  interface IUnitOfWork : IDisposable
    {
        IEstoqueRepository EstoqueRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        // Criando unica conexão para os repository e contexto 

        void SaveChanges();
    }
}
