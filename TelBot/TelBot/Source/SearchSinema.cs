using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AngleSharp.Html.Parser;

namespace TelBot.Source
{

	class SearchSinema
	{
		//private static string test = "showtimesMovie_name";
		//private static string test1 = "showtimesMovie_categories";
		//private static string test2 = "showtimes_sessions";
		//private static string test3 = "showtimes_item";

		private static string test = "search-snippet-view__link-overlay";
		private static string test1 = "orgpage-header-view__header";
		private static string test2 = "orgpage-header-view__address";
		private static string test3 = "business-card-view__extend";

		private static readonly string urlSites = "https://yandex.ru/maps/213/moscow/search/москва%20поиск%20кинотеатров/?ll=37.651246%2C55.751047&sctx=ZAAAAAgCEAAaKAoSCe8dNSbEAEZAEWg%2B527XKUxAEhIJJ58e2zLg4T8Rf%2FlkxXB1zj8iBQABAgQFKAA4AEAvSAFiKnJlbGV2X2V4cF9yZW1vdmVfbm9uX3doaXRlbGlzdF9ydWJyaWNfYWQ9MWIkbWlkZGxlX2Fza19kaXJlY3RfcXVlcnlfdHlwZXM9cnVicmljYihtaWRkbGVfaW5mbGF0ZV9kaXJlY3RfZmlsdGVyX3dpbmRvdz01MDAwYhJyZWxldl9kcnVnX2Jvb3N0PTFiRG1pZGRsZV9kaXJlY3Rfc25pcHBldHM9cGhvdG9zLzIueCxidXNpbmVzc3JhdGluZy8yLngsbWFzc3RyYW5zaXQvMS54YjZtaWRkbGVfd2l6ZXh0cmE9dHJhdmVsX2NsYXNzaWZpZXJfdmFsdWU9MC4wMDQ4MzY1NTE4NDViJ21pZGRsZV93aXpleHRyYT1hcHBseV9mZWF0dXJlX2ZpbHRlcnM9MWIobWlkZGxlX3dpemV4dHJhPW9yZ21uX3dhbmRfdGhyZXNob2xkPTAuOWIpbWlkZGxlX3dpemV4dHJhPXJlcXVlc3Rfc29mdF90aW1lb3V0PTAuMDViI21pZGRsZV93aXpleHRyYT10cmFuc2l0X2FsbG93X2dlbz0xYj5taWRkbGVfd2l6ZXh0cmE9dHJhdmVsX2NsYXNzaWZpZXJfb3JnbWFueV92YWx1ZT0wLjAwMjAwNjUzMDUyOWIqbWlkZGxlX2luZmxhdGVfZGlyZWN0X3JlcXVlc3Rfd2luZG93PTEwMDAwYh5taWRkbGVfYXNrX2RpcmVjdF9wZXJtYWxpbmtzPTFiMXJlbGV2X2V4cF9ydWJyaWNfYWRfd2hpdGVsaXN0PXZpc2l0X2dkdV93aGl0ZWxpc3RiHXJlbGV2X2ZpbHRlcl9nd2tpbmRzPTAuMywwLjQ1YilyZWFycj1zY2hlbWVfTG9jYWwvR2VvL1JlcXVlc3RVZ2NEaWdlc3Q9MWIpcmVhcnI9c2NoZW1lX0xvY2FsL0dlby9Vc2VHZW9UcmF2ZWxSdWxlPTFiKXJlYXJyPXNjaGVtZV9Mb2NhbC9HZW8vQ3V0QWZpc2hhU25pcHBldD0xYilyZWFycj1zY2hlbWVfTG9jYWwvR2VvL0FsbG93VHJhdmVsQm9vc3Q9MWI3cmVhcnI9c2NoZW1lX0xvY2FsL0dlby9SZXF1ZXN0VWdjRm9yUG9zc2libGVPd25lcnM9dHJ1ZWIvcmVhcnI9c2NoZW1lX0xvY2FsL0dlby9Qb3N0ZmlsdGVyL0Fic1RocmVzaD0wLjJiMXJlYXJyPXNjaGVtZV9Mb2NhbC9HZW91cHBlci9mZWF0dXJlc0Zyb21PYmplY3RzPTFiNnJlYXJyPXNjaGVtZV9Mb2NhbC9HZW8vSG90ZWxCb29zdD1ib29raW5nX2Jvb2tpbmdzXzEyd2oCcnVwAZUBAAAAAJ0BzcxMPqABAagBAL0BrX1uHsIBN477yPQErvSIgswE7PWIjAST6s%2B1pQKqupznA7biu7DDBKiD5dvZAoK3l5wEuMTXz4EEiJat4APqAQDyAQD4AQCCAi7QvNC%2B0YHQutCy0LAg0L%2FQvtC40YHQuiDQutC40L3QvtGC0LXQsNGC0YDQvtCyigIA&sll=37.651246%2C55.751046&source=wizbiz_new_text_multi&sspn=0.606609%2C0.262287&z=10";
		private static List<string> urlSinema = new List<string>();

		public static void Main()
		{
			WebClient wc = new WebClient();
			string url = urlSites;
			string text = wc.DownloadString(url);
			
			//return LoadInfoSinema(text);
			Console.WriteLine(LoadInfoSinema(text));
		}

		static string LoadInfoSinema(string answer)
		{
			if (answer == null)
			{
				return null;
			}

			var parser = new HtmlParser();
			WebClient wc = new WebClient();
			string allInfo = "";

			var texts = parser.ParseDocument(answer).GetElementsByClassName(test);
			//var texts = parser.ParseDocument(answer).GetElementsByClassName(test);
			//var categories = parser.ParseDocument(answer).GetElementsByClassName(test1);
			//var time = parser.ParseDocument(answer).GetElementsByClassName(test2);

			//info = new string[texts.Length];

			//foreach (var text in texts)
			//{
			//	text.TextContent = text.TextContent.Replace("\n", "");
			//	info[count++] = text.TextContent + ":";
			//}

			//count = 0;

			//foreach (var text in categories)
			//{
			//	info[count] = info[count++] + " " + text.TextContent;
			//}

			//count = 0;

			//foreach (var text in time)
			//{
			//	text.TextContent = text.TextContent.Replace("\n", "");
			//	info[count] = info[count] + ";" + "\n" + "Время:" + text.TextContent;
			//	allSinema = allSinema + info[count++] + "\n";	
			//}

			//var city = parser.ParseDocument(texts.ToString()).GetElementsByClassName("list");

			foreach (var text in texts)
			{
				var link = text.GetAttribute("href");
				urlSinema.Add("https://yandex.ru" + link);
			}

			for(int i = 0; i < urlSinema.Count; i++)
			{
				string infoSite = wc.DownloadString(urlSinema[i]);

				var pageInfo = parser.ParseDocument(infoSite).GetElementsByClassName(test1);

				foreach (var pI in pageInfo)
				{
					string name = pI.TextContent;
					allInfo = allInfo + name + "\n";
				}

				pageInfo = parser.ParseDocument(infoSite).GetElementsByClassName(test2);

				foreach (var pI in pageInfo)
				{
					string name = pI.TextContent;
					allInfo = allInfo + name + "\n";
				}
			}
			

			//allInfo = allInfo + "\nСеансы: ";

			//pageInfo = parser.ParseDocument(infoSite).GetElementsByClassName(test3);

			//foreach (var pI in pageInfo)
			//{
			//	var temp = pI.Children;
			//	foreach(var tmp in temp)
			//	{
			//		var name = tmp.TextContent;
			//		allInfo = allInfo + name;
			//	}
				
			//}

			return (allInfo);
		}
	}
}
