using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;
using Unifisio_Api.Repository.Interface;

public class RelatorioProdutividadeService : IRelatorioProdutividadeService
{
    private readonly IRelatorioRepository _repository;

    public RelatorioProdutividadeService(IRelatorioRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RelatorioProdutividadeDTO>> ObterRelatorioProdutividadeAsync(DateTime inicio, DateTime fim)
    {
        return await _repository.ObterRelatorioProdutividadeAsync(inicio, fim);
    }
}
