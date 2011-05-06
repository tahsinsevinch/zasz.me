﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using zasz.develop.SampleData;
using zasz.me.Areas.Shared.Models;
using zasz.me.Controllers.Utils;
using zasz.me.Integration.EntityFramework;

namespace zasz.health.IntegrationTests
{
    [TestClass]
    public class PostAndTagRepositoryTests
    {
        private FullContext _FullContext;
        private Posts _Posts;
        private Tags _Tags;

        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new ColdStorageInitializer());
            PostsData.RegisterSites();
            _FullContext = new FullContext();
            _Tags = new Tags(_FullContext);
            _Posts = new Posts(_FullContext, _Tags);
            var Count = _Posts.Count();
            if (Count == 0)
            {
                var SamplePosts = PostsData.GetFromFolder(Environment.GetEnvironmentVariable("SampleDataPath", EnvironmentVariableTarget.Machine), Log);
                foreach (Post SamplePost in SamplePosts)
                {
                    SamplePost.Site = Site.WithName("Both");
                    _Posts.Save(SamplePost);
                }
                _Posts.Commit();
            }
        }

        [TestMethod]
        public void TestPaging()
        {
            var Ids = new List<string> {"Fact-and-Fiction", "Getting-started-with-Apache-Struts-2-2c-with-Netbeans-61"};
            var Posts = _Posts.Page(0, 10);
            var ActualIds = Posts.Collect(Post => Post.Slug);
            Assert.IsTrue(Ids.TrueForAll(ActualIds.Contains));
        }


        [TestMethod]
        public void TestCount()
        {
            var Posts = _Posts.Count();
            var Both = _Posts.Count(Site.WithName("Both"));
            var Pro = _Posts.Count(Site.WithName("Pro"));
            var Rest = _Posts.Count(Site.WithName("Rest"));
            Assert.AreEqual(Both, Posts);
            Assert.AreEqual(Pro, Posts);
            Assert.AreEqual(Rest, Posts);
        }

        [TestMethod]
        public void TestTagPagingQuery()
        {
            var Posts = _Tags.PagePosts("asp.net", 0, 2, Site.WithName("Pro"));
            Assert.AreEqual(2, Posts.Count);

            Posts = _Tags.PagePosts("asp.net", 0, 100, Site.WithName("Pro"));
            Assert.AreEqual(7, Posts.Count);

            Posts = _Tags.PagePosts("games", 0, 100, Site.WithName("Pro"));
            Assert.AreEqual(7, Posts.Count);

            Posts = _Tags.PagePosts("dota", 0, 100, Site.WithName("Pro"));
            Assert.AreEqual(8, Posts.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            _FullContext.Dispose();
        }

        public void Log(string Log)
        {
            Console.WriteLine(Log);
        }
    }
}