using AutoresEFrasesAplicacao.DTOsMapeamento;
using AutoresEFrasesAplicacao.DTOs;
using AutoresEFrasesDominio.Enumeracoes;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace AutoresEFrasesVisualizacao.Controllers;

public class FraseController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServico _servico;
    private readonly ILogSistema _logSistema;

    public FraseController(IUnitOfWork unitOfWork, IServico servico, ILogSistema logSistema)
    {
        _unitOfWork = unitOfWork;
        _servico = servico;
        _logSistema = logSistema;
    }

    public IActionResult Index() 
    { 
        return View("PesquisarFrase"); 
    }

    public IActionResult PesquisarFrase() 
    { 
        return View(); 
    }

    public IActionResult IncluirFrase() 
    { 
        return View(); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> GETFrase([FromBody] GETFraseDTO requisicaoFrase)
    {
        try
        {
            var frases = await _unitOfWork.FraseRepositorio.BuscarFraseAsync();

            if (requisicaoFrase.id != null)
            {
                frases = frases.Where(r => r.id == requisicaoFrase.id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoFrase.frase))
            {
                frases = frases.Where(r => r.frase.Contains(requisicaoFrase.frase, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return StatusCode(200, frases.ParaColecaoFraseDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return BadRequest("Erro na requisicao");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> GETFraseEAutor([FromBody] GETFraseDTO requisicaoFrase)
    {
        try
        {
            var frases = await _unitOfWork.FraseRepositorio.BuscarFraseEAutorAsync();

            if (requisicaoFrase.id != null)
            {
                frases = frases.Where(r => r.id == requisicaoFrase.id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoFrase.frase))
            {
                frases = frases.Where(r => r.frase.Contains(requisicaoFrase.frase, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return Ok(frases.ParaColecaoFraseEAutorDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return StatusCode(500, "Erro na requisicao");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> POSTFrase([FromBody] POSTFraseDTO requisicaoFrase)
    {
        try
        {
            var frase = requisicaoFrase.ParaFrase();

            frase = _servico.ModificarFrase(frase, TipoModificacaoFrase.GerarComplementoFrase);

            _unitOfWork.FraseRepositorio.Criar(frase);

            await _unitOfWork.Efetivar();

            return StatusCode(200, frase.ParaFraseDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return StatusCode(500, "Erro na requisicao");
        }

    }
}
