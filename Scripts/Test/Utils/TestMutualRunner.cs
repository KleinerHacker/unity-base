using NUnit.Framework;
using UnityBase.Runtime.Projects.unity_base.Scripts.Runtime.Utils;

namespace UnityBase.Test.Projects.unity_base.Scripts.Test.Utils
{
    public class TestMutualRunner
    {
        [Test]
        public void Test()
        {
            var counter = 0;
            var runner = new MutualRunner();
            var mainRun = runner.Try(() =>
            {
                counter++;
                var run = runner.Try(() => counter++);
                Assert.IsFalse(run);
            });
            
            Assert.IsTrue(mainRun);
            Assert.AreEqual(1, counter);
        }
    }
}