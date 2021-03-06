﻿namespace EBook.Services.Queries.Fuzzy
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookLanguageFuzzyQuery : SearchRequestSpecification<Book>
    {
        private readonly string _language;

        public EBookLanguageFuzzyQuery(string language)
            => _language = language ?? throw new ArgumentNullException($"{nameof(language)} cannot be null.");

        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Language.Name)
                        .Query(_language)
                        .Fuzziness(Fuzziness.Auto)
                    )
                );
    }
}
