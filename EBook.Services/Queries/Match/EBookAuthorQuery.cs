﻿namespace EBook.Services.Queries.Match
{
    using EBook.Domain;
    using Nest;
    using System;

    public class EBookAuthorQuery : SearchRequestSpecification<Book>
    {
        private readonly string _author;

        public EBookAuthorQuery(string author)
            => _author = author ?? throw new ArgumentNullException($"{nameof(author)} cannot be null.");

        // @TODO:
        // - Remove "ebooks"
        public override ISearchRequest<Book> IsSatisfiedBy()
            => new SearchDescriptor<Book>()
                .Index("ebooks")
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Author)
                        .Query(_author)
                    )
                );
    }
}