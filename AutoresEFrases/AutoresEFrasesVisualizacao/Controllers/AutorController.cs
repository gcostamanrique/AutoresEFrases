using AutoresEFrasesAplicacao.DTOsMapeamento;
using AutoresEFrasesAplicacao.DTOs;
using AutoresEFrasesDominio.Enumeracoes;
using AutoresEFrasesDominio.Interfaces.InterfacesAplicacao;
using AutoresEFrasesDominio.Interfaces.InterfacesInfraestrutura;
using Microsoft.AspNetCore.Mvc;

namespace AutoresEFrasesVisualizacao.Controllers;

public class AutorController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServico _servico;
    private readonly ILogSistema _logSistema;

    public AutorController(IUnitOfWork unitOfWork, IServico servico, ILogSistema logSistema)
    {
        _unitOfWork = unitOfWork;
        _servico = servico;
        _logSistema = logSistema;
    }

    public IActionResult Index() 
    { 
        return View("PesquisarAutor"); 
    }

    public IActionResult PesquisarAutor() 
    { 
        return View(); 
    }

    public IActionResult IncluirAutor() 
    { 
        return View(); 
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> GETAutor([FromBody] GETAutorDTO requisicaoAutor)
    {
        try
        {
            var autores = await _unitOfWork.AutorRepositorio.BuscarAutorAsync();

            if (requisicaoAutor.id != null)
            {
                autores = autores.Where(r => r.id == requisicaoAutor.id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoAutor.nome))
            {
                autores = autores.Where(r => r.nome.Contains(requisicaoAutor.nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoAutor.sobrenome))
            {
                autores = autores.Where(r => r.sobrenome.Contains(requisicaoAutor.sobrenome, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return StatusCode(200, autores.ParaColecaoAutorDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return StatusCode(500, "Erro na requisicao");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> GETAutorEFrase([FromBody] GETAutorDTO requisicaoAutor)
    {
        try
        {
            var autores = await _unitOfWork.AutorRepositorio.BuscarAutorEFraseAsync();

            if (requisicaoAutor.id != null)
            {
                autores = autores.Where(r => r.id == requisicaoAutor.id).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoAutor.nome))
            {
                autores = autores.Where(r => r.nome.Contains(requisicaoAutor.nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(requisicaoAutor.sobrenome))
            {
                autores = autores.Where(r => r.sobrenome.Contains(requisicaoAutor.sobrenome, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return StatusCode(200, autores.ParaColecaoAutorEFraseDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return StatusCode(500, "Erro na requisicao");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> POSTAutor([FromBody] POSTAutorDTO requisicaoAutor)
    {
        try
        {
            var autor = requisicaoAutor.ParaAutor();

            autor = _servico.ModificarAutor(autor, TipoModificacaoAutor.GerarComplementoAutor);

            _unitOfWork.AutorRepositorio.Criar(autor);

            await _unitOfWork.Efetivar();

            return StatusCode(200, autor.ParaAutorDTO());
        }
        catch (Exception ex)
        {
            _logSistema.EscreverLog(ex.Message);
            return StatusCode(500, "Erro na requisicao");
        }

    }
}
