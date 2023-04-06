﻿using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using Delivery.DAL.Interfaces;
using Delivery.DAL.Repositories;
using Delivery.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Delivery.Models;

namespace Delivery.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
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