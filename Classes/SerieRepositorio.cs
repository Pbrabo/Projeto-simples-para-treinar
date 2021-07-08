using System;
using System.Collections.Generic;
using First.Project.Interfaces;

namespace First.Project
{
	public class AutomovelRepositorio : IRepositorio<Automovel>
	{
        private List<Automovel> listaAutomovel = new List<Automovel>();
		public void Atualiza(int id, Automovel objeto)
		{
			listaAutomovel[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaAutomovel[id].Excluir();
		}
		public void Insere(Automovel objeto)
		{
			listaAutomovel.Add(objeto);
		}

		public List<Automovel> Lista()
		{
			return listaAutomovel;
		}

		public int ProximoId()
		{
			return listaAutomovel.Count;
		}

		public Automovel RetornaPorId(int id)
		{
			return listaAutomovel[id];
		}
	}
}