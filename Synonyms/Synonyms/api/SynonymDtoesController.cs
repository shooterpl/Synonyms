using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Synonyms.Models;
using Synonyms.ViewModel;
using System;

namespace Synonyms.api
{
    public class SynonymDtoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IList<SynonymDtoViewModel> GetSynonymDtoes()
        {
            var synonymDto = db.SynonymDtoes.ToList();
            List<SynonymDtoViewModel> viewModelList = new List<SynonymDtoViewModel>();
            foreach (SynonymDto synonym in synonymDto)
            {
                SynonymDtoViewModel viewModel = new SynonymDtoViewModel();
                if (viewModelList.Exists(x => x.Term == synonym.Term) == false)
                {
                    viewModel.Term = synonym.Term;
                    IList<string> synonyms = synonym.Synonyms.Split(',');
                    viewModel.Synonyms = synonyms.ToList();
                    viewModelList.Add(viewModel);
                } 
                
            }
            foreach (SynonymDto synonym in synonymDto)
            {
                IList<string> synonyms = synonym.Synonyms.Split(',');
                foreach (string syn in synonyms)
                {
                    var temp = viewModelList.FirstOrDefault(x => x.Term == syn);
                    if (temp != null) temp.Synonyms.Add(synonym.Term);
                    else
                    {
                        try
                        {

                            SynonymDtoViewModel viewModel = new SynonymDtoViewModel();
                            viewModel.Term = syn;
                            List<string> lista = new List<string>();
                            lista.Add(synonym.Term);
                            viewModel.Synonyms = lista;
                            viewModelList.Add(viewModel);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    var temp2 = viewModelList.FirstOrDefault(x => x.Term == synonym.Term);
                    if (temp2.Synonyms.Exists(x => x == syn) == false) temp2.Synonyms.Add(syn);
                }
            }
            return viewModelList;
        }

        public void Post([FromBody]SynonymDto value)

        {
            if (value.Synonyms != null && value.Term != null)
            {
                try
                {
                    var synonyms = value.Synonyms.Split(',');
                    if (synonyms.FirstOrDefault(x => x == value.Term) == null)
                    {
                        db.SynonymDtoes.Add(value);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
        }

        private bool SynonymDtoExists(int id)
        {
            return db.SynonymDtoes.Count(e => e.Id == id) > 0;
        }
    }

    public class SynonymPost
    {
        public string Term;
    }
}