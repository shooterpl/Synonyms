using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Synonyms.Models;
using Synonyms.ViewModel;
namespace Synonyms.api
{
    public class SynonymDtoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IList<SynonymDtoViewModel> GetSynonymDtoes()
        {
            var synonymDto = db.SynonymDtoes.ToList();
            List<SynonymDtoViewModel> viewModelList = new List<SynonymDtoViewModel>();
            for (int i = 0; i < synonymDto.Count(); i++)
            {
                SynonymDto synonym = synonymDto[i];
                SynonymDtoViewModel viewModel = new SynonymDtoViewModel();

                var synonyms = synonym.Synonyms.Split(',');
                foreach (string syn in synonyms)
                {
                    if (synonymDto.Exists(x => x.Term == syn) == false)
                    {
                        SynonymDto newSyn = new SynonymDto();
                        newSyn.Term = syn;
                        if (newSyn.Synonyms != null) newSyn.Synonyms += ',';
                        newSyn.Synonyms += synonym.Term;
                        synonymDto.Add(newSyn);
                    }
                }
                if (viewModelList.Exists(x => x.Term == synonym.Term))
                {
                    var repeatedSyn = viewModelList.Find(x => x.Term == synonym.Term);
                    foreach (string syn in synonyms)
                    {
                        if (repeatedSyn.Synonyms.Exists(x => x == syn) == false)
                        {
                            repeatedSyn.Synonyms.Add(syn);
                        }
                    }
                    
                }
                else
                {
                    viewModel.Term = synonym.Term;
                    viewModel.Synonyms = synonyms.ToList();
                    viewModelList.Add(viewModel);
                }
            }
            return viewModelList;
        }
        
        public void Post([FromBody]SynonymDto value)

        {
            if(value.Synonyms != null && value.Term != null)
            {
                var synonyms = value.Synonyms.Split(',');
                if (synonyms.First(x => x == value.Term) == null)
                {
                    db.SynonymDtoes.Add(value);
                    db.SaveChanges();
                }
            }
        }

 

        private bool SynonymDtoExists(int id)
        {
            return db.SynonymDtoes.Count(e => e.Id == id) > 0;
        }
    }
}