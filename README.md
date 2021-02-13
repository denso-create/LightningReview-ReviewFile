# LightningReview-RevxFile

![Build](https://img.shields.io/github/workflow/status/denso-create/LightningReview-RevxFile/Build)


デンソークリエイトのレビュー支援ツール Lightning Review（https://www.lightning-review.com/) のrevxファイルに関するライブラリ・ツールです。.NET Standard/.NET Coreで開発をしているのでWindows/Linux/Macで動作可能です。

## LightningReview.RevxFile

[![NuGet](https://img.shields.io/nuget/v/LightningReview.RevxFile.svg)](http://nuget.org/packages/LightningReview.RevxFile)


Lightning Reviewのrevxファイルを高速に読み書き可能なライブラリです。

* コンパクトで他への依存関係がない軽量な設計になっています。
* 1000ファイルのレビューファイル(revx)の読み込みに数秒程度で処理可能と非常に高速になっています。
* 現在は読み込みのみサポートしています。

### Install
```
C:\Project> NuGet Install LightningReview.RevxFile
```

### 例
単一のレビューファイルを指定する場合

```cs
using LightningReview.RevxFile;
using LightningReview.RevxFile.Models;

//...

// revxファイルを読み込むクラスです
var reader = new RevxReader();

// 単一のレビューファイルを指定する場合
var review = reader.Read(revxFilePath);
Console.WriteLine(review.AllIssues.Count());
```


フォルダにある複数のレビューファイルを指定する場合
```cs
    // フォルダにある複数のレビューファイルを指定する場合
    var reviews = reader.ReadFolder(revxFolder);
    foreach ( var review in reviews)
    {
        Console.WriteLine(review.AllIssues.Count());
    }
```


## LightnigReview.RevxToJsonService

[![NuGet](https://img.shields.io/nuget/v/LightningReview.RevxToJsonService.svg)](http://nuget.org/packages/LightningReview.RevxToJsonService)

フォルダ内のLightning Reviewのrevxファイルの内容を読み込んでJSONファイルに出力するライブラリです。
レビューの指摘件数、メトリクスの計算などで利用して下さい。


### Install
```
C:\Project> NuGet Install LightnigReview.RevxToJsonService
```


### 例

```cs
using LightnigReview.RevxToJsonService;

//...

// エクスポート処理
var exporter = new RevxToJsonExporter();

// ロガーを設定しておく
exporter.Logger = (message) => Console.WriteLine(message);

// 実行
exporter.Export(revxFolderPath, jsonFilePath);
```


## RevxToJsonCLI

フォルダ内のrevxファイルの内容をJSONファイルに出力するコマンドラインプログラムです。

| revxToJson.exe -f revxFolder

と実行すると、現在のフォルダに `output.json` を出力します。

| revxToJson.exe -f revxFolder -o myJsonFile.json

のように `-o`で出力ファイル（パス）を指定できます。

| revxToJson.exe -f revxFolder -o myJsonFile.json -r

`-r`を指定するとサブフォルダまで対象にできます。


