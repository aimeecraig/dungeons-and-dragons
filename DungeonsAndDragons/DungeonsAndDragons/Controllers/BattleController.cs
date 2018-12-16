﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DungeonsAndDragons.Hubs;
using DungeonsAndDragons.Models;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DungeonsAndDragons.Controllers
{
    public class BattleController : Controller
    {
        private readonly IHubContext<DnDHub> _hubcontext;
        private readonly DungeonsAndDragonsContext _context;

        public BattleController(DungeonsAndDragonsContext context, IHubContext<DnDHub> hubcontext)
        {
            _context = context;
            _hubcontext = hubcontext;
        }

        public void Create(int gameid)
        {
            _hubcontext.Clients.Group(gameid.ToString()).SendAsync("StartBattleRedirect", gameid);
        }

        public void End(int gameid)
        {
            _hubcontext.Clients.Group(gameid.ToString()).SendAsync("EndBattleRedirect", gameid);
        }

        public IActionResult View(int id)
        {
            //TODO:
            //Create new instance of Battle - view need to pass this route all required variables
            //Redirect logged out users
            //Redirect users that are not part of this game

            @ViewBag.gameid = id;
            return View();
        }
    }
}
