﻿using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading.Tasks;
using DensoCreate.LightningReview.ReviewFile.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DensoCreate.LightningReview.ReviewFile.Tests.Base
{
    /// <summary>
    /// テストのベースクラス
    /// </summary>
    public class TestBase
    {
        /// <summary>
        /// テストデータ格納フォルダ（ビルドしたDLLファイルからの相対パス）
        /// </summary>
        protected virtual string TestDataFolderName => @"TestData";

        /// <summary>
        /// テストデータのファイルパスを取得します。
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <param name="fileName">テストデータのファイル名</param>
        /// <returns>テストデータのファイルパス</returns>
        protected string GetTestDataPath(string version="",string fileName = null)
        {
            var exePath = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            var dir = Path.Combine(exePath, TestDataFolderName, version);

            if (string.IsNullOrEmpty(fileName))
            {
                return dir;
            }

            var path = Path.Combine(dir, fileName);
            Assert.IsTrue(File.Exists(path), $"テストデータのファイル{path}が存在しません");
            return path;
        }

        /// <summary>
        /// レビューファイルのロード
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected IReview ReadReviewFile(string version, string filePath)
        {
            var filepath = GetTestDataPath(version, filePath);
            var reader = new ReviewFileReader();
            var review = reader.Read(filepath);
            return review;
        }

        /// <summary>
        /// フォルダを作成します。すでにあればファイルを削除して再作成します。
        /// </summary>
        /// <param name="directory"></param>
        protected void RecreateDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
            }
            else
            {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// フォルダを削除します。
        /// </summary>
        /// <param name="directory"></param>
        protected void RemoveDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(directory);
            }
        }

        /// <summary>
        /// ストリームのロード
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected IReview ReadReviewStream(string version, string fileName)
        {
            var filePath = GetTestDataPath(version, fileName);
            using (var archive = ZipFile.OpenRead(filePath))
            {
                // revxから"Review.xml"を抜き出す
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using (var zipEntryStream = reviewXmlEntry.Open())
                {
                    var reader = new ReviewFileReader();
                    var review = reader.Read(zipEntryStream);
                    return review;
                }
            }
        }

        /// <summary>
        /// 非同期のストリームのロード
        /// </summary>
        /// <param name="version">バージョン</param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        protected async Task<IReview> ReadAsyncReviewStream(string version, string fileName)
        {
            var filePath = GetTestDataPath(version, fileName);
            using (var archive = ZipFile.OpenRead(filePath))
            {
                // revxから"Review.xml"を抜き出す
                var reviewXmlEntry = archive.GetEntry("Review.xml");
                using (var zipEntryStream = reviewXmlEntry.Open())
                {
                    var reader = new ReviewFileReader();
                    var review = await reader.ReadAsync(zipEntryStream);
                    return review;
                }
            }
        }
    }
}
