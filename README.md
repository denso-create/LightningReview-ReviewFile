# LightningReview-ReviewFile

![Build](https://img.shields.io/github/workflow/status/denso-create/LightningReview-ReviewFile/Build) [![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=denso-create_LightningReview-ReviewFile&metric=alert_status)](https://sonarcloud.io/dashboard?id=denso-create_LightningReview-ReviewFile)

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
// レビューを取得する
var review = reader.Read(ReviewFilePath);

// レビューのプロジェクト名
Console.WriteLine(review.ProjectName);
// レビューの目標件数
Console.WriteLine(review.IssueCountOfGoal);
// レビューの計画実施日
Console.WriteLine(review.PlannedDate);

// レビューが持つ指摘を取得する
foreach (var issue in review.Issues)
{
    // 指摘のステータス
    Console.WriteLine(issue.Status);
    // 指摘の優先度
    Console.WriteLine(issue.Priority);
    // 指摘の修正日
    Console.WriteLine(issue.DateFixed);
}
```
### フレームワーク
.Net Standard 2.0

### 依存パッケージ
なし

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

### フレームワーク
- .Net Standard 2.0

### 依存パッケージ
- LightnigReview.ReviewFile  
- System.Text.Json  
- System.Text.Encodings.Web

## ReviewFileToJsonCLI

フォルダ内のレビューファイルの内容をJSONファイルに出力するコマンドラインプログラムです。

| ReviewFileToJson.exe -f folderPath

`-f`でレビューファイルが格納されたフォルダパスを指定すると、現在のフォルダに `output.json` を出力します。

| ReviewFileToJson.exe -f folderPath -o myJsonFile.json

 `-o`で出力ファイル（パス）を指定できます。

| ReviewFileToJson.exe -f folderPath -o myJsonFile.json -r

`-r`を指定するとサブフォルダまで対象にできます。

| ReviewFileToJson.exe -f folderPath -u

`-u`を指定すると出力されるJSONファイルにおいてUnicodeエスケープを行いません。

### `-u`オプションの注意点
本オプションをつけることで出力されるJSONファイルはUTF-8でエンコードされたJSONファイルとなります。  
以下はJSONファイルの指摘の重大度の出力イメージ例

```
"Importance": "\u4E2D" // -u オプションをつけず、Unicodeエスケープされた状態
"Importance": "中"     // -u オプションをつけて、UTF-8で出力された状態
```

-uをつけて出力されたJSONファイルを別ツールで読み込む場合は、ファイル内容がうまく読み取れなくなる恐れがあるため、UTF-8で読み込む必要があることに注意してください。

### 出力されるJSONファイルのフォーマット

``` 
{
    "TotalReviewCount": 3,  // 読みこんだレビューファイルの数
    "TotalIssueCount": 9,   // すべてのレビューファイルの指摘の合計
    "Reviews": [            // 読み込んだレビューの一覧 
        {
            // レビュー①のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc0",
            "FilePath": "C:\\work\\\\RevFile1.revx",
            //...
            "Issues": [
                {
                    // レビュー①に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f8",
                    "LID": "1",
                    //...
                },
                {
                    // レビュー①に関連する指摘②のフィールド情報
                    "GID": "4eaf62fa-995a-45f7-9ddf-65e605bfc28c",
                    "LID": "2",
                    //...
                }
            ]  
        },
        {
            // レビュー②のフィールド情報
            "GID": "b90a3142-2c05-4550-9ac5-008ea6461bc1",
            "FilePath": "C:\\work\\\\RevFile2.revx",
            //...
            "Issues": [
                {
                    // レビュー②に関連する指摘①のフィールド情報
                    "GID": "a74cde8d-d7e7-4948-8a60-82f0fabea5f9",
                    "LID": "1",
                    //...
                }
            ]
        }
    ]
}
``` 

### 出力フィールドの説明
フィールド情報の詳細は下記クラスに記載してあります。
- レビューのフィールド情報について: [Review.cs](https://github.com/denso-create/LightningReview-ReviewFile/blob/main/src/ReviewFileToJsonService/Models/Review.cs)
- 指摘のフィールド情報について: [Issue.cs](https://github.com/denso-create/LightningReview-ReviewFile/blob/main/src/ReviewFileToJsonService/Models/Issue.cs)

### フレームワーク
- .Net Core 3.1

### 依存パッケージ
- LightningReview.ReviewFileToJsonService
- CommandLineParser

### 活用例：コマンドラインから読み出してExcelに展開します

本ライブラリの具体的な利用例を動画を使ってご紹介します。  
ここでは、以下の Step で実施します。  

- [Step1：コマンドラインプログラムを実行してレビューファイルのデータを取得します](https://github.com/denso-create/LightningReview-ReviewFile#step1%E3%82%B3%E3%83%9E%E3%83%B3%E3%83%89%E3%83%A9%E3%82%A4%E3%83%B3%E3%81%8B%E3%82%89%E8%AA%AD%E3%81%BF%E5%87%BA%E3%81%97%E3%81%A6%E6%83%85%E5%A0%B1%E3%82%92%E5%8F%96%E5%BE%97%E3%81%99%E3%82%8B)
- [Step2：取得したレビューファイルのデータをExcel上に表形式で表示します](https://github.com/denso-create/LightningReview-ReviewFile#step2%E5%8F%96%E5%BE%97%E3%81%97%E3%81%9F%E6%83%85%E5%A0%B1%E3%82%92excel%E3%81%AB%E5%B1%95%E9%96%8B%E3%81%99%E3%82%8B)

#### Step1：コマンドラインプログラムを実行してレビューファイルのデータを取得します

フォルダ内に複数格納されているレビューファイルに登録されたレビューや指摘といったデータを、JSON形式の出力ファイルとして取得します。  
下の動画では、Windows のコマンドプロンプトにて Lightning Review のファイルが複数格納されたフォルダを指定して実行することで、output.jsonという出力ファイルを取得しています。

![output](https://user-images.githubusercontent.com/71699816/136491468-6979b6df-05fd-4824-8ecb-2d166cda3d6d.gif)

#### Step2：取得したレビューファイルのデータをExcel上に表形式で表示します

JSON形式で取得されたoutput.jsonは、Excelの機能を利用して表形式に変換できます。  
下の動画では、Step1 にて取得したoutput.jsonファイルをExcelで表に変換して表示しています。  
Lightning Review ファイルが保持しているそのままのデータを一覧に表示できるため、その後はお好みの形に合わせて分析できます。

![data_transform](https://user-images.githubusercontent.com/71699816/136491547-6348fb81-004b-42ac-9024-55512bea407c.gif)