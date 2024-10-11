using Microsoft.EntityFrameworkCore;
using ProjetoEmMVC.Data;
using ProjetoEmMVC.Models;
using System.Data;

namespace ProjetoEmMVC.Services.EmprestimosService
{
    public class EmprestimosService : IEmprestimosInterface
    {
        private readonly CApplicationDbContext _context;
        public EmprestimosService(CApplicationDbContext context) 
        { 
           _context = context;  
        }

        public async Task<DataTable> BuscarEmprestimoExcel()
        {
            DataTable dataTable = new DataTable();

            dataTable.TableName = "Dados emprestimos";

            dataTable.Columns.Add("Recebedor", typeof(string));
            dataTable.Columns.Add("Fornecedor", typeof(string));
            dataTable.Columns.Add("Livro", typeof(string));
            dataTable.Columns.Add("Data ultima  atualizaçao", typeof(DateTime));

            var emprestimos = await BuscarEmprestimos();

            if (emprestimos.Dados.Count > 0)
            {
                emprestimos.Dados.ForEach(emprestimo =>
                {
                    dataTable.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivrosEmprestado, emprestimo.DataUltimaAtualizacao);
                });
            }

            return dataTable;
        }

        public async Task<ResponseModel<List<EmprestimosModel>>> BuscarEmprestimos()
        {
            ResponseModel<List<EmprestimosModel>> response = new ResponseModel<List<EmprestimosModel>>();

            try
            {

                var emprestimos = await _context.Emprestimos.ToListAsync();

                response.Dados = emprestimos;
                response.Mensagem = "Dados coletado com sucesso!";

                return response;

            }
            catch (Exception ex) 
            { 

                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            
            }
           
        }

        public async Task<ResponseModel<EmprestimosModel>> BuscarEmprestimosPorId(int? id)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {

                if (id == null) 
                {
                    response.Mensagem = "Emprestimo não localizadi";
                    response.Status = false;
                    return response;
                }

                var emprestimo = await _context.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);

                if (emprestimo == null)
                {
                    response.Mensagem = "Empréstimo não localizado!";
                    response.Status = false;
                    return response;
                }

                response.Dados = emprestimo;
                response.Mensagem = "Dados coletados com sucesso!";

                return response;

            }
            catch (Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
    
            }
        }

        public async Task<ResponseModel<EmprestimosModel>> CadastrarEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {
                _context.Add(emprestimosModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Cadastro realizado com secesso!";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmprestimosModel>> EditarEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {
                var emprestimo = await BuscarEmprestimosPorId(emprestimosModel.Id);

                if(emprestimo.Status == false)
                {
                    return emprestimo;
                }

                emprestimo.Dados.LivrosEmprestado = emprestimosModel.LivrosEmprestado;
                emprestimo.Dados.Fornecedor = emprestimosModel.Fornecedor;
                emprestimo.Dados.Recebedor = emprestimosModel.Recebedor;

                _context.Update(emprestimo.Dados);   
                await _context.SaveChangesAsync();

                response.Mensagem = "Edição realizado com sucesso!";

                return response;

            }
            catch (Exception ex)
            { 
                response.Mensagem= ex.Message;    
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmprestimosModel>> RemoveEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {

                _context.Remove(emprestimosModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Remoção realizada com sucessso!";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;    
                return response;
            }
        }
    }
}
