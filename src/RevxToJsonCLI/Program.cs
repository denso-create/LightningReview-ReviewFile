using CommandLine;
using LightningReview.RevxToJsonService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace RevxToJson
{
    class Program
    {
		/// <summary>
		/// コマンドラインパーサのオプション設定
		/// </summary>
		class Options
		{
			[Option('f',"folder",Required =true,HelpText ="対象のレビューファイルが存在しているフォルダを指定します。")]
			public string FolderPath { get; set; }

			[Option('o', "output", Required = false, HelpText = "JSONファイルの出力先のパスを指定します。")]
			public string OutputPath { get; set; }

			[Option('r', "recursive", Required = false,  HelpText = "サブフォルダも含めてファイルを検索します。" , Default =false)]
			public bool Recursive { get; set; }
		}

		/// <summary>
		/// メイン
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
        {

			#region コマンドライン引数を取得
			// 引数を取得
			var parseResult = Parser.Default.ParseArguments<Options>(args);
			if (parseResult.Tag == ParserResultType.NotParsed)
			{
				Console.WriteLine($"エラー：パラメータの指定に誤りがあります。");
				return;
			}  

			var parsed = parseResult as Parsed<Options>;

			// 対象のフォルダパスおよび出力パスを取得
			var folderPath = parsed.Value.FolderPath;
			if (!Directory.Exists(folderPath))
			{
				Console.WriteLine($"エラー：指定したフォルダ{folderPath}は存在しません。");
				return;
			}

			// 出力先のファイルが指定なければ設定する
			var outputPath = parsed.Value.OutputPath;
			if ( string.IsNullOrEmpty(outputPath) ) {
				outputPath = "output.json";
			}

			// サブフォルダを含む
			var recursive = parsed.Value.Recursive;

            #endregion

            #region 処理の実行

			// ストップウォッチを用意しておく
            var stopWatch = new Stopwatch();
			stopWatch.Start();

			// エクスポート処理
			var exporter = new RevxToJsonExporter();

			// ロガーを設定しておく
			exporter.Logger = (message) => Console.WriteLine(message);
			Console.WriteLine($"フォルダ{folderPath}のレビューファイルを検索しています。");

			// 実行
			exporter.Export(folderPath, outputPath, recursive);
			stopWatch.Stop();

            // 完了メッセージ
            Console.WriteLine($"成功：検索したレビューファイルのJsonデータを{outputPath}に作成しました（処理時間 {stopWatch.ElapsedMilliseconds}ms)。");

			#endregion
		}
	}
}
