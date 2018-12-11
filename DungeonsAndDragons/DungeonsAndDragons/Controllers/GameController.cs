﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DungeonsAndDragons.Controllers
{
    public class GameController : Controller
    {
        private readonly DungeonsAndDragonsContext _context;

        public GameController(DungeonsAndDragonsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            //if (HttpContext.Session.GetString("username") == null)
            //{
            //    return Redirect("Home/Index");
            //}
            return View();
        }

        public IActionResult Create(string name, User user)
        {
            //if (HttpContext.Session.GetString("username") == null)
            //{
            //    return Redirect("Home/Index");
            //}
            _context.games.Add(new Game { name = name });
            _context.SaveChanges();
            return Redirect("Index");
        }
    }
}
