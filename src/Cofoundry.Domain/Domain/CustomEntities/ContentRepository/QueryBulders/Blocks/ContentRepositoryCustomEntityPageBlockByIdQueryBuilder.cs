﻿using Cofoundry.Domain.Extendable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cofoundry.Domain
{
    public class ContentRepositoryCustomEntityPageBlockByIdQueryBuilder
        : IAdvancedContentRepositoryCustomEntityPageBlockByIdQueryBuilder
        , IExtendableContentRepositoryPart
    {
        private readonly int _customEntityBlockId;

        public ContentRepositoryCustomEntityPageBlockByIdQueryBuilder(
            IExtendableContentRepository contentRepository,
            int customEntityBlockId
            )
        {
            ExtendableContentRepository = contentRepository;
            _customEntityBlockId = customEntityBlockId;
        }

        public IExtendableContentRepository ExtendableContentRepository { get; }

        public IContentRepositoryQueryContext<CustomEntityVersionPageBlockRenderDetails> AsRenderDetails(PublishStatusQuery? publishStatusQuery = null)
        {
            var query = new GetCustomEntityVersionPageBlockRenderDetailsByIdQuery(_customEntityBlockId, publishStatusQuery);
            return ContentRepositoryQueryContextFactory.Create(query, ExtendableContentRepository);
        }
    }
}
