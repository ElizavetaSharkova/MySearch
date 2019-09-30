# MySearch
ASP.NET Core App for search something in Google, Yandex or Bing:
1. User input string for search and click button.
2. Application send request to each not disabled search engine in db.
3. The fastest response is parsing, saving in db and displaying on page.
4. User can search by history (by db data)

The project will be published at url: https://mysearch20190930022225.azurewebsites.net

Project include xUnit test project and test data, but not all methods are covered by tests.

Install:
1. Cloning repository
2. Check ConnectionStrings
3. Migration
4. Run script: INSERT_DATA_TO_DB.sql
5. Create User in https://xml.yandex.ru/settings/
6. Replace yandex user and key in DB
5-6:or disable yandex in DB
7. If now the date is more than 14.09.19, Create User in https://azure.microsoft.com/ru-ru/try/cognitive-services/my-apis/?apiSlug=search-api
8. Replace bing key in DB
7-8: or disable bing in DB
9. Create user and project in https://console.developers.google.com/apis/api/customsearch.googleapis.com/overview
10. Replace googgle key in DB
11. Create Search engine in cse.google.com/cse/all
12. Replace google "cx" value in DB to search engine id from step 11
9-12: or disable google in DB