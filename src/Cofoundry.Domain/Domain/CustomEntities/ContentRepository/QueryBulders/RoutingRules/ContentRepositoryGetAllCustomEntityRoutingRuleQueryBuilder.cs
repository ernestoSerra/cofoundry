﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryGetAllCustomEntityRoutingRuleQueryBuilder
        : IAdvancedContentRepositoryGetAllCustomEntityRoutingRuleQueryBuilder
        , IExtendableContentRepositoryPart
    {
        public ContentRepositoryGetAllCustomEntityRoutingRuleQueryBuilder(
            IExtendableContentRepository contentRepository
            )
        {
            ExtendableContentRepository = contentRepository;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public IContentRepositoryQueryContext<ICollection<ICustomEntityRoutingRule>> AsRoutingRules()
        {
            var query = new GetAllCustomEntityRoutingRulesQuery();
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }
    }
}
