using System;
using AppCadastro.src.Enums;

namespace AppCadastro.src.Classes
{
    public class Game
    {
        // Atributos
        private int Id { get; set; }
		private Gender Genero { get; set; }
		private string Title { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Métodos
		public Game(int id, Gender genero, string title, string description, int year)
		{
			this.Id = id;
			this.Genero = genero;
			this.Title = title;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
        {
            string retorne = "";
            retorne += "Gênero: " + this.Genero + Environment.NewLine;
            retorne += "Titulo: " + this.Title + Environment.NewLine;
            retorne += "Descrição: " + this.Description + Environment.NewLine;
            retorne += "Ano de Início: " + this.Year + Environment.NewLine;
            retorne += "Excluido: " + this.Deleted;
			return retorne;
		}

        public string ReturnTitle()
		{
			return this.Title;
		}

		public int ReturnId()
		{
			return this.Id;
		}
        public bool ReturnDeleted()
		{
			return this.Deleted;
		}
        public void Delete() {
            this.Deleted = true;
        }
    }
}