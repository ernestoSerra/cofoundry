﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryPageByCustomEntityIdQueryBuilder
        : IAdvancedContentRepositoryPageByCustomEntityIdQueryBuilder
        , IExtendableContentRepositoryPart
    {
        private readonly int _customEntityId;

        public ContentRepositoryPageByCustomEntityIdQueryBuilder(
            IExtendableContentRepository contentRepository,
            int customEntityId
            )
        {
            ExtendableContentRepository = contentRepository;
            _customEntityId = customEntityId;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public IContentRepositoryQueryContext<ICollection<PageRoutingInfo>> AsRoutingInfo()
        {
            var query = new GetPageRoutingInfoByCustomEntityIdQuery(_customEntityId);
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }
    }
}
