using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unifisio_Api.DTOs;

public interface IRelatorioProdutividadeService
{
    Task<List<RelatorioProdutividadeDTO>> ObterRelatorioProdutividadeAsync(DateTime inicio, DateTime fim);
}
