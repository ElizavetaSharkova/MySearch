USE [MySearch]
GO
SET IDENTITY_INSERT [dbo].[ResponseTypes] ON 
GO
INSERT [dbo].[ResponseTypes] ([ResponseTypeId], [Type], [RootElementPath], [TitleElement], [DescriptionElement], [UrlElement], [DateElement]) VALUES (1, N'json', N'webPages.value', N'name', N'snippet', N'url', N'dateLastCrawled')
GO
INSERT [dbo].[ResponseTypes] ([ResponseTypeId], [Type], [RootElementPath], [TitleElement], [DescriptionElement], [UrlElement], [DateElement]) VALUES (2, N'json', N'items', N'title', N'snippet', N'link', NULL)
GO
INSERT [dbo].[ResponseTypes] ([ResponseTypeId], [Type], [RootElementPath], [TitleElement], [DescriptionElement], [UrlElement], [DateElement]) VALUES (3, N'xml', N'yandexsearch.response.results.grouping.group', N'title', N'passages', N'url', N'modtime')
GO
SET IDENTITY_INSERT [dbo].[ResponseTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[SearchEngines] ON 
GO
INSERT [dbo].[SearchEngines] ([SearchEngineId], [Name], [BaseUrl], [TypeResponseTypeId], [IsDisable]) VALUES (1, N'Bing', N'https://api.cognitive.microsoft.com/bing/v7.0/search?', 1, 0)
GO
INSERT [dbo].[SearchEngines] ([SearchEngineId], [Name], [BaseUrl], [TypeResponseTypeId], [IsDisable]) VALUES (2, N'Yandex', N'https://yandex.com/search/xml?', 3, 0)
GO
INSERT [dbo].[SearchEngines] ([SearchEngineId], [Name], [BaseUrl], [TypeResponseTypeId], [IsDisable]) VALUES (3, N'Google', N'https://www.googleapis.com/customsearch/v1?', 2, 0)
GO
SET IDENTITY_INSERT [dbo].[SearchEngines] OFF
GO
SET IDENTITY_INSERT [dbo].[SearchRequests] ON 
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (1, N'qwerty', CAST(N'2019-09-08T18:12:26.3322540' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (2, N'angular', CAST(N'2019-09-09T11:35:56.3440973' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (3, N'angular', CAST(N'2019-09-09T11:44:31.4151699' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (4, N'angular', CAST(N'2019-09-09T15:02:42.3928849' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (5, N'angular', CAST(N'2019-09-09T15:04:49.1800177' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (6, N'angular', CAST(N'2019-09-09T15:13:46.4734487' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (7, N'react.js', CAST(N'2019-09-09T15:13:59.4477980' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (8, N'angular', CAST(N'2019-09-09T15:15:23.7712309' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (9, N'react.js', CAST(N'2019-09-09T15:15:43.0426112' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (10, N'react.js', CAST(N'2019-09-11T04:21:45.9502311' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (11, N'react.js', CAST(N'2019-09-11T04:24:25.9198744' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (12, N'react.js', CAST(N'2019-09-11T04:26:37.7833701' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (13, N'angular', CAST(N'2019-09-11T05:06:06.2444714' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (14, N'angular', CAST(N'2019-09-11T14:56:51.0262693' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (15, N'react.js', CAST(N'2019-09-11T14:57:22.6943180' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (16, N'bing', CAST(N'2019-09-11T14:57:35.0433828' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (17, N'bing', CAST(N'2019-09-11T14:57:41.6120800' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (18, N'angular', CAST(N'2019-09-11T17:21:05.0527217' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (19, N'angular', CAST(N'2019-09-12T04:22:45.4892100' AS DateTime2))
GO
INSERT [dbo].[SearchRequests] ([SearchRequestId], [SearchString], [SearchDate]) VALUES (20, N'angular', CAST(N'2019-09-12T05:38:48.3027199' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[SearchRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[SearchResults] ON 
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (11, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.io/?', CAST(N'2018-03-14T06:30:51.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (12, N'AngularJS — Superheroic JavaScript MVW Framework', N'Go to the latest Angular . This site and all of its contents are referring to AngularJS (version 1.x), if you are looking for the latest Angular, please visit angular.io .', N'https://angularjs.org/', CAST(N'2012-10-18T18:42:38.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (13, N'Angular has 191 repositories available. Follow their code on GitHub.', N'Pinned repositories. angular. One framework.angular material material-design angular-components.', N'https://github.com/angular', CAST(N'2010-11-04T02:23:45.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (14, N'Angular (web framework) - Wikipedia', N'Angular (commonly referred to as "Angular 2+" or "Angular v2 and above") is a TypeScript-based open-source web application framework led by the Angular Team at Google and by a community of...', N'https://en.wikipedia.org/wiki/Angular_(web_framework)', CAST(N'2019-05-28T03:00:00.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (15, N'AngularJS - Wikipedia', N'Angular interprets those attributes as directives to bind input or output parts of the page to a model that is represented by standard JavaScriptSubsequent versions of AngularJS are simply called Angular.', N'https://en.m.wikipedia.org/wiki/AngularJS', CAST(N'2012-12-20T06:15:21.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (16, N'Angular - YouTube', N'Introducing Angular Console - Ayşegül Yönet at Angular MTV - Продолжительность: 23 минуты.Angular Update Workshop - Продолжительность: 1 час 9 минут. 7 650 просмотров.', N'https://www.youtube.com/feed/UCbn1OgGei-DV7aSRo_HaAiw', CAST(N'2014-09-04T14:31:39.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (17, N'AngularJS Tutorial', N'<!DOCTYPE html> <html lang="en-US"> <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script> <body>.', N'https://www.w3schools.com/Angular/', CAST(N'2015-11-30T19:22:20.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (18, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.cn/', CAST(N'2015-12-26T11:29:37.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (19, N'Angular Tutorials', N'Angular 4 Tutorials. AngularJS version 4 is latest javascript framework which uses TypeScript as their main language.How To Update Angular CLI To Version 8 | Angular 8 CLI Upgrade is today''s topic.', N'https://appdividend.com/category/angular/', CAST(N'2017-10-19T05:20:05.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (20, N'AngularUP 2019 | Building a Chatbot for an Angular Application', N'Israel''s International Angular Conference & Tour.Hear top speakers from around the world. Learn about the present and future of Angular and its ecosystem, TypeScript, tools and much more.', N'https://angular-up.com/', CAST(N'2016-07-19T05:11:31.0000000' AS DateTime2), 3, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (21, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.io/?', CAST(N'2018-03-14T06:30:51.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (22, N'AngularJS — Superheroic JavaScript MVW Framework', N'Go to the latest Angular . This site and all of its contents are referring to AngularJS (version 1.x), if you are looking for the latest Angular, please visit angular.io .', N'https://angularjs.org/', CAST(N'2012-10-18T18:42:38.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (23, N'Angular has 191 repositories available. Follow their code on GitHub.', N'Pinned repositories. angular. One framework.angular material material-design angular-components.', N'https://github.com/angular', CAST(N'2010-11-04T02:23:45.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (24, N'Angular (web framework) - Wikipedia', N'Angular (commonly referred to as "Angular 2+" or "Angular v2 and above") is a TypeScript-based open-source web application framework led by the Angular Team at Google and by a community of...', N'https://en.wikipedia.org/wiki/Angular_(web_framework)', CAST(N'2019-05-28T03:00:00.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (25, N'AngularJS - Wikipedia', N'Angular interprets those attributes as directives to bind input or output parts of the page to a model that is represented by standard JavaScriptSubsequent versions of AngularJS are simply called Angular.', N'https://en.m.wikipedia.org/wiki/AngularJS', CAST(N'2012-12-20T06:15:21.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (26, N'AngularJS Tutorial', N'<!DOCTYPE html> <html lang="en-US"> <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script> <body>.', N'https://www.w3schools.com/Angular/', CAST(N'2015-11-30T19:22:20.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (27, N'Angular - YouTube', N'Introducing Angular Console - Ayşegül Yönet at Angular MTV - Продолжительность: 23 минуты.Angular Update Workshop - Продолжительность: 1 час 9 минут. 7 650 просмотров.', N'https://www.youtube.com/feed/UCbn1OgGei-DV7aSRo_HaAiw', CAST(N'2014-09-04T14:31:39.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (28, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.cn/', CAST(N'2015-12-26T11:29:37.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (29, N'Angular Tutorials', N'Angular 4 Tutorials. AngularJS version 4 is latest javascript framework which uses TypeScript as their main language.How To Update Angular CLI To Version 8 | Angular 8 CLI Upgrade is today''s topic.', N'https://appdividend.com/category/angular/', CAST(N'2017-10-19T05:20:05.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (30, N'AngularUP 2019 | Building a Chatbot for an Angular Application', N'Israel''s International Angular Conference & Tour.Hear top speakers from around the world. Learn about the present and future of Angular and its ecosystem, TypeScript, tools and much more.', N'https://angular-up.com/', CAST(N'2016-07-19T05:11:31.0000000' AS DateTime2), 4, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (31, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.io/?', CAST(N'2018-03-14T06:30:51.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (32, N'AngularJS — Superheroic JavaScript MVW Framework', N'Go to the latest Angular . This site and all of its contents are referring to AngularJS (version 1.x), if you are looking for the latest Angular, please visit angular.io .', N'https://angularjs.org/', CAST(N'2012-10-18T18:42:38.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (33, N'Angular has 191 repositories available. Follow their code on GitHub.', N'Pinned repositories. angular. One framework.angular material material-design angular-components.', N'https://github.com/angular', CAST(N'2010-11-04T02:23:45.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (34, N'Angular (web framework) - Wikipedia', N'Angular (commonly referred to as "Angular 2+" or "Angular v2 and above") is a TypeScript-based open-source web application framework led by the Angular Team at Google and by a community of...', N'https://en.wikipedia.org/wiki/Angular_(web_framework)', CAST(N'2019-05-28T03:00:00.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (35, N'AngularJS - Wikipedia', N'Angular interprets those attributes as directives to bind input or output parts of the page to a model that is represented by standard JavaScriptSubsequent versions of AngularJS are simply called Angular.', N'https://en.m.wikipedia.org/wiki/AngularJS', CAST(N'2012-12-20T06:15:21.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (36, N'AngularJS Tutorial', N'<!DOCTYPE html> <html lang="en-US"> <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script> <body>.', N'https://www.w3schools.com/Angular/', CAST(N'2015-11-30T19:22:20.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (37, N'Angular - YouTube', N'Introducing Angular Console - Ayşegül Yönet at Angular MTV - Продолжительность: 23 минуты.Angular Update Workshop - Продолжительность: 1 час 9 минут. 7 650 просмотров.', N'https://www.youtube.com/feed/UCbn1OgGei-DV7aSRo_HaAiw', CAST(N'2014-09-04T14:31:39.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (38, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.cn/', CAST(N'2015-12-26T11:29:37.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (39, N'Angular Tutorials', N'Angular 4 Tutorials. AngularJS version 4 is latest javascript framework which uses TypeScript as their main language.How To Update Angular CLI To Version 8 | Angular 8 CLI Upgrade is today''s topic.', N'https://appdividend.com/category/angular/', CAST(N'2017-10-19T05:20:05.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (40, N'AngularUP 2019 | Building a Chatbot for an Angular Application', N'Israel''s International Angular Conference & Tour.Hear top speakers from around the world. Learn about the present and future of Angular and its ecosystem, TypeScript, tools and much more.', N'https://angular-up.com/', CAST(N'2016-07-19T05:11:31.0000000' AS DateTime2), 5, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (41, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.io/?', CAST(N'2018-03-14T06:30:51.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (42, N'AngularJS — Superheroic JavaScript MVW Framework', N'Go to the latest Angular . This site and all of its contents are referring to AngularJS (version 1.x), if you are looking for the latest Angular, please visit angular.io .', N'https://angularjs.org/', CAST(N'2012-10-18T18:42:38.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (43, N'Angular has 191 repositories available. Follow their code on GitHub.', N'Pinned repositories. angular. One framework.angular material material-design angular-components.', N'https://github.com/angular', CAST(N'2010-11-04T02:23:45.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (44, N'Angular (web framework) - Wikipedia', N'Angular (commonly referred to as "Angular 2+" or "Angular v2 and above") is a TypeScript-based open-source web application framework led by the Angular Team at Google and by a community of...', N'https://en.wikipedia.org/wiki/Angular_(web_framework)', CAST(N'2019-05-28T03:00:00.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (45, N'AngularJS - Wikipedia', N'Angular interprets those attributes as directives to bind input or output parts of the page to a model that is represented by standard JavaScriptSubsequent versions of AngularJS are simply called Angular.', N'https://en.m.wikipedia.org/wiki/AngularJS', CAST(N'2012-12-20T06:15:21.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (46, N'AngularJS Tutorial', N'<!DOCTYPE html> <html lang="en-US"> <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.6.9/angular.min.js"></script> <body>.', N'https://www.w3schools.com/Angular/', CAST(N'2015-11-30T19:22:20.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (47, N'Angular - YouTube', N'Introducing Angular Console - Ayşegül Yönet at Angular MTV - Продолжительность: 23 минуты.Angular Update Workshop - Продолжительность: 1 час 9 минут. 7 650 просмотров.', N'https://www.youtube.com/feed/UCbn1OgGei-DV7aSRo_HaAiw', CAST(N'2014-09-04T14:31:39.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (48, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.cn/', CAST(N'2015-12-26T11:29:37.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (49, N'Angular Tutorials', N'Angular 4 Tutorials. AngularJS version 4 is latest javascript framework which uses TypeScript as their main language.How To Update Angular CLI To Version 8 | Angular 8 CLI Upgrade is today''s topic.', N'https://appdividend.com/category/angular/', CAST(N'2017-10-19T05:20:05.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (50, N'AngularUP 2019 | Building a Chatbot for an Angular Application', N'Israel''s International Angular Conference & Tour.Hear top speakers from around the world. Learn about the present and future of Angular and its ecosystem, TypeScript, tools and much more.', N'https://angular-up.com/', CAST(N'2016-07-19T05:11:31.0000000' AS DateTime2), 6, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (51, N'React – A JavaScript library for building user interfaces', N'React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently update and render just the right components when your data changes.', N'https://reactjs.org/', CAST(N'2011-09-03T03:35:45.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (52, N'Изучение React. Полное руководство по React', N'Здесь вы сможете получить самую полную информацию по самой популярной технологии React. Приступайте к изучению прямо сейчас и станьте настоящим профессионалом!', N'https://learn-reactjs.ru/', CAST(N'2017-07-26T03:00:00.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (53, N'React – JavaScript-библиотека для создания пользовательских...', N'React также может работать на сервере с помощью Node и может быть задействован наReact — гибкий и предоставляет хуки, позволяющие вам взаимодействовать с другими библиотеками...', N'https://ru.react.js.org/', CAST(N'2018-07-23T03:00:00.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (54, N'React (web framework) - Wikipedia', N'React (also known as React.js or ReactJS) is a JavaScript library for building user interfaces. It is maintained by Facebook and a community of individual developers and companies.', N'https://en.wikipedia.org/wiki/React_(web_framework)', CAST(N'2014-12-03T12:50:44.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (55, N'React — Википедия', N'React (иногда React.js или ReactJS) — JavaScript-библиотека с открытым исходным кодом для разработки пользовательских интерфейсов.', N'https://ru.wikipedia.org/wiki/React', CAST(N'2015-10-09T19:43:32.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (56, N'Основы React.js', N'React.js -- одна из самых популярных библиотек для создания сложных Frontend-приложений. Однако, успешная разработка на нём требует хорошего понимания концепций...', N'https://learn.javascript.ru/screencast/react', CAST(N'2016-09-02T03:00:00.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (57, N'facebook/react: A declarative, efficient, and flexible JavaScript library...', N'React is a JavaScript library for building user interfaces. Declarative: React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently...', N'https://github.com/facebook/react', CAST(N'2015-12-03T02:56:43.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (58, N'React Tutorial', N'React is a JavaScript library for building user interfaces. React is used to build single pageIf you have NPM and Node.js installed, you can create a React application by first installing the...', N'https://www.w3schools.com/react/', CAST(N'2019-01-26T03:00:00.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (59, N'A nice collection of often useful examples done in React.js', N'Boilerplate for Chrome Extension React.js project.react-search is a simple search autocomplete component using react.js.', N'https://reactjsexample.com/', CAST(N'2016-08-18T22:25:29.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (60, N'REACT JS TUTORIAL #1 - Reactjs Javascript Introduction... - YouTube', N'This React JS Course will help you get quickly up to pace with React.js development. React is an AMAZING Javascript framework that allows you to build...', N'https://www.youtube.com/watch?v=MhkGQAoc7bc', CAST(N'2016-03-31T03:20:14.0000000' AS DateTime2), 7, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (61, N'Angular', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with Angular.', N'https://angular.io/', CAST(N'2019-09-05T19:57:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (62, N'AngularJS — Superheroic JavaScript MVW Framework', N'AngularJS is what HTML would have been, had it been designed for building web-apps. Declarative templates with data-binding, MVW, MVVM, MVC, dependency ...', N'https://angularjs.org/', CAST(N'2019-09-04T20:08:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (63, N'AngularJS — Википедия', N'Литература. Brad Green, Shyam Seshadri. AngularJS. — O''Reilly Media, 2013. — 196 p. — ISBN 978-1449344856. Lukas Ruebbelke with Brian Ford.', N'https://ru.wikipedia.org/wiki/AngularJS', CAST(N'2019-09-05T05:27:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (64, N'Angular | Введение и начало работы', N'Введение,основные особенности и начало работы с Angular 8, роль языка TypeScript, первое приложение', N'https://metanit.com/web/angular2/1.1.php', CAST(N'2019-09-03T13:39:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (65, N'Angular Material', N'Versatile. Themable, for when you need to stay on brand or just have a favorite color. Accessible and internationalized so that all users are welcome.', N'https://material.angular.io/', CAST(N'2019-09-06T06:18:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (66, N'Angular (web framework) - Wikipedia', N'Angular (commonly referred to as "Angular 2+" or "Angular v2 and above") is a TypeScript-based open-source web application framework led by the Angular Team at Google ...', N'https://en.wikipedia.org/wiki/Angular_(Application_Platform)', CAST(N'2019-09-06T10:57:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (67, N'AngularJS - Wikipedia', N'Angular Material is a UI component library that implements Material Design in AngularJS. Chrome extension. In July 2012, the Angular team built an ...', N'https://en.wikipedia.org/wiki/AngularJS', CAST(N'2019-09-04T17:49:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (68, N'Angular CLI', N'ng new. The Angular CLI makes it easy to create an application that already works, right out of the box. It already follows our best practices!', N'https://cli.angular.io/', CAST(N'2019-09-04T05:45:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (69, N'AngularJS Tutorial - w3schools.com', N'Well organized and easy to understand Web building tutorials with lots of examples of how to use HTML, CSS, JavaScript, SQL, PHP, Python, Bootstrap, Java and XML.', N'https://www.w3schools.com/angular/', CAST(N'2019-09-05T05:52:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (70, N'Angular · GitHub', N'Angular has 190 repositories available. Follow their code on GitHub.', N'https://github.com/angular', CAST(N'2019-09-04T07:26:00.0000000' AS DateTime2), 8, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (71, N'React – A JavaScript library for building user interfaces', N'React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently update and render just the right ...', N'https://reactjs.org/', CAST(N'2019-09-04T12:32:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (72, N'Основы React.js - learn.javascript.ru', N'Скринкаст по React.js. React.js-- одна из самых популярных библиотек для создания сложных Frontend ...', N'https://learn.javascript.ru/screencast/react', CAST(N'2019-09-03T12:58:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (73, N'React – JavaScript-библиотека для создания ...', N'Создавать интерактивные пользовательские интерфейсы на React — приятно и просто.', N'https://ru.reactjs.org/', CAST(N'2019-09-05T13:42:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (74, N'React (web framework) - Wikipedia', N'The Greeter class is a React component that accepts a property greeting. The ReactDOM.render method creates an instance of the Greeter component, sets the greeting ...', N'https://en.wikipedia.org/wiki/React_(JavaScript_library)', CAST(N'2019-09-06T01:28:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (75, N'Курс по React - learn.javascript.ru', N'Программа. В этом курсе мы с вами шаг за шагом пройдем от знакомства с основными идеями до ...', N'https://learn.javascript.ru/courses/react', CAST(N'2019-09-05T07:10:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (76, N'React – JavaScript-библиотека для создания ...', N'React делает безболезным создание интерактивных пользовательских интерфейсов.', N'https://ru.react.js.org/', CAST(N'2019-08-29T23:17:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (77, N'Формы – React', N'В React HTML-элементы формы ведут себя несколько отлично от остальных DOM-элементов, так как у ...', N'https://ru.reactjs.org/docs/forms.html', CAST(N'2019-09-05T14:14:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (78, N'Tutorial: Intro to React – React', N'Delete all files in the src/ folder of the new project ; Note: Don’t delete the entire src folder, just the original source files inside it. We’ll replace the ...', N'https://reactjs.org/tutorial/tutorial.html', CAST(N'2019-09-05T16:33:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (79, N'Изучение React. Полное руководство по React', N'Изучение React. Учебник React. Документация React. Полное руководство по React. Здесь вы сможете ...', N'https://learn-reactjs.ru/home', CAST(N'2019-09-03T17:56:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (80, N'React integration for ASP.NET MVC | ReactJS.NET', N'ReactJS.NET makes it easier to use Facebook''s React and JSX from C# and other .NET languages, focusing specifically on ASP.NET MVC (although it also ...', N'https://reactjs.net/', CAST(N'2019-09-05T07:03:00.0000000' AS DateTime2), 9, 1)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (81, N'React – A JavaScript library for building user interfaces', N'Design simple views for each state in your application, and React will ... Since 
component logic is written in JavaScript instead of templates, you can easily pass
 ...', N'https://reactjs.org/', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (82, N'React (web framework) - Wikipedia', N'React is a JavaScript library for building user interfaces. It is maintained by 
Facebook and a community of individual developers and companies. React can 
be ...', N'https://en.wikipedia.org/wiki/React_(web_framework)', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (83, N'Tutorial: Intro to React – React', N'React is a declarative, efficient, and flexible JavaScript library for building user 
interfaces. It lets you compose complex UIs from small and isolated pieces of ...', N'https://reactjs.org/tutorial/tutorial.html', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (84, N'facebook/react: A declarative, efficient, and flexible ... - GitHub', N'A declarative, efficient, and flexible JavaScript library for building user interfaces. 
- facebook/react.', N'https://github.com/facebook/react', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (85, N'React (@reactjs) | Twitter', N'The latest Tweets from React (@reactjs). React is a declarative, efficient, and 
flexible JavaScript library for building user interfaces.', N'https://twitter.com/reactjs?lang=en', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (86, N'React Tutorial', N'React is a JavaScript library for building user interfaces. React is used to build 
single page applications. React allows us to create reusable UI components.', N'https://www.w3schools.com/react/', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (87, N'React.js: a better introduction to the most powerful UI library ever ...', N'Sep 1, 2018 ... A better introduction to React? Unfortunately, most of the React tutorials out there 
have no consideration for best practices and don''t always ...', N'https://hackernoon.com/react-js-a-better-introduction-to-the-most-powerful-ui-library-ever-created-ecd96e8f4621', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (88, N'What is React', N'React is a JavaScript library created by Facebook. React is a User Interface (UI) 
library. React is a tool for building UI components ...', N'https://www.w3schools.com/whatis/whatis_react.asp', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (89, N'ReactJS Basics - #1 What is React? - YouTube', N'Aug 11, 2016 ... This ReactJS Tutorial dives into the Question what ReactJS actually is and why 
you might want to use it. Limited Offer! Join the Full React.js ...', N'https://www.youtube.com/watch?v=JPT3bFIwJYA', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (90, N'ReactJS Tutorial Part I: Learn ReactJS For Free | Codecademy', N'Utilize ReactJS components like JSX to build powerful interactive applications 
with this popular JavaScript library.', N'https://www.codecademy.com/learn/react-101', NULL, 10, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (91, N'React – A JavaScript library for building user interfaces', N'Design simple views for each state in your application, and React will ... Since 
component logic is written in JavaScript instead of templates, you can easily pass
 ...', N'https://reactjs.org/', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (92, N'React (web framework) - Wikipedia', N'React is a JavaScript library for building user interfaces. It is maintained by 
Facebook and a community of individual developers and companies. React can 
be ...', N'https://en.wikipedia.org/wiki/React_(web_framework)', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (93, N'Tutorial: Intro to React – React', N'React is a declarative, efficient, and flexible JavaScript library for building user 
interfaces. It lets you compose complex UIs from small and isolated pieces of ...', N'https://reactjs.org/tutorial/tutorial.html', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (94, N'facebook/react: A declarative, efficient, and flexible ... - GitHub', N'A declarative, efficient, and flexible JavaScript library for building user interfaces. 
- facebook/react.', N'https://github.com/facebook/react', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (95, N'React (@reactjs) | Twitter', N'The latest Tweets from React (@reactjs). React is a declarative, efficient, and 
flexible JavaScript library for building user interfaces.', N'https://twitter.com/reactjs?lang=en', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (96, N'React Tutorial', N'React is a JavaScript library for building user interfaces. React is used to build 
single page applications. React allows us to create reusable UI components.', N'https://www.w3schools.com/react/', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (97, N'React.js: a better introduction to the most powerful UI library ever ...', N'Sep 1, 2018 ... A better introduction to React? Unfortunately, most of the React tutorials out there 
have no consideration for best practices and don''t always ...', N'https://hackernoon.com/react-js-a-better-introduction-to-the-most-powerful-ui-library-ever-created-ecd96e8f4621', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (98, N'What is React', N'React is a JavaScript library created by Facebook. React is a User Interface (UI) 
library. React is a tool for building UI components ...', N'https://www.w3schools.com/whatis/whatis_react.asp', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (99, N'ReactJS Basics - #1 What is React? - YouTube', N'Aug 11, 2016 ... This ReactJS Tutorial dives into the Question what ReactJS actually is and why 
you might want to use it. Limited Offer! Join the Full React.js ...', N'https://www.youtube.com/watch?v=JPT3bFIwJYA', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (100, N'ReactJS Tutorial Part I: Learn ReactJS For Free | Codecademy', N'Utilize ReactJS components like JSX to build powerful interactive applications 
with this popular JavaScript library.', N'https://www.codecademy.com/learn/react-101', NULL, 11, 3)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (101, N'React – A JavaScript library for building user interfaces', N'React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently update and render just the right components when your data changes.', N'https://reactjs.org/', CAST(N'2011-09-03T03:35:45.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (102, N'Изучение React. Полное руководство по React', N'Здесь вы сможете получить самую полную информацию по самой популярной технологии React. Приступайте к изучению прямо сейчас и станьте настоящим профессионалом!', N'https://learn-reactjs.ru/', CAST(N'2017-07-26T03:00:00.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (103, N'React – JavaScript-библиотека для создания пользовательских...', N'React также может работать на сервере с помощью Node и может быть задействован наReact — гибкий и предоставляет хуки, позволяющие вам взаимодействовать с другими библиотеками...', N'https://ru.react.js.org/', CAST(N'2018-07-23T03:00:00.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (104, N'React (web framework) - Wikipedia', N'React (also known as React.js or ReactJS) is a JavaScript library for building user interfaces. It is maintained by Facebook and a community of individual developers and companies.', N'https://en.wikipedia.org/wiki/React_(web_framework)', CAST(N'2014-12-03T12:50:44.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (105, N'React — Википедия', N'React (иногда React.js или ReactJS) — JavaScript-библиотека с открытым исходным кодом для разработки пользовательских интерфейсов. React разрабатывается и поддерживается Facebook, Instagram и сообществом отдельных разработчиков и корпораций.', N'https://ru.wikipedia.org/wiki/React', CAST(N'2015-10-09T19:43:32.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (106, N'Основы React.js', N'React.js -- одна из самых популярных библиотек для создания сложных Frontend-приложений. Однако, успешная разработка на нём требует хорошего понимания концепций...', N'https://learn.javascript.ru/screencast/react', CAST(N'2016-09-02T03:00:00.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (107, N'facebook/react: A declarative, efficient, and flexible JavaScript library...', N'React is a JavaScript library for building user interfaces. Declarative: React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently...', N'https://github.com/facebook/react', CAST(N'2015-12-03T02:56:43.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (108, N'React Tutorial', N'React is a JavaScript library for building user interfaces. React is used to build single pageIf you have NPM and Node.js installed, you can create a React application by first installing the...', N'https://www.w3schools.com/react/', CAST(N'2019-01-26T03:00:00.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (109, N'A nice collection of often useful examples done in React.js', N'React PureComponent loading animations. React Pure Loaders is a package that disponibilizes loaders for your Project.Boilerplate for Chrome Extension React.js project.', N'https://reactjsexample.com/', CAST(N'2016-08-18T22:25:29.0000000' AS DateTime2), 12, 2)
GO
INSERT [dbo].[SearchResults] ([SearchResultId], [Title], [Description], [Url], [IndexedTime], [RequestSearchRequestId], [SearchEngineId]) VALUES (110, N'REACT JS TUTORIAL #1 - Reactjs Javascript Introduction... - YouTube', N'This React JS Course will help you get quickly up to pace with React.js development. React is an AMAZING Javascript framework that allows you to build...', N'https://www.youtube.com/watch?v=MhkGQAoc7bc', CAST(N'2016-03-31T03:20:14.0000000' AS DateTime2), 12, 2)
GO
SET IDENTITY_INSERT [dbo].[SearchResults] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestsParameters] ON 
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (7, N'user', N'sharkliza', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (8, N'key', N'03.56342046:44e04c5c9ed07bc68cea14d41c1d5449', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (10, N'cx', N'013553820816947410123:zutiweyshiv', 3)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (11, N'key', N'0123456789', 3) --example data
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (12, N'fields', N'items(title,link,snippet)', 3)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (13, N'search', N'q', 1)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (14, N'search', N'query', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (15, N'search', N'q', 3)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (16, N'l10n', N'en', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (17, N'sortby', N'rlv', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (18, N'filter', N'none', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (19, N'maxpassages', N'1', 2)
GO
INSERT [dbo].[RequestsParameters] ([RequestsParameterId], [ParametrName], [ParametrValue], [engineSearchEngineId]) VALUES (20, N'groupby', N'attr%3Dd.mode%3Ddeep.groups-on-page%3D10.docs-in-group%3D1', 2)
GO
SET IDENTITY_INSERT [dbo].[RequestsParameters] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestHeaders] ON 
GO
INSERT [dbo].[RequestHeaders] ([RequestHeaderId], [HeaderName], [HeaderValue], [engineSearchEngineId]) VALUES (1, N'Ocp-Apim-Subscription-Key', N'f4dbfb964e114a3ab43cd253b5c9cba7', 1)
GO
INSERT [dbo].[RequestHeaders] ([RequestHeaderId], [HeaderName], [HeaderValue], [engineSearchEngineId]) VALUES (2, N'X-MSEdge-ClientID', N'X-MSEdge-ClientID', 1)
GO
SET IDENTITY_INSERT [dbo].[RequestHeaders] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190908113752_InitialCreate', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910005706_Add_RequestParameters_and_ResponseType', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910024549_Add_RequestHeaders', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910151533_deleteType', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910151802_addType', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910195541_renameRootElement', N'2.2.6-servicing-10079')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190910200319_AddIsDisableEngine', N'2.2.6-servicing-10079')
GO
