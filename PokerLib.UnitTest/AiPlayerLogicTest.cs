using NUnit.Framework;
using Poker.Lib;
using static Poker.Suite;
using static Poker.Rank;
using Poker;
using System.Linq;

namespace PokerLib.UnitTest
{
    [TestFixture]
    public class AiPlayerLogicTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CanConstructAiPlayerLogic()
        {
            IPlayerLogic ai = new AiPlayerLogic();
        }

        [Test]
        public void AiCanMakeSmartDecisionAboutFlush()
        {
            
        }
    }
}
