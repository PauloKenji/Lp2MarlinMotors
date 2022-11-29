using System.ComponentModel.DataAnnotations;

namespace MarlinMotors.Models;

public class Venda
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(25)]
    public string TipoVeiculo { get; set; }

    [Required]
    [StringLength(25)]
    public string Marca { get; set; }

    [Required]
    [StringLength(25)]
    public string Modelo { get; set; }

    [Required]
    [StringLength(7)]
    public string Placa { get; set; }

    [Required]
    public int Ano { get; set; }

    [Required]
    [StringLength(50)]
    public string NomeCliente { get; set; }
    
    [Required]
    [StringLength(11)]
    public string CPFCliente { get; set; }

    public Venda() {}

    public Venda(
        int id, 
        string tipoVeiculo, 
        string marca, 
        string modelo, 
        string placa, 
        int ano, 
        string nomeCliente, 
        string cpfCliente
    )
    {
        Id = id;
        TipoVeiculo = tipoVeiculo;
        Marca = marca;
        Modelo = modelo;
        Placa = placa;
        Ano = ano;
        NomeCliente = nomeCliente;
        CPFCliente = cpfCliente;
    }
}