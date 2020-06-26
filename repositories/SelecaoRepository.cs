using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;
using WSTower.Interfaces;

namespace WSTower.repositories
{
    public class SelecaoRepository
    {
        public Selecao BuscarPorId(int id)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                return ctx.Selecao.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Selecao> Listar()
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                return ctx.Selecao.ToList();
            }
        }

        public void Cadastrar(Selecao selecao)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                ctx.Selecao.Add(selecao);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                Selecao selecaoId = ctx.Selecao.Find(id);
                ctx.Selecao.Remove(selecaoId);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Selecao selecao)
        {
            using (CampeonatoContext ctx = new CampeonatoContext())
            {
                Selecao selecaoAtuaizada = ctx.Selecao.FirstOrDefault(x => x.Id == selecao.Id);
                selecaoAtuaizada.Nome = selecao.Nome;
                ctx.Selecao.Update(selecaoAtuaizada);
                ctx.SaveChanges();
            }
        }
    }
}
