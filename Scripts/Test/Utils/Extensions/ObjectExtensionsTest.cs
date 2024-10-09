using NUnit.Framework;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils.Extensions;
using UnityEngine;

namespace UnityBase.Test.Projects.unity_base.Scripts.Test.Utils.Extensions
{
    public class ObjectExtensionsTest
    {
        [Test]
        public void TestClassFull()
        {
            var s = "123";
            var sa = s.ToSingleArray();

            Assert.NotNull(sa);
            Assert.AreEqual(typeof(string), sa.GetType().GetElementType());
            Assert.AreEqual(1, sa.Length);
            Assert.AreEqual("123", sa[0]);
        }

        [Test]
        public void TestClassEmpty()
        {
            string s = null;
            var sa = s.ToSingleArray();

            Assert.NotNull(sa);
            Assert.AreEqual(typeof(string), sa.GetType().GetElementType());
            Assert.AreEqual(0, sa.Length);
        }

        [Test]
        public void TestStructFull1()
        {
            var v = new Vector3(1f, 2f, 3f);
            var va = v.ToSingleArray();

            Assert.NotNull(va);
            Assert.AreEqual(typeof(Vector3), va.GetType().GetElementType());
            Assert.AreEqual(1, va.Length);
            Assert.AreEqual(new Vector3(1f, 2f, 3f), va[0]);
        }

        [Test]
        public void TestStructFull2()
        {
            Vector3? v = new Vector3(1f, 2f, 3f);
            var va = v.ToSingleArray();

            Assert.NotNull(va);
            Assert.AreEqual(typeof(Vector3), va.GetType().GetElementType());
            Assert.AreEqual(1, va.Length);
            Assert.AreEqual(new Vector3(1f, 2f, 3f), va[0]);
        }

        [Test]
        public void TestStructEmpty()
        {
            Vector3? v = null;
            var va = v.ToSingleArray();

            Assert.NotNull(va);
            Assert.AreEqual(typeof(Vector3), va.GetType().GetElementType());
            Assert.AreEqual(0, va.Length);
        }
    }
}