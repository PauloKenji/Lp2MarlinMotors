using System.ComponentModel.DataAnnotations;

namespace MarlinMotors.Models;

public class Moto
{
    [Required]
    public int Id { get; set; }

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

    public string Tipo { get; set; }

    public Moto() {}

    public Moto(int id, string marca, string modelo, string placa, int ano, string tipo)
    {
        Id = id;
        Marca = marca;
        Modelo = modelo;
        Placa = placa;
        Ano = ano;
        Tipo = tipo;
    }
}