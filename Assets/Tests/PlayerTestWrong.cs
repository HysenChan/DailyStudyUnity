using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestWrong : MonoBehaviour
{
    [Test]
    public void TestHealth()
    {
        Player player = new Player();
        player.Health = 1000.0f;
        //通过Assert断言来判断这个函数的返回结果是否符合预期
        player.DamageWrong(200);
        NUnit.Framework.Assert.AreEqual(800, player.Health);
        player.DamageWrong(150);
        NUnit.Framework.Assert.AreEqual(950, player.Health);
    }
    [Test]
    [ExpectedException(typeof(NegativeHealthException))]
    public void NegativeHealth()
    {
        Player player = new Player();
        player.Health = 1000;
        player.DamageNoException(500);
        player.DamageNoException(600);
    }
}
