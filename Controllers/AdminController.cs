using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MarlinMotors.Models;

namespace MarlinMotors.Controllers;

public class AdminController : Controller
{    
    private readonly MarlinMotorsContext _context;

    public AdminController (MarlinMotorsContext context)
    {
        _context = context;
    }    

    public IActionResult Index()
    {
        return View();
    }
    // Vendas

    public IActionResult ListaVendas () => View(_context.Vendas);

    public IActionResult DeletarVenda(int id){
        _context.Vendas.Remove(_context.Vendas.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult VerVenda(int id)
    {
        Venda venda = _context.Vendas.Find(id);

        if(venda == null)
        {
            return RedirectToAction("ListaVendas");
        }

        return View(venda);
    }

    public IActionResult AtualizarVenda(int id){
        Venda venda = _context.Vendas.Find(id);

        if(venda == null)
        {
            return Content("Venda não existente, tente outro id");
        }
        else
        {
            return View(venda);
        }

    }

    [HttpPost]
    public IActionResult AtualizarVenda(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano,
        [FromForm] string nomeCliente, 
        [FromForm] string cpfCliente
        )
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Venda venda = _context.Vendas.Find(id);
        
        venda.Marca = marca;
        venda.Modelo = modelo;
        venda.Placa = placa;
        venda.Ano = ano;
        venda.NomeCliente = nomeCliente;
        venda.CPFCliente = cpfCliente;
        _context.SaveChanges();
        return RedirectToAction("ListaVendas");
    }

    //Cadastrar carro -------------------------------
    public IActionResult CadastroCarro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroCarro(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano
    )
    {
        if(!ModelState.IsValid){
            return View("CadastroCarro");
        }
        if(idIsAvaible(id)){
            string tipo = "carro";
            Carro carro = new Carro(id, marca, modelo, placa, ano, tipo);
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return RedirectToAction("CadastroCarro");
        }
        else
        {
            return Content("Veiculo já está cadastrado ou já foi vendido , tente outro id");
        }
    }

    public IActionResult VendaCarro(int id)
    {
        ViewData["Carro"] = _context.Carros.Find(id);
        return View();
    }

    [HttpPost]
    public IActionResult VendaCarro(
        [FromForm] int id, 
        [FromForm] string tipoVeiculo, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano,
        [FromForm] string nomeCliente,
        [FromForm] string cpfCliente
    )
    {
        if(!ModelState.IsValid){
            return View("ListaCarros");
        }
        if(_context.Vendas.Find(id) == null){
            Venda venda = new Venda(id, tipoVeiculo, marca, modelo, placa, ano, nomeCliente, cpfCliente);
            _context.Vendas.Add(venda);
            _context.Carros.Remove(_context.Carros.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return Content("Venda já existente, tente outro id");
        }
    }

    public IActionResult VerCarro(int id)
    {
        Carro carro = _context.Carros.Find(id);

        if(carro == null)
        {
            return RedirectToAction("ListaCarros");
        }

        return View(carro);
    }

    public IActionResult DeletarCarro(int id){
        _context.Carros.Remove(_context.Carros.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult AtualizarCarro(int id){
        Carro carro = _context.Carros.Find(id);

        if(carro == null)
        {
            return Content("Carro não existente, tente outro id");
        }
        else
        {
            return View(carro);
        }

    }

    [HttpPost]
    public IActionResult AtualizarCarro(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano)
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Carro carro = _context.Carros.Find(id);
        
        carro.Marca = marca;
        carro.Modelo = modelo;
        carro.Placa = placa;
        carro.Ano = ano;
        _context.SaveChanges();
        return RedirectToAction("ListaCarros");
    }

    public IActionResult ListaCarros () => View(_context.Carros);

    public bool idIsAvaible(int id){
        if(
            _context.Carros.Find(id) == null &&
            _context.Vendas.Find(id) == null
        ){
            return true;
        }
        else
        {
            return false;
        }
    
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}