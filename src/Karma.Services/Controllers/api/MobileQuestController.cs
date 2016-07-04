using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Karma.Services.DataObjects;
using Karma.Services.Models;

namespace Karma.Services.Controllers.api
{
    public class MobileQuestController : TableController<MobileQuest>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            ApplicationDbContext context = new ApplicationDbContext();
            //DomainManager = new EntityDomainManager<MobileQuest>(context, Request);
            DomainManager = new QuestDtoDomainManager(context, Request);
        }

        // GET tables/MobileQuest
        public IQueryable<MobileQuest> GetAllMobileQuest()
        {
            return Query(); 
        }

        // GET tables/MobileQuest/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<MobileQuest> GetMobileQuest(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/MobileQuest/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<MobileQuest> PatchMobileQuest(string id, Delta<MobileQuest> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/MobileQuest
        public async Task<IHttpActionResult> PostMobileQuest(MobileQuest item)
        {
            MobileQuest current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/MobileQuest/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteMobileQuest(string id)
        {
             return DeleteAsync(id);
        }
    }
}
