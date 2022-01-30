using System;
using System.Collections.Generic;
using AppCadastro.src.Interfaces;

namespace AppCadastro.src.Classes
{
    public class GameRepository : IRepository<Game>
	{
        private List<Game> GameList = new List<Game>();
		public void Update(int id, Game objeto)
		{
			GameList[id] = objeto;
		}

		public void Delete(int id)
		{
			GameList[id].Delete();
		}

		public void Insert(Game objeto)
		{
			GameList.Add(objeto);
		}

		public List<Game> List()
		{
			return GameList;
		}

		public int NextId()
		{
			return GameList.Count;
		}

		public Game ReturnById(int id)
		{
			return GameList[id];
		}
	}
}