# E-Book Repository API

## Content search example

![Content Search](./docs/content.png)

## Search

Search uses Boolean *AND* Query for all given query options.  
If your search is based on multiple fields, it will only result in a single matching e-book result.

### Search functions:
- Match search:  
`Search(IEBookSearchOptions options)`  

- Fuzzy search:  
`FuzzySearch(IEBookSearchOptions options)`  

> **_Note:_**
> Additional search function on `feature/full-search` branch: 
> - Match search:  
> `SearchByTitle(string title)`  
> `SearchByAuthor(string author)`  
> `SearchByKeywords(string keywords)`  
> `SearchByCategory(string category)`  
> `SearchByLanguage(string language)`  
>
> - Fuzzy search:  
> `FuzzySearchByTitle(string title)`  
> `FuzzySearchByAuthor(string author)`  
> `FuzzySearchByKeywords(string keywords)`  
> `FuzzySearchByCategory(string category)`  
> `FuzzySearchByLanguage(string language)`  

### Search Options  
```
public interface IEBookSearchOptions
{
    string Title { get; set; }
    string Author { get; set; }
    string Keywords { get; set; }
    string Language { get; set; }
    string Category { get; set; }
    
    int Page { get; set; }
    int Size { get; set; }
}
```

### Example search requests

Without fuzzy search:  
`GET /api/ebooks/search?title=the great gatsby&language=english`  

With fuzzy search:  
`GET /api/ebooks/search?title=cash for kings&author=gerge&fuzzy=true`

## Filter

Filter uses Boolean *OR* Query for all given query options.  
Your filter can be based on multiple fields and it will result in all matching e-books.

### Filter functions:  
- Match filter:  
`Filter(IEBooksFilterOptions options)`  

- Fuzzy filter:  
`FuzzyFilter(IEBooksFilterOptions options)`  

### Filter Options  
```
public interface IEBookFilterOptions
{
    string Title { get; set; }
    string Author { get; set; }
    string Keywords { get; set; }
    string Language { get; set; }
    string Category { get; set; }

    int Page { get; set; }
    int Size { get; set; }
}
```

### Example filter requests:

Without fuzzy filter:  
`GET /api/ebooks/filter?author=george&title=catch 22`  

With fuzzy filter:  
`GET /api/ebooks/filter?author=gorge&title=catc 25&fuzzy=true`

## Example response:  

```
{
    "total": 2,
    "page": 1,
    "size": 2,
    "items": [
        {
            "highlights": {
                "file.content": [
                    "Ut ac <strong>dolor</strong>\nLorem ipsum <strong>dolor</strong> sit amet, consectetur adipiscing Lorem ipsum <strong>dolor</strong> sit amet, consectetur adipiscing Lorem ipsum <strong>dolor</strong> sit amet, consectetur",
                    "Ut ac <strong>dolor</strong>\nLorem ipsum <strong>dolor</strong> sit amet, consectetur adipiscing Lorem ipsum <strong>dolor</strong> sit amet, consectetur adipiscing Lorem ipsum <strong>dolor</strong> sit amet, consectetur"
                ]
            },
            "id": 2,
            "title": "Example book",
            "author": "Example author",
            "keywords": "example dummy content test",
            "publicationYear": 2020,
            "file": {
                "path": "path-to-pdf-location\\example.pdf",
                "mime": "application/pdf",
                "filename": "example.pdf"
            },
            "category": {
                "id": 6,
                "name": "Tech"
            },
            "language": {
                "id": 1,
                "name": "English"
            }
    },
    ... other items ...
}
```