using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelBot
{
	class Program
	{
		private static ITelegramBotClient botClient;
		private static readonly char prefics = '/';
		//private static KeyboardButton button;
		//private static ReplyKeyboardMarkup markUp;

		static void Main(string[] args)
		{
			
			botClient = new TelegramBotClient("1627227016:AAFv46I51dASl1sWFNslembOQwrIWzVJtGA") {Timeout = TimeSpan.FromSeconds(10) };

			botClient.OnMessage += BotClient_OnMessage;
			botClient.StartReceiving();

			Console.ReadKey();
		}

		private static async void BotClient_OnMessage(object sender, MessageEventArgs e)
		{
			var text = e?.Message?.Text;
			if (text == null) return;

			if(text == $"{prefics}start")
			{
				await botClient.SendTextMessageAsync
					(
						chatId: e.Message.Chat.Id,
						$"Список команд: /check, /films ..."
					).ConfigureAwait(false);
			}

			if (text == $"{prefics}check")
			{
				await botClient.SendTextMessageAsync
					(
						chatId: e.Message.Chat.Id,
						$"https://www.youtube.com/watch?v=GrvA9r99-KQ"
					).ConfigureAwait(false);
			}

			//if (text == $"{prefics}films")
			//{
			//	await botClient.SendTextMessageAsync
			//		(
			//			chatId: e.Message.Chat.Id,
			//			$"{Source.SearchSinema.Init()}"
			//		).ConfigureAwait(false);
			//}

			if (text == $"{prefics}location")
			{
				await botClient.SendTextMessageAsync
					(
						chatId: e.Message.Chat.Id,
						$"Ок.",
						replyMarkup: GetButton()
					).ConfigureAwait(false);
			}
		}

		private static IReplyMarkup GetButton()
		{
			return new ReplyKeyboardMarkup
			{
				OneTimeKeyboard = true,
				Keyboard = new List<List<KeyboardButton>>
				{
					new List<KeyboardButton> { new KeyboardButton { Text = "Указать своё местоположение", RequestContact = true } }
				}
			};
		}
	}
}
