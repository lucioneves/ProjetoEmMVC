﻿using ProjetoEmMVC.Models;
using System.Data;

namespace ProjetoEmMVC.Services.EmprestimosService
{
    public interface IEmprestimosInterface
    {
        Task<ResponseModel<List<EmprestimosModel>>> BuscarEmprestimos();
        Task<ResponseModel<EmprestimosModel>> BuscarEmprestimosPorId(int? id);

        Task<ResponseModel<EmprestimosModel>> CadastrarEmprestimo(EmprestimosModel emprestimosModel);

        Task<ResponseModel<EmprestimosModel>> EditarEmprestimo(EmprestimosModel emprestimosModel);

        Task<ResponseModel<EmprestimosModel>> RemoveEmprestimo(EmprestimosModel emprestimosModel);

        Task<DataTable> BuscarEmprestimoExcel();
    }
}
