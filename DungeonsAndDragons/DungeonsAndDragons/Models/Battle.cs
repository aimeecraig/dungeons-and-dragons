﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndDragons.Models
{
    public class Battle : Interaction
    {         public int currentPlayerId { get; set; }         public NonPlayableCharacter NPC { get; set; }

        public static Battle StartBattle(DungeonsAndDragonsContext _context, int gameId, int npcId)
        {
            int dmId = _context.games.SingleOrDefault(x => x.id == gameId).id;
            NonPlayableCharacter npc = _context.nonplayablecharacters.SingleOrDefault(x => x.id == npcId);
            List<GameUser> gameUserResults = _context.gamesusers.Where(x => x.gameid == gameId & x.playablecharacterid != null).ToList();
            List<PlayableCharacter> players = new List<PlayableCharacter> { };

            foreach (var result in gameUserResults)
            {
                var player = _context.playablecharacters.SingleOrDefault(x => x.id == result.playablecharacterid);
                players.Add(player);
            }

            int currentPlayerId;
            if (players.Count == 0)
            {
                currentPlayerId = 0;
            }
            else
            {
                currentPlayerId = players.First().id;
            }

            var battle = new Battle() { gameId = gameId, dmId = dmId, NPC = npc, players = players, currentPlayerId = currentPlayerId };
            return battle;
        }

        public static void UpdateNpcHp(DungeonsAndDragonsContext _context, int npcId, int newHP)
        {
            var character = _context.nonplayablecharacters.Find(npcId);
            character.currentHp = newHP;
            _context.SaveChanges();
        }
    }
}
