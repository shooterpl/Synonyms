using Synonyms.Models;
using Synonyms.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Synonyms.api
{
    public class SearchController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private SynonymDtoesController controller = new SynonymDtoesController();

        public SynonymDtoViewModel Post([FromBody]SynonymDtoViewModel value)

        {
            IList<SynonymDtoViewModel> list = controller.GetSynonymDtoes();
            SynonymDtoViewModel viewModel = new SynonymDtoViewModel();
            var synonyms = db.SynonymDtoes.ToList();
            var result = list.FirstOrDefault(x => x.Term == value.Term);
            viewModel.Term = result.Term;
            viewModel.Synonyms = result.Synonyms;
            return viewModel;
        }

    }
}