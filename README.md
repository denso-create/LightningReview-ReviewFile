# LightningReview-ReviewFile

![Build](https://img.shields.io/github/workflow/status/denso-create/LightningReview-ReviewFile/Build)

デンソークリエイトのレビュー支援ツール Lightning Review（https://www.lightning-review.com/) のレビューファイルに関するライブラリとツールです。Lightning Reviewアプリケーション不要でLightning Reviewのレビューファイルの高速なデータ読み込みが可能です。また、.NET Standard/.NET Coreで開発をしているのでWindows/Linux/Macで動作可能です。


## LightningReview.ReviewFile

[![NuGet](https://img.shields.io/nuget/v/LightningReview.ReviewFile.svg)](http://nuget.org/packages/LightningReview.ReviewFile)

Lightning Reviewのレビューファイルのレビューや指摘のデータを高速に読み込み可能なライブラリです。

* コンパクトで他への依存関係がない軽量な設計になっています。
* 複数のLightning Reviewバージョンでの分析が可能です。Lightning ReviewはV1.8でレビューファイルのフォーマットが変わりましたが、このライブラリではV1.8でもそれ以前のバージョンでもどちらのファイルも対応しています。
* 1000ファイルのレビューファイルの読み込みに数秒程度で処理可能と非常に高速になっています。
* 複数のレビューファイルを集計して品質メトリクスを計測するようなユースケースを想定しています。従って、現時点ではレビューファイルの要素にすべての対応しているわけではありません。主にレビューと指摘に関する情報が参照できます。 現在はDocumentのOutline取得についてはLightning ReviewのV1.8以降のフォーマットのみ対応しています。また指摘画像やレビュー設定の読み込みは対応していません。

### Install

Nuget: [LightningReview.ReviewFile](https://www.nuget.org/packages/LightningReview.ReviewFile/)

```
C:\Project> NuGet Install LightningReview.ReviewFile
```
### 例
単一のレビューファイルを指定する場合

```cs
using LightningReview.ReviewFile;
using LightningReview.ReviewFile.Models;

//...

// レビューファイルを読み込むクラスです
var reader = new ReviewFileReader();

// 単一のレビューファイルを指定する場合
var review = reader.Read(ReviewFilePath);
Console.WriteLine(review.Issues.Count());
```

フォルダにある複数のレビューファイルを指定する場合
```cs
// フォルダにある複数のレビューファイルを指定する場合
var reviews = reader.ReadFolder(folder);
foreach ( var review in reviews)
{
    Console.WriteLine(review.Name);

    // レビューごとの指摘件数
    Console.WriteLine(review.Issues.Count());

    // 指摘毎の詳細
    foreach ( var issue in review.Issues)
    {
        Console.WriteLine(issue.Description);
    }
}
```

読み込んだレビューおよび指摘の要素にアクセスする場合
```cs
// レビューの要素にアクセスする場合
var review = reader.Read(ReviewFilePath);

// レビューのプロジェクト名
Console.WriteLine(review.ProjectName);
// レビューの目標件数
Console.WriteLine(review.IssueCountOfGoal);
// レビューの最終更新日時
Console.WriteLine(review.LastUpdatedDateTime);

// レビューが持つ指摘の要素にアクセスする場合
foreach (var issue in review.Issues)
{
	// 指摘の状態
	Console.WriteLine(issue.Status);
    // 指摘の優先度
	Console.WriteLine(issue.Priority);
    // 指摘の修正日
    Console.WriteLine(issue.DateFixed);
}
```

## LightnigReview.ReviewFileToJsonService

[![NuGet](https://img.shields.io/nuget/v/LightningReview.ReviewFileToJsonService.svg)](http://nuget.org/packages/LightningReview.ReviewFileToJsonService)

フォルダ内のLightning Reviewのレビューファイルの内容を読み込んでJSONファイルに出力するライブラリです。
`LightningReview.ReviewFile` を参照して作成している軽量なライブラリです。レビューの指摘件数、メトリクスの計算などで利用して下さい。


### Install

Nuget: [LightningReview.ReviewFileToJsonService](https://www.nuget.org/packages/LightningReview.ReviewFileToJsonService/)

```
C:\Project> NuGet Install LightnigReview.ReviewFileToJsonService
```


### 例

```cs
using LightnigReview.ReviewFileToJsonService;

//...

// エクスポート処理
var exporter = new ReviewFileToJsonExporter();

// ロガーを設定しておく
exporter.Logger = (message) => Console.WriteLine(message);

// 実行
exporter.Export(folderPath, jsonFilePath);
```


## ReviewFileToJsonCLI

フォルダ内のレビューファイルの内容をJSONファイルに出力するコマンドラインプログラムです。

| ReviewFileToJson.exe -f folder

と実行すると、現在のフォルダに `output.json` を出力します。

| ReviewFileToJson.exe -f folder -o myJsonFile.json

のように `-o`で出力ファイル（パス）を指定できます。

| ReviewFileToJson.exe -f folder -o myJsonFile.json -r

`-r`を指定するとサブフォルダまで対象にできます。

### 出力されるJSONファイルのフォーマット

```json 
{
    "TotalReviewCount": 3,  // 読みこんだレビューファイルの数
    "TotalIssueCount": 9,   // すべてのレビューファイルの指摘の合計
    "Reviews": [            // 読み込んだレビューの一覧 
        {
            // レビュー①のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc0",
            "FilePath": "C:\\work\\\\RevFile1.revx",
            // ...
            "Issues": [
                {
                    // レビュー①に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f8",
                    "LID": "1",
                    // ...
                },
                {
                    // レビュー①に関連する指摘②のフィールド情報
                    "GID": "4eaf62fa-995a-45f7-9ddf-65e605bfc28c",
                    "LID": "2",
                    // ...
                }
            ]  
        },
        {
            // レビュー②のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc1",
            "FilePath": "C:\\work\\\\RevFile2.revx",
            // ...
            "Issues": [
                {
                    // レビュー②に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f9",
                    "LID": "1",
                    // ...
                }
            ]
        }
    ]
}
``` 
### 出力フィールドの説明
フィールド情報の詳細は下記クラスに記載してありますのでそちらを参照ください。
- レビューのフィールド情報：　　
  https://github.com/denso-create/LightningReview-ReviewFile/blob/master/src/ReviewFileToJsonService/Models/Review.cs#L43
- 指摘のフィールド情報：https://github.com/denso-create/LightningReview-ReviewFile/blob/master/src/ReviewFileToJsonService/Models/Issue.cs#L35