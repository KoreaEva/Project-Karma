using Karma.Services.Models;
using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using System.Net.Http;
using System.Data.Entity;
using AutoMapper;

namespace Karma.Services.DataObjects
{
    public class QuestDtoDomainManager : MappedEntityDomainManager<MobileQuest, Quest>
    {
        private ApplicationDbContext DbContext; 

        public QuestDtoDomainManager(ApplicationDbContext context, HttpRequestMessage request)
            : base(context, request)
        {
            this.DbContext = context;
            Request = request;
        }

        private long GetKey(string mobileid, DbSet<Quest> quests, HttpRequestMessage request)
        {
            long questid = quests.Where(x => x.Id == mobileid).Select(x => x.QuestId).FirstOrDefault();
            if (questid == 0)
            {
                throw new HttpResponseException(request.CreateNotFoundResponse());
            }
            return questid;
        }

        protected override T GetKey<T>(string mobileid)
        {
            return (T)(object)GetKey(mobileid, this.DbContext.Quests, this.Request);
        }

        public override SingleResult<MobileQuest> Lookup(string mobileid)
        {
            long questid = GetKey<long>(mobileid);
            return LookupEntity(c => c.QuestId == questid);
        }

        public override async Task<MobileQuest> InsertAsync(MobileQuest mobilequest)
        {
            return await base.InsertAsync(mobilequest);
        }

        public override async Task<bool> DeleteAsync(string mobileid)
        {
            long questid = GetKey<long>(mobileid);
            return await DeleteItemAsync(questid);
        }


        public override async Task<MobileQuest> UpdateAsync(string mobileid, Delta<MobileQuest> patch)
        {
            long questid = GetKey<long>(mobileid);

            Quest existingQuest = await this.DbContext.Set<Quest>().FindAsync(questid);

            if (existingQuest == null)
            {
                throw new HttpResponseException(this.Request.CreateNotFoundResponse());
            }

            MobileQuest existingMobileQuest = Mapper.Map<Quest, MobileQuest>(existingQuest);
            patch.Patch(existingMobileQuest);
            Mapper.Map<MobileQuest, Quest>(existingMobileQuest, existingQuest);

            await this.SubmitChangesAsync();

            MobileQuest updatedMobileQuest = Mapper.Map<Quest, MobileQuest>(existingQuest);

            return updatedMobileQuest;
        }
    }
}