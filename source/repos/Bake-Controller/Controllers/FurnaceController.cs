using Bake_Controller.Data;
using Bake_Controller.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

//public class FurnaceController : Controller
//{
//    // Dados simulados, sem dependência do ApplicationDbContext
//    private static List<FurnaceRecord> _mockData = new List<FurnaceRecord>
//    {
//        new FurnaceRecord { Id = 1, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-15), Usuario = "André", Matricula=12345, Email = "andre_azevedo@jabil.com" },
//        new FurnaceRecord { Id = 2, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-2), Usuario = "Caroline", Matricula=12345, Email = "carol@jabil.com" },
//        new FurnaceRecord { Id = 3, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-20), Usuario = "Ciclano", Matricula = 12345, Email = "jose@jabil.com" },
//        new FurnaceRecord { Id = 4, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-10), Usuario = "Fulano", Matricula=12345, Email = "fulano@jabil.com" }
//    };

//    public IActionResult Control()
//    {
//        foreach (var item in _mockData)
//        {
//            item.Turno = item.CalcularTurno(item.HoraInicio);
//        }

//        // Retorna os dados mockados para a view
//        return View(_mockData);
//    }

//    [HttpPost]
//    public IActionResult RetirarDoForno(int id, string login)
//    {
//        var placa = _mockData.FirstOrDefault(p => p.Id == id);

//        if (placa != null)
//        {
//            placa.HoraFim = DateTime.Now;
//            placa.LoginRetirada = login;
//            //sem salvar no banco ainda, esta sendo salvo em cache
//        }

//        return RedirectToAction("Control");
//    }
//}



public class FurnaceController : Controller
{
    // Dados mockados para simulação
    private static List<FurnaceRecord> _mockData = new List<FurnaceRecord>
    {
        new FurnaceRecord { Id = 1, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-15), Usuario = "André", Matricula=12345, Email = "andre_azevedo@jabil.com" },
        new FurnaceRecord { Id = 2, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-2), Usuario = "Caroline", Matricula=12345, Email = "carol@jabil.com" },
        new FurnaceRecord { Id = 3, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-20), Usuario = "Ciclano", Matricula = 12345, Email = "jose@jabil.com" },
        new FurnaceRecord { Id = 4, PlacaId = "A123", Cliente="Fibocom", HoraInicio = DateTime.Now.AddHours(-10), Usuario = "Fulano", Matricula=12345, Email = "fulano@jabil.com" }
    };

    public IActionResult Control()
    {
        foreach (var item in _mockData)
        {
            item.Turno = item.CalcularTurno(item.HoraInicio);
        }

        return View(_mockData);
    }

    [HttpPost]
    public IActionResult RetirarDoForno(int id, string login)
    {
        var placa = _mockData.FirstOrDefault(p => p.Id == id);

        if (placa != null)
        {
            placa.HoraFim = DateTime.Now;
            placa.LoginRetirada = login;
        }


        // Atualizar a lista para refletir as mudanças
        _mockData = _mockData.Where(p => p.HoraFim == null).ToList();

        // Redireciona para a página "Retirados" após a retirada
        return RedirectToAction("Retirados");
    }

    public IActionResult Retirados()
    {
        var itensRetirados = _mockData.Where(p => p.HoraFim != null).ToList();
        return View("Retirados", itensRetirados);
    }



}
