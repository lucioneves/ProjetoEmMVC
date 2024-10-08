using System.ComponentModel.DataAnnotations;

namespace ProjetoEmMVC.Models
{
    //Tabela de emprestimo de livros.
    public class EmprestimosModel
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do recebedor!")]
        public string Recebedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do fornecedor!")]
        public string Fornecedor { get; set; }
        [Required(ErrorMessage = "Digite o nome do livro!")]
        public string LivrosEmprestado { get; set; }


        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
