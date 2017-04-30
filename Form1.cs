using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Services;
using Google.Apis.Translate.v2;
using Google.Apis.Translate.v2.Data;

namespace GoogleTranslationAPI_Test
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TranslateText();
		}

		public async void TranslateText()
		{
			//번역 서비스 생성
			TranslateService service = new TranslateService(new BaseClientService.Initializer()
			{
				ApiKey = this.textBox3.Text,
				ApplicationName = " "
			});

			//string[] srcText = new[] { "Hello world!", "The Google APIs client library for .NET uses client_secrets.json files for storing the client_id, client_secret, and other OAuth 2.0 parameters." };

			try
			{
				//번역 요청
				TranslationsListResponse response
					= await service.Translations.List(textBox1.Text, "ko").ExecuteAsync();
				//결과를 저장
				textBox2.Text = response.Translations[0].TranslatedText;


			}
			catch (Exception ex)
			{
				//api에서 문제가 생겨도 여기서 오류가 발생한다.
				//오류 내용을 확인해서 로그를 남겨야 할듯
				Console.WriteLine("오류 :" + ex.ToString());
			}

		}

	}
}
