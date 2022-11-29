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

      //Cadastrar Moto -------------------------------
    public IActionResult CadastroMoto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroMoto(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano
    )
    {
        if(!ModelState.IsValid){
            return View("CadastroMoto");
        }
        if(idIsAvaible(id)){
            string tipo = "moto";
            Moto moto = new Moto(id, marca, modelo, placa, ano, tipo);
            _context.Motos.Add(moto);
            _context.SaveChanges();
            return RedirectToAction("CadastroMoto");
        }
        else
        {
            return Content("Veiculo já está cadastrado ou já foi vendido , tente outro id");
        }
    }

    public IActionResult VendaMoto(int id)
    {
        ViewData["Moto"] = _context.Motos.Find(id);
        return View();
    }

    [HttpPost]
    public IActionResult VendaMoto(
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
            return View("ListaMotos");
        }
        if(_context.Vendas.Find(id) == null){
            Venda venda = new Venda(id, tipoVeiculo, marca, modelo, placa, ano, nomeCliente, cpfCliente);
            _context.Vendas.Add(venda);
            _context.Motos.Remove(_context.Motos.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return Content("Venda já existente, tente outro id");
        }
    }

    public IActionResult VerMoto(int id)
    {
        Moto moto = _context.Motos.Find(id);

        if(moto == null)
        {
            return RedirectToAction("ListaMotos");
        }

        return View(moto);
    }

    public IActionResult DeletarMoto(int id){
        _context.Motos.Remove(_context.Motos.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult AtualizarMoto(int id){
        Moto moto = _context.Motos.Find(id);

        if(moto == null)
        {
            return Content("moto não existente, tente outro id");
        }
        else
        {
            return View(moto);
        }

    }

    [HttpPost]
    public IActionResult AtualizarMoto(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano)
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Moto moto = _context.Motos.Find(id);
        
        moto.Marca = marca;
        moto.Modelo = modelo;
        moto.Placa = placa;
        moto.Ano = ano;
        _context.SaveChanges();
        return RedirectToAction("ListaMotos");
    }

    public IActionResult ListaMotos () => View(_context.Motos);

    //Cadastrar Moto -------------------------------


    //Cadastrar Van -------------------------------
    public IActionResult CadastroVan()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroVan(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano
    )
    {
        if(!ModelState.IsValid){
            return View("CadastroVan");
        }
        if(idIsAvaible(id)){
            string tipo = "van";
            Van van = new Van(id, marca, modelo, placa, ano, tipo);
            _context.Vans.Add(van);
            _context.SaveChanges();
            return RedirectToAction("CadastroVan");
        }
        else
        {
            return Content("Veiculo já existente, tente outro id");
        }
    }

    public IActionResult VendaVan(int id)
    {
        ViewData["Van"] = _context.Vans.Find(id);
        return View();
    }

    [HttpPost]
    public IActionResult VendaVan(
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
            return View("ListaVans");
        }
        if(_context.Vendas.Find(id) == null){
            Venda venda = new Venda(id, tipoVeiculo, marca, modelo, placa, ano, nomeCliente, cpfCliente);
            _context.Vendas.Add(venda);
            _context.Vans.Remove(_context.Vans.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return Content("Veiculo já está cadastrado ou já foi vendido , tente outro id");
        }
    }

    public IActionResult VerVan(int id)
    {
        Van van = _context.Vans.Find(id);

        if(van == null)
        {
            return RedirectToAction("ListaVan");
        }

        return View(van);
    }

    public IActionResult DeletarVan(int id){
        _context.Vans.Remove(_context.Vans.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult AtualizarVan(int id){
        Van van = _context.Vans.Find(id);

        if(van == null)
        {
            return Content("van não existente, tente outro id");
        }
        else
        {
            return View(van);
        }

    }

    [HttpPost]
    public IActionResult AtualizarVan(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano)
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Van van = _context.Vans.Find(id);
        
        van.Marca = marca;
        van.Modelo = modelo;
        van.Placa = placa;
        van.Ano = ano;
        _context.SaveChanges();
        return RedirectToAction("ListaVans");
    }

    public IActionResult ListaVans () => View(_context.Vans);

    //Cadastrar Van -------------------------------

    //Cadastrar Caminhão -------------------------------

    public IActionResult CadastroCaminhao()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroCaminhao(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano
    )
    {
        if(!ModelState.IsValid){
            return View("CadastroCaminhao");
        }
        if(idIsAvaible(id)){
            string tipo = "caminhao";
            Caminhao caminhao = new Caminhao(id, marca, modelo, placa, ano, tipo);
            _context.Caminhoes.Add(caminhao);
            _context.SaveChanges();
            return RedirectToAction("CadastroCaminhao");
        }
        else
        {
            return Content("Veiculo já está cadastrado ou já foi vendido , tente outro id");
        }
    }

    public IActionResult VendaCaminhao(int id)
    {
        ViewData["Caminhao"] = _context.Caminhoes.Find(id);
        return View();
    }

    [HttpPost]
    public IActionResult VendaCaminhao(
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
            return View("ListaCaminhoes");
        }
        if(_context.Vendas.Find(id) == null){
            Venda venda = new Venda(id, tipoVeiculo, marca, modelo, placa, ano, nomeCliente, cpfCliente);
            _context.Vendas.Add(venda);
            _context.Caminhoes.Remove(_context.Caminhoes.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return Content("Venda já existente, tente outro id");
        }
    }

    public IActionResult VerCaminhao(int id)
    {
        Caminhao caminhao = _context.Caminhoes.Find(id);

        if(caminhao == null)
        {
            return RedirectToAction("ListaCaminhoes");
        }

        return View(caminhao);
    }

    public IActionResult DeletarCaminhao(int id){
        _context.Caminhoes.Remove(_context.Caminhoes.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult AtualizarCaminhao(int id){
        Caminhao caminhao = _context.Caminhoes.Find(id);

        if(caminhao == null)
        {
            return Content("caminhão não existente, tente outro id");
        }
        else
        {
            return View(caminhao);
        }

    }

    [HttpPost]
    public IActionResult AtualizarCaminhao(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano)
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Caminhao caminhao = _context.Caminhoes.Find(id);
        
        caminhao.Marca = marca;
        caminhao.Modelo = modelo;
        caminhao.Placa = placa;
        caminhao.Ano = ano;
        _context.SaveChanges();
        return RedirectToAction("ListaCaminhoes");
    }

    public IActionResult ListaCaminhoes () => View(_context.Caminhoes);

    //Cadastrar Caminhão -------------------------------

    //Cadastrar Ônibus -------------------------------

    public IActionResult CadastroOnibus()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CadastroOnibus(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano
    )
    {
        if(!ModelState.IsValid){
            return View("CadastroOnibus");
        }
        if(idIsAvaible(id)){
            string tipo = "onibus";
            Onibus onibus = new Onibus(id, marca, modelo, placa, ano, tipo);
            _context.Onibuss.Add(onibus);
            _context.SaveChanges();
            return RedirectToAction("CadastroOnibus");
        }
        else
        {
            return Content("Veiculo já está cadastrado ou já foi vendido , tente outro id");
        }
    }

    public IActionResult VendaOnibus(int id)
    {
        ViewData["onibus"] = _context.Onibuss.Find(id);
        return View();
    }

    [HttpPost]
    public IActionResult VendaOnibus(
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
            return View("ListaOnibuss");
        }
        if(_context.Vendas.Find(id) == null){
            Venda venda = new Venda(id, tipoVeiculo, marca, modelo, placa, ano, nomeCliente, cpfCliente);
            _context.Vendas.Add(venda);
            _context.Onibuss.Remove(_context.Onibuss.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return Content("Venda já existente, tente outro id");
        }
    }

    public IActionResult VerOnibus(int id)
    {
        Onibus onibus = _context.Onibuss.Find(id);

        if(onibus == null)
        {
            return RedirectToAction("ListaOnibus");
        }

        return View(onibus);
    }

    public IActionResult DeletarOnibus(int id){
        _context.Onibuss.Remove(_context.Onibuss.Find(id));
        _context.SaveChanges();
        return View("Index");
    }

    public IActionResult AtualizarOnibus(int id){
        Onibus onibus = _context.Onibuss.Find(id);

        if(onibus == null)
        {
            return Content("Ônibus não existente, tente outro id");
        }
        else
        {
            return View(onibus);
        }

    }

    [HttpPost]
    public IActionResult AtualizarOnibus(
        [FromForm] int id, 
        [FromForm] string marca, 
        [FromForm] string modelo, 
        [FromForm] string placa, 
        [FromForm] int ano)
    {
        
        if(!ModelState.IsValid){
            return View();
        }
        Onibus onibus = _context.Onibuss.Find(id);
        
        onibus.Marca = marca;
        onibus.Modelo = modelo;
        onibus.Placa = placa;
        onibus.Ano = ano;
        _context.SaveChanges();
        return RedirectToAction("ListaOnibuss");
    }

    public IActionResult ListaOnibuss () => View(_context.Onibuss);

    //Cadastrar Ônibus -------------------------------

    public bool idIsAvaible(int id){
        if(
            _context.Carros.Find(id) == null &&
            _context.Vans.Find(id) == null &&
            _context.Motos.Find(id) == null &&
            _context.Caminhoes.Find(id) == null &&
            _context.Onibuss.Find(id) == null &&
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