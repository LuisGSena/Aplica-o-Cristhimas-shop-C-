using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalCsharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinalCsharp.Data;
namespace TrabalhoFinalCsharp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly BancoContext _context;
    public HomeController(ILogger<HomeController> logger, BancoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> IndexAsync()
    {
        return _context.Produtos != null ?
            View(await _context.Produtos.ToListAsync()) :
            Problem("Entity set 'BancoContext.Produtos'  is null.");
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult CadastroCliente()
    {
        return View();
    }

    public IActionResult CadastroFuncionario()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessarCadastroCliente([Bind("Id,EmailUsuario,NomeUsuario,SenhaUsuario,CPFUsuario, CEPUsuario, InformacoesBancarias")] ClienteModel clienteModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(clienteModel);
            await _context.SaveChangesAsync();
            TempData["MensagemCadastro"] = "Cadastro feito com sucesso!";
            return RedirectToAction("Login");
        }
        else
        {
            TempData["ErroCadastro"] = "Houve um erro ao processar o seu cadastro... Tente novamente mais tarde!";
            return RedirectToAction("Login");
        }
        
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProcessarCadastroFuncionario([Bind("Id,EmailUsuario,NomeUsuario,SenhaUsuario,CPFUsuario, CEPUsuario, StatusAdministrador")] FuncionarioModel funcionarioModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(funcionarioModel);
            await _context.SaveChangesAsync();
            TempData["MensagemCadastro"] = "Cadastro feito com sucesso!";
            return RedirectToAction("Login");
        }
        else
        {
            TempData["ErroCadastro"] = "Houve um erro ao processar o seu cadastro... Tente novamente mais tarde!";
            return RedirectToAction("Login");
        }
        
    }

    [HttpPost]
    public IActionResult ProcessarLogin(string email, string senha)
    {
        TempData["MensagemLogin"] = "Login feito com sucesso! Seja bem vindo!";
        TempData["ErroLogin"] = "Houve um erro ao processar o seu login... Tente novamente mais tarde!";
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
